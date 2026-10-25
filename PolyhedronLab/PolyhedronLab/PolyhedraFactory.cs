using System;

namespace PolyhedronLab
{
    public static class PolyhedraFactory
    {
        public static Polyhedron Tetrahedron()
        {
            var p = new Polyhedron();
            p.Vertices.AddRange(new[]
            {
                new Point3D( 1,  1,  1), new Point3D( 1, -1, -1),
                new Point3D(-1,  1, -1), new Point3D(-1, -1,  1),
            });
            p.Faces.AddRange(new[]
            {
                new Face(new[]{0,1,2}), new Face(new[]{0,3,1}),
                new Face(new[]{0,2,3}), new Face(new[]{1,3,2}),
            });
            return p;
        }

        public static Polyhedron Hexahedron()
        {
            var p = new Polyhedron();
            p.Vertices.AddRange(new[]
            {
                new Point3D(-1, -1, -1), new Point3D( 1, -1, -1),
                new Point3D( 1,  1, -1), new Point3D(-1,  1, -1),
                new Point3D(-1, -1,  1), new Point3D( 1, -1,  1),
                new Point3D( 1,  1,  1), new Point3D(-1,  1,  1),
            });
            p.Faces.AddRange(new[]
            {
                new Face(new[]{0,3,2,1}), new Face(new[]{4,5,6,7}),
                new Face(new[]{0,1,5,4}), new Face(new[]{2,3,7,6}),
                new Face(new[]{1,2,6,5}), new Face(new[]{0,4,7,3}),
            });
            return p;
        }

        public static Polyhedron Octahedron()
        {
            var p = new Polyhedron();
            p.Vertices.AddRange(new[]
            {
                new Point3D( 1,  0,  0), new Point3D(-1,  0,  0),
                new Point3D( 0,  1,  0), new Point3D( 0, -1,  0),
                new Point3D( 0,  0,  1), new Point3D( 0,  0, -1),
            });
            int[,] f = {
                {0,2,4},{2,1,4},{1,3,4},{3,0,4},
                {2,0,5},{1,2,5},{3,1,5},{0,3,5}
            };
            for (int i = 0; i < 8; i++)
                p.Faces.Add(new Face(new[] { f[i, 0], f[i, 1], f[i, 2] }));
            return p;
        }

        public static Polyhedron Icosahedron()
        {
            var p = new Polyhedron();
            double phi = (1 + Math.Sqrt(5)) / 2;
            p.Vertices.AddRange(new[]
            {
                new Point3D(-1,  phi, 0), new Point3D( 1,  phi, 0),
                new Point3D(-1, -phi, 0), new Point3D( 1, -phi, 0),
                new Point3D( 0, -1,  phi), new Point3D( 0,  1,  phi),
                new Point3D( 0, -1, -phi), new Point3D( 0,  1, -phi),
                new Point3D( phi, 0, -1), new Point3D( phi, 0,  1),
                new Point3D(-phi, 0, -1), new Point3D(-phi, 0,  1),
            });
            int[,] f = {
                {0,11,5},{0,5,1},{0,1,7},{0,7,10},{0,10,11},
                {1,5,9},{5,11,4},{11,10,2},{10,7,6},{7,1,8},
                {3,9,4},{3,4,2},{3,2,6},{3,6,8},{3,8,9},
                {4,9,5},{2,4,11},{6,2,10},{8,6,7},{9,8,1}
            };
            for (int i = 0; i < 20; i++)
                p.Faces.Add(new Face(new[] { f[i, 0], f[i, 1], f[i, 2] }));
            return p;
        }

        public static Polyhedron Dodecahedron()
        {
            var p = new Polyhedron();
            double phi = (1 + Math.Sqrt(5)) / 2;

            // 1. Вершины икосаэдра
            var icoVerts = new[]
            {
        new Point3D(-1,  phi, 0), new Point3D( 1,  phi, 0),
        new Point3D(-1, -phi, 0), new Point3D( 1, -phi, 0),
        new Point3D( 0, -1,  phi), new Point3D( 0,  1,  phi),
        new Point3D( 0, -1, -phi), new Point3D( 0,  1, -phi),
        new Point3D( phi, 0, -1), new Point3D( phi, 0,  1),
        new Point3D(-phi, 0, -1), new Point3D(-phi, 0,  1),
    };

            // 2. Грани икосаэдра
            int[][] icoFaces = {
        new[]{0,11,5}, new[]{0,5,1}, new[]{0,1,7}, new[]{0,7,10}, new[]{0,10,11},
        new[]{1,5,9}, new[]{5,11,4}, new[]{11,10,2}, new[]{10,7,6}, new[]{7,1,8},
        new[]{3,9,4}, new[]{3,4,2}, new[]{3,2,6}, new[]{3,6,8}, new[]{3,8,9},
        new[]{4,9,5}, new[]{2,4,11}, new[]{6,2,10}, new[]{8,6,7}, new[]{9,8,1}
    };

            // 3. Вершины додекаэдра — центры граней икосаэдра
            for (int i = 0; i < icoFaces.Length; i++)
            {
                var v1 = icoVerts[icoFaces[i][0]];
                var v2 = icoVerts[icoFaces[i][1]];
                var v3 = icoVerts[icoFaces[i][2]];
                var center = new Point3D((v1.X + v2.X + v3.X) / 3.0, (v1.Y + v2.Y + v3.Y) / 3.0, (v1.Z + v2.Z + v3.Z) / 3.0);
                p.Vertices.Add(center.Normalized());
            }

            // 4. Грани додекаэдра (собираются вокруг вершин икосаэдра)
            for (int i = 0; i < 12; i++)
            {
                // Собираем все центры граней, которые содержат вершину i
                var faceIndices = new System.Collections.Generic.List<int>();
                for (int f = 0; f < icoFaces.Length; f++)
                {
                    if (icoFaces[f][0] == i || icoFaces[f][1] == i || icoFaces[f][2] == i)
                        faceIndices.Add(f);
                }

                // Сортируем вершины по кругу, чтобы контур не пересекался
                var centerOfFace = new Point3D(0, 0, 0);
                foreach (var idx in faceIndices) centerOfFace += p.Vertices[idx];
                centerOfFace = centerOfFace * (1.0 / faceIndices.Count);

                var axis = icoVerts[i].Normalized();

                var u = Point3D.Cross(axis, new Point3D(0, 1, 0));
                if (u.Length < 0.1) u = Point3D.Cross(axis, new Point3D(1, 0, 0));
                u = u.Normalized();
                var v = Point3D.Cross(axis, u).Normalized();

                var sorted = System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.OrderBy(faceIndices, idx =>
                    {
                        var dir = p.Vertices[idx] - centerOfFace;
                        double x = Point3D.Dot(dir, u);
                        double y = Point3D.Dot(dir, v);
                        return Math.Atan2(y, x); // Сортировка по углу
                    }));

                p.Faces.Add(new Face(sorted));
            }

            return p;
        }

        public static Polyhedron Create(int index)
        {
            switch (index)
            {
                case 0: return Tetrahedron();
                case 1: return Hexahedron();
                case 2: return Octahedron();
                case 3: return Icosahedron();
                case 4: return Dodecahedron();
                default: return Hexahedron();
            }
        }
    }
}