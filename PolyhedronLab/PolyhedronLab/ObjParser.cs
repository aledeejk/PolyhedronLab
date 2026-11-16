using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PolyhedronLab
{
    public static class ObjParser
    {
        public static Polyhedron Load(string filePath)
        {
            var poly = new Polyhedron();
            var temp = new List<Point3D>();
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#")) continue;
                var p = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (p.Length == 0) continue;
                if (p[0] == "v" && p.Length >= 4)
                    temp.Add(new Point3D(
                        double.Parse(p[1], CultureInfo.InvariantCulture),
                        double.Parse(p[2], CultureInfo.InvariantCulture),
                        double.Parse(p[3], CultureInfo.InvariantCulture)));
                else if (p[0] == "f")
                {
                    var idx = new List<int>();
                    for (int i = 1; i < p.Length; i++)
                    {
                        var vd = p[i].Split('/');
                        int id = int.Parse(vd[0]);
                        if (id < 0) id = temp.Count + id + 1;
                        else id = id - 1;
                        idx.Add(id);
                    }
                    poly.Faces.Add(new Face(idx));
                }
            }
            double maxDist = 0;
            foreach (var v in temp) maxDist = Math.Max(maxDist, v.Length);
            if (maxDist > 0) foreach (var v in temp) poly.Vertices.Add(v * (1.0 / maxDist));
            else poly.Vertices.AddRange(temp);
            return poly;
        }

        public static void Save(Polyhedron poly, string filePath)
        {
            using (var w = new StreamWriter(filePath))
            {
                w.WriteLine("# PolyhedronLab OBJ Export");
                foreach (var v in poly.Vertices)
                    w.WriteLine($"v {v.X.ToString(CultureInfo.InvariantCulture)} {v.Y.ToString(CultureInfo.InvariantCulture)} {v.Z.ToString(CultureInfo.InvariantCulture)}");
                foreach (var f in poly.Faces)
                {
                    w.Write("f");
                    foreach (var i in f.Indices) w.Write($" {i + 1}");
                    w.WriteLine();
                }
            }
        }
    }
}