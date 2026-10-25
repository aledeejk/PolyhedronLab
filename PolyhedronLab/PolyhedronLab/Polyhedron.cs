using System.Collections.Generic;

namespace PolyhedronLab
{
    public class Polyhedron
    {
        public List<Point3D> Vertices { get; } = new List<Point3D>();
        public List<Face> Faces { get; } = new List<Face>();

        public Point3D Center
        {
            get
            {
                if (Vertices.Count == 0) return new Point3D(0, 0, 0);
                double x = 0, y = 0, z = 0;
                foreach (var v in Vertices) { x += v.X; y += v.Y; z += v.Z; }
                return new Point3D(x / Vertices.Count, y / Vertices.Count, z / Vertices.Count);
            }
        }

        public double MaxRadius
        {
            get
            {
                if (Vertices.Count == 0) return 1;
                var c = Center;
                double r = 0;
                foreach (var v in Vertices)
                {
                    double d = (v - c).Length;
                    if (d > r) r = d;
                }
                return r < 1e-9 ? 1 : r;
            }
        }

        public Polyhedron Transformed(Matrix4x4 m)
        {
            var copy = new Polyhedron();
            foreach (var v in Vertices) copy.Vertices.Add(v.Apply(m));
            foreach (var f in Faces) copy.Faces.Add(new Face(f.Indices));
            return copy;
        }
    }
}