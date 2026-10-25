using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
            lblStatus.Text = $"Загружен: {cmbShape.Text}. Проекция: Аксонометрическая.";
        }

        private void canvas_Resize(object sender, EventArgs e) => canvas.Invalidate();

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_poly == null || _poly.Vertices.Count == 0) return;
            if (canvas.Width == 0 || canvas.Height == 0) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Применяем накопленную матрицу к фигуре
            var display = _poly.Transformed(_modelMatrix);
            int cx = canvas.Width / 2;
            int cy = canvas.Height / 2;

            _renderer.Draw(e.Graphics, display, cx, cy);
        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Создаем новую фигуру
            _poly = PolyhedraFactory.Create(cmbShape.SelectedIndex);

            // ВАЖНО: Мы НИЧЕГО НЕ ДЕЛАЕМ с _renderer.ShowAxisLine и координатами линии.
            // Линия остается там, где была, и не исчезает!

            lblStatus.Text = $"Загружен многогранник: {cmbShape.Text}";
            canvas.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _matrixHistory.Push(_modelMatrix);
            _modelMatrix = Matrix4x4.Identity();
            _renderer.ShowAxisLine = false; // При сбросе линию скрываем
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
            if (_renderer == null) return;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Matrix4x4 op = Matrix4x4.Identity();
                bool applyLocally = false;

                // Если мы выбрали НЕ 9-й пункт (произвольную прямую), скрываем линию
                if (cmbOp.SelectedIndex != 9)
                {
                    _renderer.ShowAxisLine = false;
                }

                if (cmbOp.SelectedIndex == 10) // Отражение
                {
                    var s = txtParams.Text.Trim().ToUpper();
                    if (s.Length != 1 || "XYZ".IndexOf(s[0]) < 0)
                        throw new ArgumentException("Укажите X, Y или Z");
                    op = Matrix4x4.ReflectPlane(s[0]);
                }
                else
                {
                    var p = ParseParams();
                    switch (cmbOp.SelectedIndex)
                    {
                        case 0: // Смещение
                            Require(p, 3);
                            op = Matrix4x4.Translate(p[0], p[1], p[2]);
                            break;
                        case 1: // Обычный масштаб
                            Require(p, 3);
                            if (p[0] == 0 || p[1] == 0 || p[2] == 0) throw new Exception("Масштаб не может быть 0.");
                            op = Matrix4x4.Scale(p[0], p[1], p[2]);
                            break;
                        case 2: // Масштаб отн. центра
                            Require(p, 1);
                            if (p[0] == 0) throw new Exception("Масштаб не может быть 0.");
                            op = Matrix4x4.ScaleAboutCenter(_poly.Center, p[0]);
                            applyLocally = true;
                            break;
                        case 3: Require(p, 1); op = Matrix4x4.RotateX(p[0]); break;
                        case 4: Require(p, 1); op = Matrix4x4.RotateY(p[0]); break;
                        case 5: Require(p, 1); op = Matrix4x4.RotateZ(p[0]); break;
                        case 6: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(-1, 0, 0), _poly.Center + new Point3D(1, 0, 0), p[0]); applyLocally = true; break;
                        case 7: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(0, -1, 0), _poly.Center + new Point3D(0, 1, 0), p[0]); applyLocally = true; break;
                        case 8: Require(p, 1); op = Matrix4x4.RotateAroundLine(_poly.Center + new Point3D(0, 0, -1), _poly.Center + new Point3D(0, 0, 1), p[0]); applyLocally = true; break;

                        case 9: // Произвольная прямая
                            Require(p, 7);
                            _renderer.ShowAxisLine = true;

                            // Задаем НОВЫЕ координаты линии
                            _renderer.AxisPoint1 = new Point3D(p[0], p[1], p[2]);
                            _renderer.AxisPoint2 = new Point3D(p[3], p[4], p[5]);

                            op = Matrix4x4.RotateAroundLine(_renderer.AxisPoint1, _renderer.AxisPoint2, p[6]);
                            break;
                    }
                }

                _matrixHistory.Push(_modelMatrix);

                if (applyLocally)
                    _modelMatrix = _modelMatrix * op;
                else
                    _modelMatrix = op * _modelMatrix;

                // ВАЖНО: Если мы двигаем/поворачиваем фигуру, линия тоже должна ехать вместе с ней.
                // Но только если это не 9-й пункт (иначе мы её только что задали).
                if (_renderer.ShowAxisLine && cmbOp.SelectedIndex != 9)
                {
                    _renderer.AxisPoint1 = _renderer.AxisPoint1.Apply(_modelMatrix);
                    _renderer.AxisPoint2 = _renderer.AxisPoint2.Apply(_modelMatrix);
                }

                lblStatus.Text = $"Применено: {cmbOp.Text} (Параметры: {txtParams.Text})";
                canvas.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double[] ParseParams()
        {
            string text = txtParams.Text.Trim();
            if (text.Length == 0) return new double[0];
            var parts = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                string t = parts[i].Trim();
                if (!double.TryParse(t, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out res[i]) &&
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