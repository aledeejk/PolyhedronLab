using System;
using System.Drawing;
using System.Collections.Generic;

namespace PolyhedronLab
{
    public class Renderer
    {
        public double RotX { get; set; } = 25;
        public double RotY { get; set; } = -35;
        public bool PerspectiveMode { get; set; } = false;
        public bool DrawEdgesOnly { get; set; } = false;

        public bool ShowAxisLine { get; set; } = false;
        public Point3D AxisPoint1 { get; set; }
        public Point3D AxisPoint2 { get; set; }

        private Matrix4x4 ViewMatrix()
        {
            return Matrix4x4.RotateX(RotX) * Matrix4x4.RotateY(RotY);
        }

        public void Draw(Graphics g, Polyhedron poly, int cx, int cy)
        {
            if (poly == null || poly.Vertices.Count == 0) return;

            var view = ViewMatrix();
            double baseScale = 60.0;
            double cameraDist = 15.0;

            // 1. Рисуем координатные оси (они всегда на фоне)
            DrawAxes(g, cx, cy, view, Math.Min(cx, cy) * 0.8);

            // 2. Готовим список для сортировки (сюда попадут и грани куба, и кусочки линии)
            var renderQueue = new List<(Action<Graphics> drawAction, double depth)>();

            // --- Подготовка граней куба ---
            var projected = new PointF[poly.Vertices.Count];
            var vertexDepths = new double[poly.Vertices.Count];

            for (int i = 0; i < poly.Vertices.Count; i++)
            {
                var v = poly.Vertices[i].Apply(view);

                if (PerspectiveMode)
                {
                    double zDist = v.Z + cameraDist;
                    if (zDist < 0.1) zDist = 0.1;
                    double perspectiveScale = cameraDist / zDist;
                    double sx = cx + (v.X * perspectiveScale) * baseScale;
                    double sy = cy - (v.Y * perspectiveScale) * baseScale;
                    projected[i] = new PointF((float)sx, (float)sy);
                    vertexDepths[i] = zDist;
                }
                else
                {
                    double sx = cx + v.X * baseScale;
                    double sy = cy - v.Y * baseScale;
                    projected[i] = new PointF((float)sx, (float)sy);
                    vertexDepths[i] = v.Z;
                }
            }

            foreach (var face in poly.Faces)
            {
                if (face.Indices.Count < 3) continue;
                double depthSum = 0;
                foreach (var idx in face.Indices) depthSum += vertexDepths[idx];
                double avgDepth = depthSum / face.Indices.Count;

                var pts = new PointF[face.Indices.Count];
                for (int i = 0; i < face.Indices.Count; i++)
                    pts[i] = projected[face.Indices[i]];

                // Добавляем грань в очередь отрисовки
                renderQueue.Add((
                    (gfx) =>
                    {
                        if (!DrawEdgesOnly)
                        {
                            using (var brush = new SolidBrush(Color.FromArgb(200, Color.SteelBlue)))
                                gfx.FillPolygon(brush, pts);
                        }
                        using (var pen = new Pen(Color.DarkBlue, 1.5f))
                            gfx.DrawPolygon(pen, pts);
                    },
                    avgDepth
                ));
            }

            // --- Подготовка линии (разбиваем на 20 сегментов) ---
            if (ShowAxisLine)
            {
                var dir = (AxisPoint2 - AxisPoint1).Normalized();
                var p1 = AxisPoint1 - dir * 10.0;
                var p2 = AxisPoint2 + dir * 10.0;

                int segments = 20;
                for (int s = 0; s < segments; s++)
                {
                    var startT = (double)s / segments;
                    var endT = (double)(s + 1) / segments;

                    var startPoint = p1 + (p2 - p1) * startT;
                    var endPoint = p1 + (p2 - p1) * endT;

                    var midPoint = (startPoint + endPoint) * 0.5;

                    var vMid = midPoint.Apply(view);
                    double depth = PerspectiveMode ? (vMid.Z + cameraDist) : vMid.Z;

                    PointF screenStart = ProjectPoint(startPoint, view, cx, cy, baseScale, cameraDist);
                    PointF screenEnd = ProjectPoint(endPoint, view, cx, cy, baseScale, cameraDist);

                    // Добавляем кусочек линии в очередь
                    renderQueue.Add((
                        (gfx) =>
                        {
                            using (var pen = new Pen(Color.Magenta, 2f))
                            {
                                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                gfx.DrawLine(pen, screenStart, screenEnd);
                            }
                        },
                        depth
                    ));
                }
            }

            // 3. СОРТИРУЕМ ВСЕ (и грани, и линию) ПО ГЛУБИНЕ (от дальних к ближним)
            renderQueue.Sort((a, b) => a.depth.CompareTo(b.depth));

            // 4. Рисуем всё в правильном порядке
            foreach (var item in renderQueue)
            {
                item.drawAction(g);
            }
        }

        private PointF ProjectPoint(Point3D p, Matrix4x4 view, int cx, int cy, double baseScale, double cameraDist)
        {
            var v = p.Apply(view);
            if (PerspectiveMode)
            {
                double zDist = v.Z + cameraDist;
                if (zDist < 0.1) zDist = 0.1;
                double perspectiveScale = cameraDist / zDist;
                return new PointF(
                    (float)(cx + (v.X * perspectiveScale) * baseScale),
                    (float)(cy - (v.Y * perspectiveScale) * baseScale));
            }
            else
            {
                return new PointF(
                    (float)(cx + v.X * baseScale),
                    (float)(cy - v.Y * baseScale));
            }
        }

        private void DrawAxes(Graphics g, int cx, int cy, Matrix4x4 view, double maxPixelLength)
        {
            var axisX = new Point3D(1, 0, 0);
            var axisY = new Point3D(0, 1, 0);
            var axisZ = new Point3D(0, 0, 1);

            PointF ProjectAxis(Point3D p)
            {
                var v = p.Apply(view);
                double sx = cx + v.X;
                double sy = cy - v.Y;
                double dx = sx - cx;
                double dy = sy - cy;
                double len = Math.Sqrt(dx * dx + dy * dy);
                if (len > 0)
                {
                    sx = cx + (dx / len) * maxPixelLength;
                    sy = cy + (dy / len) * maxPixelLength;
                }
                return new PointF((float)sx, (float)sy);
            }

            PointF p0 = new PointF(cx, cy);
            PointF px = ProjectAxis(axisX);
            PointF py = ProjectAxis(axisY);
            PointF pz = ProjectAxis(axisZ);

            using (var pen = new Pen(Color.Red, 3f)) { g.DrawLine(pen, p0, px); g.DrawString("X", SystemFonts.DefaultFont, Brushes.Red, px.X + 5, px.Y); }
            using (var pen = new Pen(Color.Green, 3f)) { g.DrawLine(pen, p0, py); g.DrawString("Y", SystemFonts.DefaultFont, Brushes.Green, py.X + 5, py.Y); }
            using (var pen = new Pen(Color.Blue, 3f)) { g.DrawLine(pen, p0, pz); g.DrawString("Z", SystemFonts.DefaultFont, Brushes.Blue, pz.X + 5, pz.Y); }
        }
    }
}