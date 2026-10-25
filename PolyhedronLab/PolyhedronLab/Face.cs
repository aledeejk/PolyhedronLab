using System.Collections.Generic;

namespace PolyhedronLab
{
    public class Face
    {
        public List<int> Indices { get; } = new List<int>();

        public Face() { }
        public Face(IEnumerable<int> idx) { Indices.AddRange(idx); }

        public Point3D ComputeCenter(IReadOnlyList<Point3D> vertices)
        {
            double x = 0, y = 0, z = 0;
            foreach (var i in Indices)
            {
                x += vertices[i].X; y += vertices[i].Y; z += vertices[i].Z;
            }
            int n = Indices.Count;
            return new Point3D(x / n, y / n, z / n);
        }
    }
}