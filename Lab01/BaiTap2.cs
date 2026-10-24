using System;

namespace Baitap2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;

            Console.Write("Nhap he so a: ");

            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Nhap sai! Vui long nhap lai a: ");
            }

            Console.Write("Nhap he so b: ");

            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.Write("Nhap sai! Vui long nhap lai b: ");
            }

            if (a != 0)
            {
                double x = -b / a;
                Console.WriteLine("Phuong trinh co nghiem x = " + x);
            }
            else if (b == 0)
            {
                Console.WriteLine("Phuong trinh co vo so nghiem.");
            }
            else
            {
                Console.WriteLine("Phuong trinh vo nghiem.");
            }

            Console.ReadKey();
        }
    }
}