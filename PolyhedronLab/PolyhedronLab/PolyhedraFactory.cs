using System;
using System.Collections.Generic;
using System.Linq;

namespace PolyhedronLab
{
    public static class PolyhedraFactory
    {
        // ==========================================================
        // ЛАБ6 - ДЕЕВА АЛЕКСАНДРА (Правильные многогранники)
        // ==========================================================
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

            var icoVerts = new[]
            {
                new Point3D(-1,  phi, 0), new Point3D( 1,  phi, 0),
                new Point3D(-1, -phi, 0), new Point3D( 1, -phi, 0),
                new Point3D( 0, -1,  phi), new Point3D( 0,  1,  phi),
                new Point3D( 0, -1, -phi), new Point3D( 0,  1, -phi),
                new Point3D( phi, 0, -1), new Point3D( phi, 0,  1),
                new Point3D(-phi, 0, -1), new Point3D(-phi, 0,  1),
            };

            int[][] icoFaces = {
                new[]{0,11,5}, new[]{0,5,1}, new[]{0,1,7}, new[]{0,7,10}, new[]{0,10,11},
                new[]{1,5,9}, new[]{5,11,4}, new[]{11,10,2}, new[]{10,7,6}, new[]{7,1,8},
                new[]{3,9,4}, new[]{3,4,2}, new[]{3,2,6}, new[]{3,6,8}, new[]{3,8,9},
                new[]{4,9,5}, new[]{2,4,11}, new[]{6,2,10}, new[]{8,6,7}, new[]{9,8,1}
            };

            for (int i = 0; i < icoFaces.Length; i++)
            {
                var v1 = icoVerts[icoFaces[i][0]];
                var v2 = icoVerts[icoFaces[i][1]];
                var v3 = icoVerts[icoFaces[i][2]];
                var center = new Point3D((v1.X + v2.X + v3.X) / 3.0, (v1.Y + v2.Y + v3.Y) / 3.0, (v1.Z + v2.Z + v3.Z) / 3.0);
                p.Vertices.Add(center.Normalized());
            }

            for (int i = 0; i < 12; i++)
            {
                var faceIndices = new List<int>();
                for (int f = 0; f < icoFaces.Length; f++)
                {
                    if (icoFaces[f][0] == i || icoFaces[f][1] == i || icoFaces[f][2] == i)
                        faceIndices.Add(f);
                }

                var centerOfFace = new Point3D(0, 0, 0);
                foreach (var idx in faceIndices) centerOfFace += p.Vertices[idx];
                centerOfFace = centerOfFace * (1.0 / faceIndices.Count);

                var axis = icoVerts[i].Normalized();

                var u = Point3D.Cross(axis, new Point3D(0, 1, 0));
                if (u.Length < 0.1) u = Point3D.Cross(axis, new Point3D(1, 0, 0));
                u = u.Normalized();
                var v = Point3D.Cross(axis, u).Normalized();

                var sorted = Enumerable.ToArray(
                    Enumerable.OrderBy(faceIndices, idx =>
                    {
                        var dir = p.Vertices[idx] - centerOfFace;
                        double x = Point3D.Dot(dir, u);
                        double y = Point3D.Dot(dir, v);
                        return Math.Atan2(y, x);
                    }));

                p.Faces.Add(new Face(sorted));
            }

            return p;
        }

        // ==========================================================
        // ЛАБ7 - БОЧАРОВА КАТЕРИНА (Фигура вращения)
        // ==========================================================
        public static Polyhedron CreateRotationFigure(List<Point3D> generatrix, int axis, int segments)
        {
            var p = new Polyhedron();
            if (generatrix.Count < 2) return p;

            int n = generatrix.Count;
            for (int s = 0; s <= segments; s++)
            {
                double angle = (360.0 / segments) * s * Math.PI / 180.0;
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                foreach (var pt in generatrix)
                {
                    double x = pt.X, y = pt.Y, z = pt.Z;
                    if (axis == 0) // X
                    {
                        double ny = y * cos - z * sin;
                        double nz = y * sin + z * cos;
                        p.Vertices.Add(new Point3D(x, ny, nz));
                    }
                    else if (axis == 1) // Y
                    {
                        double nx = x * cos + z * sin;
                        double nz = -x * sin + z * cos;
                        p.Vertices.Add(new Point3D(nx, y, nz));
                    }
                    else // Z
                    {
                        double nx = x * cos - y * sin;
                        double ny = x * sin + y * cos;
                        p.Vertices.Add(new Point3D(nx, ny, z));
                    }
                }
            }

            for (int s = 0; s < segments; s++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    int v1 = s * n + i;
                    int v2 = s * n + i + 1;
                    int v3 = (s + 1) * n + i + 1;
                    int v4 = (s + 1) * n + i;
                    p.Faces.Add(new Face(new[] { v1, v2, v3, v4 }));
                }
            }

            return p;
        }

        // ==========================================================
        // ЛАБ7 - СИДОРЧИК АЛИСА (График функции)
        // ==========================================================
        public static Polyhedron CreateSurfaceGraph(Func<double, double, double> f,
            double x0, double x1, double y0, double y1, int divX, int divY)
        {
            var p = new Polyhedron();

            // 1. Создаем сетку вершин
            for (int i = 0; i <= divX; i++)
            {
                double x = x0 + (x1 - x0) * i / divX;
                for (int j = 0; j <= divY; j++)
                {
                    double y = y0 + (y1 - y0) * j / divY;
                    double z = f(x, y);

                    // X - вправо, Y - высота (график), Z - вглубь
                    p.Vertices.Add(new Point3D(x, z, y));
                }
            }

            // 2. Создаем грани (треугольники)
            for (int i = 0; i < divX; i++)
            {
                for (int j = 0; j < divY; j++)
                {
                    int v1 = i * (divY + 1) + j;
                    int v2 = v1 + 1;
                    int v3 = (i + 1) * (divY + 1) + j + 1;
                    int v4 = (i + 1) * (divY + 1) + j;

                    p.Faces.Add(new Face(new[] { v1, v2, v3 }));
                    p.Faces.Add(new Face(new[] { v1, v3, v4 }));
                }
            }

            // 3. Масштабирование, чтобы влезло в экран
            double maxDist = 0;
            foreach (var v in p.Vertices)
                maxDist = Math.Max(maxDist, v.Length);

            if (maxDist > 0)
            {
                double scale = 2.0 / maxDist;
                for (int i = 0; i < p.Vertices.Count; i++)
                    p.Vertices[i] = p.Vertices[i] * scale;
            }

            return p;
        }
    }
}