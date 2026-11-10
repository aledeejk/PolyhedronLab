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
        public bool CullBackFaces { get; set; } = true;

        public bool ShowAxisLine { get; set; } = false;
        public Point3D AxisPoint1 { get; set; }
        public Point3D AxisPoint2 { get; set; }

        private Matrix4x4 ViewMatrix() => Matrix4x4.RotateX(RotX) * Matrix4x4.RotateY(RotY);

        // =========================================================================
        // ДЕЕВА АЛЕКСАНДРА
        // ЛАБ6: Отображение многогранников, Отражение (в матрицах).
        // ЛАБ7: Загрузка/Сохранение (в ObjParser).
        // ЛАБ8: Отсечение нелицевых граней (DrawCulled), Вектор обзора.
        // =========================================================================

        public void DrawCulled(Graphics g, Polyhedron poly, int cx, int cy, Point3D viewVector)
        {
            if (poly == null || poly.Vertices.Count == 0) return;

            var view = ViewMatrix();
            double baseScale = 100.0;
            double cameraDist = 15.0;

            DrawAxes(g, cx, cy, view, Math.Min(cx, cy) * 0.8);

            var projected = new PointF[poly.Vertices.Count];
            var viewCoords = new Point3D[poly.Vertices.Count];
            var depths = new double[poly.Vertices.Count];

            for (int i = 0; i < poly.Vertices.Count; i++)
            {
                var v = poly.Vertices[i].Apply(view);
                viewCoords[i] = v;

                if (PerspectiveMode)
                {
                    double zDist = cameraDist - v.Z;
                    if (zDist < 0.1) zDist = 0.1;
                    double pScale = cameraDist / zDist;
                    projected[i] = new PointF((float)(cx + (v.X * pScale) * baseScale), (float)(cy - (v.Y * pScale) * baseScale));
                    depths[i] = zDist;
                }
                else
                {
                    projected[i] = new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                    depths[i] = v.Z;
                }
            }

            var facesToDraw = new List<(Face face, double avgDepth)>();

            foreach (var face in poly.Faces)
            {
                if (face.Indices.Count < 3) continue;

                var p0 = viewCoords[face.Indices[0]];
                var p1 = viewCoords[face.Indices[1]];
                var p2 = viewCoords[face.Indices[2]];
                var normal = Point3D.Cross(p1 - p0, p2 - p0).Normalized();

                if (Point3D.Dot(normal, viewVector) > 0) continue;

                double depthSum = 0;
                foreach (var idx in face.Indices) depthSum += depths[idx];
                facesToDraw.Add((face, depthSum / face.Indices.Count));
            }

            facesToDraw.Sort((a, b) => a.avgDepth.CompareTo(b.avgDepth));

            foreach (var (face, _) in facesToDraw)
            {
                var pts = new PointF[face.Indices.Count];
                for (int i = 0; i < face.Indices.Count; i++)
                    pts[i] = projected[face.Indices[i]];

                if (!DrawEdgesOnly)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(200, Color.SteelBlue)))
                        g.FillPolygon(brush, pts);
                }
                using (var pen = new Pen(Color.DarkBlue, 1.0f))
                    g.DrawPolygon(pen, pts);
            }
        }

        // =========================================================================
        // БОЧАРОВА КАТЕРИНА
        // ЛАБ6: Смещение, Масштаб (обычный и от центра), Повороты осей (в матрицах).
        // ЛАБ7: Построение фигуры вращения (в PolyhedraFactory).
        // ЛАБ8: Алгоритм Z-буфера (DrawTrueZBuffer, RasterizeTriangle).
        // =========================================================================

        public void DrawTrueZBuffer(Graphics g, List<Polyhedron> polys, int cx, int cy, int width, int height)
        {
            double[] zBuffer = new double[width * height];
            Color[] colorBuffer = new Color[width * height];

            for (int i = 0; i < zBuffer.Length; i++) zBuffer[i] = double.MaxValue;

            var view = ViewMatrix();
            double baseScale = 100.0;
            double cameraDist = 15.0;

            Color[] colors = { Color.SteelBlue, Color.LightGreen, Color.Orange, Color.Pink };

            var faceContours = new List<(PointF[] pts, double[] depths, Color color)>();

            for (int pIndex = 0; pIndex < polys.Count; pIndex++)
            {
                var poly = polys[pIndex];
                Color objectColor = colors[pIndex % colors.Length];

                var projected = new PointF[poly.Vertices.Count];
                var viewCoords = new Point3D[poly.Vertices.Count];
                var depths = new double[poly.Vertices.Count];

                for (int i = 0; i < poly.Vertices.Count; i++)
                {
                    var v = poly.Vertices[i].Apply(view);
                    viewCoords[i] = v;

                    if (PerspectiveMode)
                    {
                        double zDist = cameraDist - v.Z;
                        if (zDist < 0.1) zDist = 0.1;
                        double pScale = cameraDist / zDist;
                        projected[i] = new PointF((float)(cx + (v.X * pScale) * baseScale), (float)(cy - (v.Y * pScale) * baseScale));
                        depths[i] = zDist;
                    }
                    else
                    {
                        projected[i] = new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                        depths[i] = v.Z;
                    }
                }

                foreach (var face in poly.Faces)
                {
                    if (face.Indices.Count < 3) continue;

                    var p0 = viewCoords[face.Indices[0]];
                    var p1 = viewCoords[face.Indices[1]];
                    var p2 = viewCoords[face.Indices[2]];
                    var normal = Point3D.Cross(p1 - p0, p2 - p0).Normalized();
                    if (Point3D.Dot(normal, new Point3D(0, 0, -1)) > 0) continue;

                    var facePts = new PointF[face.Indices.Count];
                    var faceDepths = new double[face.Indices.Count];
                    for (int i = 0; i < face.Indices.Count; i++)
                    {
                        facePts[i] = projected[face.Indices[i]];
                        faceDepths[i] = depths[face.Indices[i]];
                    }
                    faceContours.Add((facePts, faceDepths, objectColor));

                    for (int i = 1; i < face.Indices.Count - 1; i++)
                    {
                        int v1 = face.Indices[0];
                        int v2 = face.Indices[i];
                        int v3 = face.Indices[i + 1];

                        RasterizeTriangle(projected[v1], projected[v2], projected[v3],
                                          depths[v1], depths[v2], depths[v3],
                                          zBuffer, colorBuffer, width, height, objectColor);
                    }
                }
            }

            // Выводим Z-буфер
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (zBuffer[y * width + x] < double.MaxValue)
                    {
                        using (var brush = new SolidBrush(colorBuffer[y * width + x]))
                            g.FillRectangle(brush, x, y, 1, 1);
                    }
                }
            }

            // Рисуем рёбра с проверкой Z
            foreach (var (pts, depthPts, color) in faceContours)
            {
                for (int i = 0; i < pts.Length; i++)
                {
                    int next = (i + 1) % pts.Length;
                    PointF p1 = pts[i];
                    PointF p2 = pts[next];
                    double z1 = depthPts[i];
                    double z2 = depthPts[next];

                    int steps = (int)Math.Max(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
                    if (steps < 1) steps = 1;

                    for (int s = 0; s <= steps; s++)
                    {
                        float t = (float)s / steps;
                        float x = p1.X + (p2.X - p1.X) * t;
                        float y = p1.Y + (p2.Y - p1.Y) * t;
                        int ix = (int)x;
                        int iy = (int)y;

                        if (ix >= 0 && ix < width && iy >= 0 && iy < height)
                        {
                            int index = iy * width + ix;
                            double lineZ = z1 + (z2 - z1) * t;

                            if (lineZ <= zBuffer[index] + 0.1)
                            {
                                using (var brush = new SolidBrush(Color.Black))
                                    g.FillRectangle(brush, ix, iy, 1, 1);
                            }
                        }
                    }
                }
            }
        }

        private void RasterizeTriangle(PointF p1, PointF p2, PointF p3, double z1, double z2, double z3,
                                       double[] zBuffer, Color[] colorBuffer, int width, int height, Color color)
        {
            int minX = (int)Math.Min(p1.X, Math.Min(p2.X, p3.X));
            int maxX = (int)Math.Max(p1.X, Math.Max(p2.X, p3.X));
            int minY = (int)Math.Min(p1.Y, Math.Min(p2.Y, p3.Y));
            int maxY = (int)Math.Max(p1.Y, Math.Max(p2.Y, p3.Y));

            if (minX < 0) minX = 0;
            if (maxX >= width) maxX = width - 1;
            if (minY < 0) minY = 0;
            if (maxY >= height) maxY = height - 1;

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    float denominator = (p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y);
                    if (Math.Abs(denominator) < 0.001f) continue;

                    float a = ((p2.Y - p3.Y) * (x - p3.X) + (p3.X - p2.X) * (y - p3.Y)) / denominator;
                    float b = ((p3.Y - p1.Y) * (x - p3.X) + (p1.X - p3.X) * (y - p3.Y)) / denominator;
                    float c = 1 - a - b;

                    if (a >= 0 && b >= 0 && c >= 0)
                    {
                        double depth = a * z1 + b * z2 + c * z3;
                        int index = y * width + x;
                        if (depth < zBuffer[index])
                        {
                            zBuffer[index] = depth;
                            colorBuffer[index] = color;
                        }
                    }
                }
            }
        }

        // =========================================================================
        // СИДОРЧИК АЛИСА
        // ЛАБ6: Повороты через центр, Поворот вокруг произвольной прямой (в матрицах).
        // ЛАБ7: Построение графика функции (в PolyhedraFactory).
        // ЛАБ8: Камера (DrawCamera).
        // =========================================================================

        public void DrawCamera(Graphics g, Polyhedron poly, int cx, int cy, double angle)
        {
            if (poly == null || poly.Vertices.Count == 0) return;

            double baseScale = 70.0;
            double cameraDist = 15.0;

            var view = Matrix4x4.RotateX(30) * Matrix4x4.RotateY(angle * 180 / Math.PI);
            DrawAxes(g, cx, cy, view, Math.Min(cx, cy) * 0.8);

            var projected = new PointF[poly.Vertices.Count];
            var viewCoords = new Point3D[poly.Vertices.Count];
            var depths = new double[poly.Vertices.Count];

            for (int i = 0; i < poly.Vertices.Count; i++)
            {
                var v = poly.Vertices[i].Apply(view);
                viewCoords[i] = v;

                if (PerspectiveMode)
                {
                    double zDist = cameraDist - v.Z;
                    if (zDist < 0.1) zDist = 0.1;
                    double pScale = cameraDist / zDist;
                    projected[i] = new PointF((float)(cx + (v.X * pScale) * baseScale), (float)(cy - (v.Y * pScale) * baseScale));
                    depths[i] = zDist;
                }
                else
                {
                    projected[i] = new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                    depths[i] = v.Z;
                }
            }

            var facesToDraw = new List<(Face face, double avgDepth)>();

            foreach (var face in poly.Faces)
            {
                if (face.Indices.Count < 3) continue;

                var p0 = viewCoords[face.Indices[0]];
                var p1 = viewCoords[face.Indices[1]];
                var p2 = viewCoords[face.Indices[2]];
                var normal = Point3D.Cross(p1 - p0, p2 - p0).Normalized();

                if (Point3D.Dot(normal, new Point3D(0, 0, -1)) > 0) continue;

                double depthSum = 0;
                foreach (var idx in face.Indices) depthSum += depths[idx];
                facesToDraw.Add((face, depthSum / face.Indices.Count));
            }

            facesToDraw.Sort((a, b) => a.avgDepth.CompareTo(b.avgDepth));

            foreach (var (face, _) in facesToDraw)
            {
                var pts = new PointF[face.Indices.Count];
                for (int i = 0; i < face.Indices.Count; i++)
                    pts[i] = projected[face.Indices[i]];

                if (!DrawEdgesOnly)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(200, Color.SteelBlue)))
                        g.FillPolygon(brush, pts);
                }
                using (var pen = new Pen(Color.DarkBlue, 1.0f))
                    g.DrawPolygon(pen, pts);
            }
        }

        // =========================================================================
        // ОБЩИЙ БЛОК
        // Отрисовка (ЛР6/7), Оси, Поворот произвольной прямой (ShowAxisLine).
        // =========================================================================

        public void Draw(Graphics g, Polyhedron poly, int cx, int cy)
        {
            if (poly == null || poly.Vertices.Count == 0) return;

            var view = ViewMatrix();
            double baseScale = 100.0;
            double cameraDist = 15.0;

            DrawAxes(g, cx, cy, view, Math.Min(cx, cy) * 0.8);

            var projected = new PointF[poly.Vertices.Count];
            var viewCoords = new Point3D[poly.Vertices.Count];
            var depths = new double[poly.Vertices.Count];

            for (int i = 0; i < poly.Vertices.Count; i++)
            {
                var v = poly.Vertices[i].Apply(view);
                viewCoords[i] = v;

                if (PerspectiveMode)
                {
                    double zDist = cameraDist - v.Z;
                    if (zDist < 0.1) zDist = 0.1;
                    double pScale = cameraDist / zDist;
                    projected[i] = new PointF((float)(cx + (v.X * pScale) * baseScale), (float)(cy - (v.Y * pScale) * baseScale));
                    depths[i] = zDist;
                }
                else
                {
                    projected[i] = new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                    depths[i] = v.Z;
                }
            }

            var facesToDraw = new List<(Face face, double avgDepth)>();

            foreach (var face in poly.Faces)
            {
                if (face.Indices.Count < 3) continue;

                if (CullBackFaces)
                {
                    var p0 = viewCoords[face.Indices[0]];
                    var p1 = viewCoords[face.Indices[1]];
                    var p2 = viewCoords[face.Indices[2]];
                    var normal = Point3D.Cross(p1 - p0, p2 - p0).Normalized();
                    if (Point3D.Dot(normal, new Point3D(0, 0, -1)) > 0) continue;
                }

                double depthSum = 0;
                foreach (var idx in face.Indices) depthSum += depths[idx];
                facesToDraw.Add((face, depthSum / face.Indices.Count));
            }

            facesToDraw.Sort((a, b) => a.avgDepth.CompareTo(b.avgDepth));

            foreach (var (face, _) in facesToDraw)
            {
                var pts = new PointF[face.Indices.Count];
                for (int i = 0; i < face.Indices.Count; i++)
                    pts[i] = projected[face.Indices[i]];

                if (!DrawEdgesOnly)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(200, Color.SteelBlue)))
                        g.FillPolygon(brush, pts);
                }
                using (var pen = new Pen(Color.DarkBlue, 1.0f))
                    g.DrawPolygon(pen, pts);
            }

            if (ShowAxisLine)
            {
                var dir = (AxisPoint2 - AxisPoint1).Normalized();
                var p1 = AxisPoint1 - dir * 5.0;
                var p2 = AxisPoint2 + dir * 5.0;

                PointF ProjectPoint(Point3D p)
                {
                    var v = p.Apply(view);
                    if (PerspectiveMode)
                    {
                        double zDist = cameraDist - v.Z;
                        if (zDist < 0.1) zDist = 0.1;
                        double pScale = cameraDist / zDist;
                        return new PointF((float)(cx + (v.X * pScale) * baseScale), (float)(cy - (v.Y * pScale) * baseScale));
                    }
                    else
                    {
                        return new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                    }
                }

                using (var pen = new Pen(Color.Magenta, 2f))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(pen, ProjectPoint(p1), ProjectPoint(p2));
                }
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