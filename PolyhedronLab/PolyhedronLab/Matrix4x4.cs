using System;

namespace PolyhedronLab
{
    public class Matrix4x4
    {
        public double M11, M12, M13, M14;
        public double M21, M22, M23, M24;
        public double M31, M32, M33, M34;
        public double M41, M42, M43, M44;

        public Matrix4x4()
        {
            M11 = M22 = M33 = M44 = 1.0;
        }

        public static Matrix4x4 Identity() => new Matrix4x4();

        public static Matrix4x4 Translate(double dx, double dy, double dz)
        {
            var m = new Matrix4x4();
            m.M14 = dx; m.M24 = dy; m.M34 = dz;
            return m;
        }

        public static Matrix4x4 Scale(double sx, double sy, double sz)
        {
            var m = new Matrix4x4();
            m.M11 = sx; m.M22 = sy; m.M33 = sz;
            return m;
        }

        public static Matrix4x4 ScaleAboutCenter(Point3D c, double k)
        {
            // ВАЖНО: для вектор-строк порядок именно такой (t1 * s * t2)!
            // Сначала переносим в 0, затем масштабируем, затем возвращаем.
            var t1 = Translate(-c.X, -c.Y, -c.Z);
            var s = Scale(k, k, k);
            var t2 = Translate(c.X, c.Y, c.Z);
            return t1 * s * t2;
        }

        public static Matrix4x4 RotateX(double deg)
        {
            double a = deg * Math.PI / 180.0;
            double c = Math.Cos(a), s = Math.Sin(a);
            var m = new Matrix4x4();
            m.M22 = c; m.M23 = -s;
            m.M32 = s; m.M33 = c;
            return m;
        }

        public static Matrix4x4 RotateY(double deg)
        {
            double a = deg * Math.PI / 180.0;
            double c = Math.Cos(a), s = Math.Sin(a);
            var m = new Matrix4x4();
            m.M11 = c; m.M13 = s;
            m.M31 = -s; m.M33 = c;
            return m;
        }

        public static Matrix4x4 RotateZ(double deg)
        {
            double a = deg * Math.PI / 180.0;
            double c = Math.Cos(a), s = Math.Sin(a);
            var m = new Matrix4x4();
            m.M11 = c; m.M12 = -s;
            m.M21 = s; m.M22 = c;
            return m;
        }

        public static Matrix4x4 RotateAxis(Point3D axis, double deg)
        {
            var u = axis.Normalized();
            double x = u.X, y = u.Y, z = u.Z;
            double a = deg * Math.PI / 180.0;
            double c = Math.Cos(a), s = Math.Sin(a);
            double t = 1 - c;

            var m = new Matrix4x4();
            m.M11 = t * x * x + c;
            m.M12 = t * x * y - s * z;
            m.M13 = t * x * z + s * y;
            m.M21 = t * x * y + s * z;
            m.M22 = t * y * y + c;
            m.M23 = t * y * z - s * x;
            m.M31 = t * x * z - s * y;
            m.M32 = t * y * z + s * x;
            m.M33 = t * z * z + c;
            return m;
        }

        public static Matrix4x4 RotateAroundLine(Point3D p1, Point3D p2, double deg)
        {
            var dir = p2 - p1;
            return Translate(-p1.X, -p1.Y, -p1.Z)
                 * RotateAxis(dir, deg)
                 * Translate(p1.X, p1.Y, p1.Z);
        }

        public static Matrix4x4 ReflectPlane(char plane)
        {
            var m = new Matrix4x4();
            switch (char.ToUpper(plane))
            {
                case 'X': m.M11 = -1; break;
                case 'Y': m.M22 = -1; break;
                case 'Z': m.M33 = -1; break;
                default: throw new ArgumentException("Плоскость X, Y или Z");
            }
            return m;
        }

        public static Matrix4x4 Perspective(double c)
        {
            var m = new Matrix4x4();
            m.M44 = 1;
            m.M43 = -1.0 / c;
            return m;
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            var r = new Matrix4x4();
            r.M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41;
            r.M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42;
            r.M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43;
            r.M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44;

            r.M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41;
            r.M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42;
            r.M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43;
            r.M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44;

            r.M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41;
            r.M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42;
            r.M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43;
            r.M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44;

            r.M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41;
            r.M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42;
            r.M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43;
            r.M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44;
            return r;
        }
    }
}