
using System;

namespace BaiTapDaThuc
{
    class DaThuc
    {
        private double[] a;
        private int n;

        // Constructor: tao da thuc bac n, cac he so bang 0
        public DaThuc(int bac)
        {
            if (bac < 0)
            {
                throw new ArgumentException("Bac da thuc phai >= 0");
            }

            n = bac;
            a = new double[n + 1];

            for (int i = 0; i <= n; i++)
            {
                a[i] = 0;
            }
        }

        // Property cho biet bac da thuc
        public int Bac
        {
            get { return n; }
        }

        // Indexer: truy cap he so a[k]
        public double this[int k]
        {
            get
            {
                if (k < 0 || k > n)
                {
                    throw new IndexOutOfRangeException();
                }

                return a[k];
            }
            set
            {
                if (k < 0 || k > n)
                {
                    throw new IndexOutOfRangeException();
                }

                a[k] = value;
            }
        }

        // Cong hai da thuc
        public static DaThuc operator +(DaThuc p, DaThuc q)
        {
            int bacMax = Math.Max(p.n, q.n);
            DaThuc ketQua = new DaThuc(bacMax);

            for (int i = 0; i <= bacMax; i++)
            {
                double hesoP = 0;
                double hesoQ = 0;

                if (i <= p.n)
                    hesoP = p[i];

                if (i <= q.n)
                    hesoQ = q[i];

                ketQua[i] = hesoP + hesoQ;
            }

            return ketQua;
        }

        // Tru hai da thuc
        public static DaThuc operator -(DaThuc p, DaThuc q)
        {
            int bacMax = Math.Max(p.n, q.n);
            DaThuc ketQua = new DaThuc(bacMax);

            for (int i = 0; i <= bacMax; i++)
            {
                double hesoP = 0;
                double hesoQ = 0;

                if (i <= p.n)
                    hesoP = p[i];

                if (i <= q.n)
                    hesoQ = q[i];

                ketQua[i] = hesoP - hesoQ;
            }

            return ketQua;
        }

        // Tinh gia tri da thuc tai x = b
        public double TinhGiaTri(double b)
        {
            double ketQua = 0;

            for (int i = 0; i <= n; i++)
            {
                ketQua += a[i] * Math.Pow(b, i);
            }

            return ketQua;
        }

        // Xuat da thuc
        public void Xuat()
        {
            for (int i = n; i >= 0; i--)
            {
                Console.Write(a[i] + "x^{0}", i);

                if (i > 0)
                    Console.Write(" + ");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tao da thuc P(x) bac 2
            DaThuc p = new DaThuc(2);

            p[0] = 1;  // he so tu do
            p[1] = 2;  // he so x
            p[2] = 3;  // he so x^2

            // Tao da thuc Q(x) bac 1
            DaThuc q = new DaThuc(1);

            q[0] = 4;
            q[1] = 5;

            Console.Write("P(x) = ");
            p.Xuat();

            Console.Write("Q(x) = ");
            q.Xuat();

            // Cong da thuc
            DaThuc tong = p + q;

            Console.Write("P(x) + Q(x) = ");
            tong.Xuat();

            // Tru da thuc
            DaThuc hieu = p - q;

            Console.Write("P(x) - Q(x) = ");
            hieu.Xuat();

            // Tinh gia tri tai x = 2
            Console.WriteLine("P(2) = " + p.TinhGiaTri(2));
            Console.WriteLine("Q(2) = " + q.TinhGiaTri(2));

            Console.ReadKey();
        }
    }
}
