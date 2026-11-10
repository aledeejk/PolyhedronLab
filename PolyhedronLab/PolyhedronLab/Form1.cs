using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PolyhedronLab
{
    public partial class Form1 : Form
    {
        private Polyhedron _poly;
        private readonly Renderer _renderer = new Renderer();
        private Matrix4x4 _modelMatrix = Matrix4x4.Identity();
        private Stack<Matrix4x4> _matrixHistory = new Stack<Matrix4x4>();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, canvas, new object[] { true });

            _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);
            _renderer.PerspectiveMode = rbPerspective.Checked;
            lblStatus.Text = "Готово. Выберите действие.";

            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
        }

        private void canvas_Resize(object sender, EventArgs e) => canvas.Invalidate();

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_poly == null || _poly.Vertices.Count == 0) return;
            if (canvas.Width == 0 || canvas.Height == 0) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var display = _poly.Transformed(_modelMatrix);
            _renderer.Draw(e.Graphics, display, canvas.Width / 2, canvas.Height / 2);
        }

        // =========================================================================
        // ДЕЕВА АЛЕКСАНДРА
        // =========================================================================

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);
            lblStatus.Text = $"Загружен многогранник: {cmbShape.Text}";
            canvas.Invalidate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Wavefront OBJ (*.obj)|*.obj|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _poly = ObjParser.Load(ofd.FileName);
                        _modelMatrix = Matrix4x4.Identity();
                        _matrixHistory.Clear();
                        lblStatus.Text = $"Загружен файл: {Path.GetFileName(ofd.FileName)}";
                        canvas.Invalidate();
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_poly == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Wavefront OBJ (*.obj)|*.obj";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var display = _poly.Transformed(_modelMatrix);
                        ObjParser.Save(display, sfd.FileName);
                        lblStatus.Text = $"Сохранено в: {Path.GetFileName(sfd.FileName)}";
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка сохранения: " + ex.Message); }
                }
            }
        }

        // =========================================================================
        // БОЧАРОВА КАТЕРИНА
        // =========================================================================

        private void btnBuildRotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGeneratrix.Text)) txtGeneratrix.Text = "1,0,0; 2,0,0; 2,0,1; 1,0,1";

                var points = new List<Point3D>();
                var segments = txtGeneratrix.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < segments.Length; i++)
                {
                    var coords = segments[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (coords.Length == 3)
                    {
                        points.Add(new Point3D(
                            double.Parse(coords[0].Trim(), CultureInfo.InvariantCulture),
                            double.Parse(coords[1].Trim(), CultureInfo.InvariantCulture),
                            double.Parse(coords[2].Trim(), CultureInfo.InvariantCulture)));
                    }
                }

                if (points.Count < 2) throw new Exception("Образующая должна содержать хотя бы 2 точки.");

                int axis = cmbAxis.SelectedIndex;
                int divs = int.Parse(txtSegments.Text);

                _poly = PolyhedraFactory.CreateRotationFigure(points, axis, divs);
                _modelMatrix = Matrix4x4.Identity();
                _matrixHistory.Clear();
                lblStatus.Text = "Построена фигура вращения";
                canvas.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        // =========================================================================
        // СИДОРЧИК АЛИСА
        // =========================================================================

        private void btnBuildSurface_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRange.Text)) txtRange.Text = "-3, 3, -3, 3";
                if (string.IsNullOrWhiteSpace(txtDivs.Text)) txtDivs.Text = "20";

                var ranges = txtRange.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (ranges.Length != 4) throw new Exception("Введите 4 числа: x0, x1, y0, y1");

                double x0 = double.Parse(ranges[0].Trim(), CultureInfo.InvariantCulture);
                double x1 = double.Parse(ranges[1].Trim(), CultureInfo.InvariantCulture);
                double y0 = double.Parse(ranges[2].Trim(), CultureInfo.InvariantCulture);
                double y1 = double.Parse(ranges[3].Trim(), CultureInfo.InvariantCulture);

                int divs = int.Parse(txtDivs.Text);

                Func<double, double, double> f;
                switch (cmbFunction.SelectedIndex)
                {
                    case 0: f = (x, y) => Math.Sin(x) * Math.Cos(y); break;
                    case 1: f = (x, y) => x * x - y * y; break;
                    case 2: f = (x, y) => Math.Sin(Math.Sqrt(x * x + y * y)); break;
                    default: f = (x, y) => 0; break;
                }

                _poly = PolyhedraFactory.CreateSurfaceGraph(f, x0, x1, y0, y1, divs, divs);
                _modelMatrix = Matrix4x4.Identity();
                _matrixHistory.Clear();
                lblStatus.Text = "Построен график поверхности";
                canvas.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        // =========================================================================
        // Вызов всех преобразований.
        // =========================================================================

        private void ApplyOperation(ComboBox cmbOp, TextBox txtParams)
        {
            try
            {
                Matrix4x4 op = Matrix4x4.Identity();
                bool applyLocally = false;
                if (cmbOp.SelectedIndex != 9) _renderer.ShowAxisLine = false;

                if (cmbOp.SelectedIndex == 10)
                {
                    // --- ДЕЕВА АЛЕКСАНДРА: Отражение ---
                    var s = txtParams.Text.Trim().ToUpper();
                    if (s.Length != 1 || "XYZ".IndexOf(s[0]) < 0) throw new ArgumentException("Укажите X, Y или Z");
                    op = Matrix4x4.ReflectPlane(s[0]);
                }
                else
                {
                    var p = ParseParams(txtParams.Text);
                    switch (cmbOp.SelectedIndex)
                    {
                        // --- БОЧАРОВА КАТЕРИНА: Смещение, Масштаб, Повороты осей ---
                        case 0: Require(p, 3); op = Matrix4x4.Translate(p[0], p[1], p[2]); break;
                        case 1: Require(p, 3); if (p[0] == 0 || p[1] == 0 || p[2] == 0) throw new Exception("Масштаб не может быть 0."); op = Matrix4x4.Scale(p[0], p[1], p[2]); break;
                        case 2: Require(p, 1); if (p[0] == 0) throw new Exception("Масштаб не может быть 0."); op = Matrix4x4.ScaleAboutCenter(_poly.Center, p[0]); applyLocally = true; break;
                        case 3: Require(p, 1); op = Matrix4x4.RotateX(p[0]); break;
                        case 4: Require(p, 1); op = Matrix4x4.RotateY(p[0]); break;
                        case 5: Require(p, 1); op = Matrix4x4.RotateZ(p[0]); break;

                        // --- СИДОРЧИК АЛИСА: Повороты через центр и вокруг произвольной прямой ---
                        case 6: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(-1, 0, 0), _poly.Center + new Point3D(1, 0, 0), p[0]); applyLocally = true; break;
                        case 7: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(0, -1, 0), _poly.Center + new Point3D(0, 1, 0), p[0]); applyLocally = true; break;
                        case 8: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(0, 0, -1), _poly.Center + new Point3D(0, 0, 1), p[0]); applyLocally = true; break;
                        case 9:
                            Require(p, 7);
                            _renderer.ShowAxisLine = true;
                            _renderer.AxisPoint1 = new Point3D(p[0], p[1], p[2]);
                            _renderer.AxisPoint2 = new Point3D(p[3], p[4], p[5]);
                            op = Matrix4x4.RotateAroundLine(_renderer.AxisPoint1, _renderer.AxisPoint2, p[6]);
                            break;
                    }
                }

                _matrixHistory.Push(_modelMatrix);
                _modelMatrix = applyLocally ? _modelMatrix * op : op * _modelMatrix;

                if (_renderer.ShowAxisLine && cmbOp.SelectedIndex != 9)
                {
                    _renderer.AxisPoint1 = _renderer.AxisPoint1.Apply(_modelMatrix);
                    _renderer.AxisPoint2 = _renderer.AxisPoint2.Apply(_modelMatrix);
                }
                lblStatus.Text = $"Применено: {cmbOp.Text}";
                canvas.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnApply_Click(object sender, EventArgs e) => ApplyOperation(cmbOp, txtParams);
        private void btnApplyRot_Click(object sender, EventArgs e) => ApplyOperation(cmbOpRot, txtParamsRot);
        private void btnApplySurf_Click(object sender, EventArgs e) => ApplyOperation(cmbOpSurf, txtParamsSurf);

        // =========================================================================
        // ОБЩИЕ ОБРАБОТЧИКИ ИНТЕРФЕЙСА
        // =========================================================================

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabSurface)
            {
                btnBuildSurface_Click(null, null);
            }
            else if (tabControl.SelectedTab == tabRotation)
            {
                btnBuildRotation_Click(null, null);
            }
            else
            {
                _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);
                _modelMatrix = Matrix4x4.Identity();
                canvas.Invalidate();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _matrixHistory.Push(_modelMatrix);
            _modelMatrix = Matrix4x4.Identity();
            _renderer.ShowAxisLine = false;
            lblStatus.Text = "Матрица преобразований сброшена к исходной";
            canvas.Invalidate();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_matrixHistory.Count > 0)
            {
                _modelMatrix = _matrixHistory.Pop();
                lblStatus.Text = "Последнее действие отменено";
                canvas.Invalidate();
            }
            else lblStatus.Text = "Больше нечего отменять";
        }

        private void rbProjection_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.PerspectiveMode = rbPerspective.Checked;
            lblStatus.Text = rbPerspective.Checked ? "Включена перспективная проекция" : "Включена аксонометрическая проекция";
            canvas.Invalidate();
        }

        private void chkEdgesOnly_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.DrawEdgesOnly = chkEdgesOnly.Checked;
            lblStatus.Text = chkEdgesOnly.Checked ? "Режим каркаса" : "Режим заливки";
            canvas.Invalidate();
        }

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