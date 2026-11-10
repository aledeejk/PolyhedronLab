using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PolyhedronLab
{
    // =========================================================================
    // ДЕЕВА АЛЕКСАНДРА 
    // =========================================================================
    public static class ObjParser
    {
        // --- ЗАГРУЗКА ИЗ ФАЙЛА ---
        public static Polyhedron Load(string filePath)
        {
            var poly = new Polyhedron();
            var tempVertices = new List<Point3D>();

            foreach (var line in File.ReadLines(filePath))
            {
                // Пропускаем пустые строки и комментарии (начинаются с #)
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;

                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                if (parts[0] == "v") // Вершина
                {
                    // В OBJ вершина задается как "v x y z" (иногда с 4-й координатой w)
                    if (parts.Length >= 4)
                    {
                        double x = double.Parse(parts[1], CultureInfo.InvariantCulture);
                        double y = double.Parse(parts[2], CultureInfo.InvariantCulture);
                        double z = double.Parse(parts[3], CultureInfo.InvariantCulture);
                        tempVertices.Add(new Point3D(x, y, z));
                    }
                }
                else if (parts[0] == "f") // Грань
                {
                    var faceIndices = new List<int>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        // Грань может быть записана как "v", "v/vt" или "v/vt/vn".
                        // Нас интересует только первая часть (индекс вершины).
                        var vertexData = parts[i].Split('/');
                        int index = int.Parse(vertexData[0]);

                        // В OBJ индексы начинаются с 1. 
                        // Если индекс отрицательный, это означает "от конца списка".
                        if (index < 0)
                            index = tempVertices.Count + index + 1;
                        else
                            index = index - 1; // Приводим к 0-индексации C#

                        faceIndices.Add(index);
                    }
                    poly.Faces.Add(new Face(faceIndices));
                }
            }

            // Нормализация (масштабирование), чтобы модель любого размера влезла в экран
            double maxDist = 0;
            foreach (var v in tempVertices)
                maxDist = Math.Max(maxDist, v.Length);

            if (maxDist > 0)
            {
                foreach (var v in tempVertices)
                    poly.Vertices.Add(v * (1.0 / maxDist));
            }
            else
            {
                poly.Vertices.AddRange(tempVertices);
            }

            return poly;
        }

        // --- СОХРАНЕНИЕ В ФАЙЛ ---
        public static void Save(Polyhedron poly, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("# PolyhedronLab OBJ Export");

                // Записываем все вершины
                foreach (var v in poly.Vertices)
                {
                    writer.WriteLine($"v {v.X.ToString(CultureInfo.InvariantCulture)} {v.Y.ToString(CultureInfo.InvariantCulture)} {v.Z.ToString(CultureInfo.InvariantCulture)}");
                }

                // Записываем все грани
                foreach (var face in poly.Faces)
                {
                    writer.Write("f");
                    foreach (var idx in face.Indices)
                    {
                        writer.Write($" {idx + 1}"); // В OBJ индексы с 1
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}