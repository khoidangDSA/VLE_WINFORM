
using System;

namespace DuongTron
{
    class Diem
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // Constructor mac dinh
        public Diem()
        {
            x = 0;
            y = 0;
        }

        // Constructor co tham so
        public Diem(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // Constructor sao chep
        public Diem(Diem p)
        {
            x = p.X;
            y = p.Y;
        }

        // Tinh khoang cach giua hai diem
        public double KhoangCach(Diem b)
        {
            double dx = X - b.X;
            double dy = Y - b.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Nhap diem
        public void Nhap()
        {
            Console.Write("Nhap hoanh do x: ");
            X = int.Parse(Console.ReadLine());

            Console.Write("Nhap tung do y: ");
            Y = int.Parse(Console.ReadLine());
        }

        // Xuat diem
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}
