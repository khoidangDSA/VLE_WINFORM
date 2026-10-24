using System;

namespace Baitap3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("Nhap so phan tu cua mang: ");

            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Nhap lai n (n > 0): ");
            }

            int[] a = new int[n];

            // Nhap mang
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[" + i + "]: ");

                while (!int.TryParse(Console.ReadLine(), out a[i]))
                {
                    Console.Write("Nhap sai! Vui long nhap lai a[" + i + "]: ");
                }
            }

            // Khoi tao tong, gia tri lon nhat va nho nhat
            int tong = 0;
            int max = a[0];
            int min = a[0];

            // Duyet mang
            for (int i = 0; i < n; i++)
            {
                tong = tong + a[i];

                if (a[i] > max)
                {
                    max = a[i];
                }

                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            Console.WriteLine("Tong cua mang = " + tong);
            Console.WriteLine("So nguyen lon nhat = " + max);
            Console.WriteLine("So nguyen nho nhat = " + min);

            Console.ReadKey();
        }
    }
}