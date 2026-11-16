using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace PolyhedronLab
{
    public partial class Form1 : Form
    {
        private readonly Renderer _renderer = new Renderer();
        private Polyhedron _poly;
        private Matrix4x4 _modelMatrix = Matrix4x4.Identity();

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, canvas, new object[] { true });

            cmbShape.SelectedIndex = 1;   // по умолчанию — куб
            _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);
            _renderer.PerspectiveMode = rbPerspective.Checked;
            lblStatus.Text = "Готово.";
        }

        private void canvas_Resize(object sender, EventArgs e) => canvas.Invalidate();

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvas.Width == 0 || canvas.Height == 0) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (_poly == null) return;
            var display = _poly.Transformed(_modelMatrix);
            _renderer.Draw(e.Graphics, display, canvas.Width / 2, canvas.Height / 2);
        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);
            _modelMatrix = Matrix4x4.Identity();
            lblStatus.Text = $"Загружен: {cmbShape.Text}";
            canvas.Invalidate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Wavefront OBJ (*.obj)|*.obj|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _poly = ObjParser.Load(ofd.FileName);
                        _modelMatrix = Matrix4x4.Identity();
                        lblStatus.Text = $"Загружен: {Path.GetFileName(ofd.FileName)}";
                        canvas.Invalidate();
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_poly == null) return;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Wavefront OBJ (*.obj)|*.obj";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ObjParser.Save(_poly.Transformed(_modelMatrix), sfd.FileName);
                        lblStatus.Text = "Сохранено.";
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var p = ParseParams(txtParams.Text);
                Matrix4x4 op = Matrix4x4.Identity();
                switch (cmbOp.SelectedIndex)
                {
                    case 0: Require(p, 3); op = Matrix4x4.Translate(p[0], p[1], p[2]); break;
                    case 1: Require(p, 3); op = Matrix4x4.Scale(p[0], p[1], p[2]); break;
                    case 2: Require(p, 1); op = Matrix4x4.ScaleAboutCenter(_poly.Center, p[0]); break;
                    case 3: Require(p, 1); op = Matrix4x4.RotateX(p[0]); break;
                    case 4: Require(p, 1); op = Matrix4x4.RotateY(p[0]); break;
                    case 5: Require(p, 1); op = Matrix4x4.RotateZ(p[0]); break;
                }
                _modelMatrix = op * _modelMatrix;
                lblStatus.Text = "Применено.";
                canvas.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _modelMatrix = Matrix4x4.Identity();
            lblStatus.Text = "Сброс.";
            canvas.Invalidate();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            _modelMatrix = Matrix4x4.Identity();
            lblStatus.Text = "Отменено.";
            canvas.Invalidate();
        }

        private void btnApplyLight_Click(object sender, EventArgs e)
        {
            try
            {
                var lp = ParseParams(txtLightPos.Text);
                Require(lp, 3);
                _renderer.Light.Position = new Point3D(lp[0], lp[1], lp[2]);

                var lc = ParseParams(txtLightColor.Text);
                Require(lc, 3);
                _renderer.Light.Color = Color.FromArgb((int)lc[0], (int)lc[1], (int)lc[2]);

                var oc = ParseParams(txtObjectColor.Text);
                Require(oc, 3);
                _renderer.ObjectColor = Color.FromArgb((int)oc[0], (int)oc[1], (int)oc[2]);

                lblStatus.Text = "Свет и цвет обновлены.";
                canvas.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbProjection_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.PerspectiveMode = rbPerspective.Checked;
            lblStatus.Text = rbPerspective.Checked ? "Перспектива" : "Аксонометрия";
            canvas.Invalidate();
        }

        // ----- Вспомогательные -----
        private double[] ParseParams(string text)
        {
            text = text.Trim();
            if (text.Length == 0) return new double[0];
            var parts = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                string t = parts[i].Trim();
                if (!double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out res[i]) &&
                    !double.TryParse(t.Replace('.', ','), out res[i]))
                    throw new FormatException("Неверный формат числа: " + parts[i]);
            }
            return res;
        }

        private static void Require(double[] p, int n)
        {
            if (p.Length < n) throw new ArgumentException($"Требуется {n} параметр(ов), получено {p.Length}.");
        }
    }
}