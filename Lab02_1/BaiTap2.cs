using System;
using System.Collections.Generic;

namespace Baitap2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhap n
            int n;

            Console.Write("Nhap n (n > 0): ");

            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Nhap lai n (n > 0): ");
            }

            // Tao List de luu cac so nguyen
            List<int> ml = new List<int>();

            // Tao doi tuong Random
            Random rd = new Random();

            // Phat sinh n so nguyen ngau nhien
            for (int i = 0; i < n; i++)
            {
                int so = rd.Next(100);
                ml.Add(so);
            }

            // Xuat day so ban dau
            Console.WriteLine("Day so ban dau:");

            for (int i = 0; i < ml.Count; i++)
            {
                Console.Write(ml[i] + " ");
            }

            // Sap xep tang dan
            ml.Sort();

            // Xuat day so sau khi sap xep
            Console.WriteLine("\nDay so tang dan:");

            for (int i = 0; i < ml.Count; i++)
            {
                Console.Write(ml[i] + " ");
            }

            Console.ReadKey();
        }
    }
}