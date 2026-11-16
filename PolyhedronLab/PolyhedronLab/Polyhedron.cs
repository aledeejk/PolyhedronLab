using System.Collections.Generic;
using System.Linq;

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

        public Polyhedron Transformed(Matrix4x4 m)
        {
            var copy = new Polyhedron();
            foreach (var v in Vertices) copy.Vertices.Add(v.Apply(m));
            foreach (var f in Faces) copy.Faces.Add(new Face(f.Indices));
            return copy;
        }

        /// <summary>
        /// Возвращает нормаль к каждой вершине: усреднение нормалей смежных граней.
        /// </summary>
        public List<Point3D> ComputeVertexNormals()
        {
            var normals = new List<Point3D>(new Point3D[Vertices.Count]);
            foreach (var face in Faces)
            {
                if (face.Indices.Count < 3) continue;
                var p0 = Vertices[face.Indices[0]];
                var p1 = Vertices[face.Indices[1]];
                var p2 = Vertices[face.Indices[2]];
                var fn = Point3D.Cross(p1 - p0, p2 - p0).Normalized();
                foreach (var idx in face.Indices)
                    normals[idx] = normals[idx] + fn;
            }
            for (int i = 0; i < normals.Count; i++)
                normals[i] = normals[i].Normalized();
            return normals;
        }
    }
}