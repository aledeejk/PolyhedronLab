using System;

namespace PolyhedronLab
{
    public struct Point3D
    {
        public double X, Y, Z;

        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }

        public static Point3D operator +(Point3D a, Point3D b)
            => new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Point3D operator -(Point3D a, Point3D b)
            => new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Point3D operator *(Point3D a, double k)
            => new Point3D(a.X * k, a.Y * k, a.Z * k);

        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Point3D Normalized()
        {
            double l = Length;
            return l < 1e-12 ? new Point3D(0, 0, 0) : new Point3D(X / l, Y / l, Z / l);
        }

        public static Point3D Cross(Point3D a, Point3D b)
            => new Point3D(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);

        public static double Dot(Point3D a, Point3D b)
            => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public Point3D Apply(Matrix4x4 m)
        {
            double x = m.M11 * X + m.M12 * Y + m.M13 * Z + m.M14;
            double y = m.M21 * X + m.M22 * Y + m.M23 * Z + m.M24;
            double z = m.M31 * X + m.M32 * Y + m.M33 * Z + m.M34;
            double w = m.M41 * X + m.M42 * Y + m.M43 * Z + m.M44;
            if (Math.Abs(w) < 1e-12) w = 1.0;
            return new Point3D(x / w, y / w, z / w);
        }

        public double[] ApplyHomogeneous(Matrix4x4 m)
        {
            double x = m.M11 * X + m.M12 * Y + m.M13 * Z + m.M14;
            double y = m.M21 * X + m.M22 * Y + m.M23 * Z + m.M24;
            double z = m.M31 * X + m.M32 * Y + m.M33 * Z + m.M34;
            double w = m.M41 * X + m.M42 * Y + m.M43 * Z + m.M44;
            return new[] { x, y, z, w };
        }

        public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2})";
    }
}