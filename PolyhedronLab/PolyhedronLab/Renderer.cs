using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PolyhedronLab
{
    public class Light
    {
        public Point3D Position = new Point3D(5, 5, 5);
        public Color Color = Color.White;
        public double Intensity = 1.0;
    }

    public class Renderer
    {
        public double RotX { get; set; } = 25;
        public double RotY { get; set; } = -35;
        public bool PerspectiveMode { get; set; } = false;

        public Color ObjectColor { get; set; } = Color.SteelBlue;
        public Light Light { get; set; } = new Light();

        private Matrix4x4 ViewMatrix() => Matrix4x4.RotateX(RotX) * Matrix4x4.RotateY(RotY);

        public void Draw(Graphics g, Polyhedron poly, int cx, int cy)
        {
            if (poly == null || poly.Vertices.Count == 0) return;
            var view = ViewMatrix();
            double baseScale = 100.0, cameraDist = 15.0;
            DrawAxes(g, cx, cy, view, Math.Min(cx, cy) * 0.8);

            var projected = new PointF[poly.Vertices.Count];
            var viewCoords = new Point3D[poly.Vertices.Count];
            var depths = new double[poly.Vertices.Count];
            var worldCoords = new Point3D[poly.Vertices.Count];

            for (int i = 0; i < poly.Vertices.Count; i++)
            {
                var world = poly.Vertices[i];
                worldCoords[i] = world;
                var v = world.Apply(view);
                viewCoords[i] = v;
                if (PerspectiveMode)
                {
                    double zDist = cameraDist - v.Z; if (zDist < 0.1) zDist = 0.1;
                    double pScale = cameraDist / zDist;
                    projected[i] = new PointF((float)(cx + v.X * pScale * baseScale), (float)(cy - v.Y * pScale * baseScale));
                    depths[i] = zDist;
                }
                else
                {
                    projected[i] = new PointF((float)(cx + v.X * baseScale), (float)(cy - v.Y * baseScale));
                    depths[i] = v.Z;
                }
            }

            // Нормали вершин (в мировых координатах).
            var vertexNormals = poly.ComputeVertexNormals();

            var visibleFaces = new List<(Face face, double avg)>();
            foreach (var face in poly.Faces)
            {
                if (face.Indices.Count < 3) continue;
                var p0 = viewCoords[face.Indices[0]];
                var p1 = viewCoords[face.Indices[1]];
                var p2 = viewCoords[face.Indices[2]];
                var n = Point3D.Cross(p1 - p0, p2 - p0).Normalized();
                if (Point3D.Dot(n, new Point3D(0, 0, -1)) > 0) continue;

                double sum = 0;
                foreach (var idx in face.Indices) sum += depths[idx];
                visibleFaces.Add((face, sum / face.Indices.Count));
            }
            visibleFaces.Sort((a, b) => a.avg.CompareTo(b.avg));

            foreach (var (face, _) in visibleFaces)
            {
                // --- Шейдинг Гуро ---
                var pts = new PointF[face.Indices.Count];
                var colors = new Color[face.Indices.Count];
                for (int i = 0; i < face.Indices.Count; i++)
                {
                    int vi = face.Indices[i];
                    pts[i] = projected[vi];
                    colors[i] = ShadeLambert(worldCoords[vi], vertexNormals[vi]);
                }
                FillPolygonGouraud(g, pts, colors);
                using (var pen = new Pen(Color.FromArgb(60, 0, 0, 60), 1f))
                    g.DrawPolygon(pen, pts);
            }
        }

        private Color ShadeLambert(Point3D point, Point3D normal)
        {
            // Модель Ламберта: диффузное отражение.
            var L = (Light.Position - point).Normalized();
            var N = normal.Normalized();
            double diff = Math.Max(0.0, Point3D.Dot(N, L));
            double ambient = 0.2;
            double k = ambient + diff * Light.Intensity * 0.8;

            int r = (int)Math.Min(255, ObjectColor.R * Light.Color.R / 255.0 * k);
            int gg = (int)Math.Min(255, ObjectColor.G * Light.Color.G / 255.0 * k);
            int b = (int)Math.Min(255, ObjectColor.B * Light.Color.B / 255.0 * k);
            return Color.FromArgb(255, r, gg, b);
        }

        /// <summary>
        /// Заливка полигона методом Гуро: билинейная интерполяция цвета между вершинами.
        /// </summary>
        private void FillPolygonGouraud(Graphics g, PointF[] pts, Color[] colors)
        {
            if (pts.Length < 3) return;
            using (var bmp = new Bitmap((int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height))
            {
                // Для скорости используем GraphicsPath и градиент — но в общем случае
                // нужно попиксельно интерполировать. Для задачи достаточно разбить
                // полигон на треугольники и залить каждый по Гуро.
                for (int i = 1; i < pts.Length - 1; i++)
                {
                    FillTriangleGouraud(g, pts[0], pts[i], pts[i + 1],
                        colors[0], colors[i], colors[i + 1]);
                }
            }
        }

        private void FillTriangleGouraud(Graphics g, PointF a, PointF b, PointF c,
            Color ca, Color cb, Color cc)
        {
            // Растеризация с интерполяцией цвета по барицентрическим координатам.
            int minX = (int)Math.Min(a.X, Math.Min(b.X, c.X));
            int maxX = (int)Math.Max(a.X, Math.Max(b.X, c.X));
            int minY = (int)Math.Min(a.Y, Math.Min(b.Y, c.Y));
            int maxY = (int)Math.Max(a.Y, Math.Max(b.Y, c.Y));

            float d = (b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y);
            if (Math.Abs(d) < 1e-5f) return;

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    float w0 = ((b.Y - c.Y) * (x - c.X) + (c.X - b.X) * (y - c.Y)) / d;
                    float w1 = ((c.Y - a.Y) * (x - c.X) + (a.X - c.X) * (y - c.Y)) / d;
                    float w2 = 1 - w0 - w1;
                    if (w0 < 0 || w1 < 0 || w2 < 0) continue;

                    int r = (int)(w0 * ca.R + w1 * cb.R + w2 * cc.R);
                    int gg = (int)(w0 * ca.G + w1 * cb.G + w2 * cc.G);
                    int bb = (int)(w0 * ca.B + w1 * cb.B + w2 * cc.B);
                    using (var brush = new SolidBrush(Color.FromArgb(255, r, gg, bb)))
                        g.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }

        private void DrawAxes(Graphics g, int cx, int cy, Matrix4x4 view, double len)
        {
            PointF Proj(Point3D p)
            {
                var v = p.Apply(view);
                double sx = cx + v.X, sy = cy - v.Y;
                double dx = sx - cx, dy = sy - cy, l = Math.Sqrt(dx * dx + dy * dy);
                if (l > 0) { sx = cx + dx / l * len; sy = cy + dy / l * len; }
                return new PointF((float)sx, (float)sy);
            }
            var p0 = new PointF(cx, cy);
            var px = Proj(new Point3D(1, 0, 0));
            var py = Proj(new Point3D(0, 1, 0));
            var pz = Proj(new Point3D(0, 0, 1));
            using (var pen = new Pen(Color.Red, 3f)) { g.DrawLine(pen, p0, px); g.DrawString("X", SystemFonts.DefaultFont, Brushes.Red, px.X + 5, px.Y); }
            using (var pen = new Pen(Color.Green, 3f)) { g.DrawLine(pen, p0, py); g.DrawString("Y", SystemFonts.DefaultFont, Brushes.Green, py.X + 5, py.Y); }
            using (var pen = new Pen(Color.Blue, 3f)) { g.DrawLine(pen, p0, pz); g.DrawString("Z", SystemFonts.DefaultFont, Brushes.Blue, pz.X + 5, pz.Y); }
        }
    }
}