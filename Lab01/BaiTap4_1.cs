using System;

namespace Baitap4_Cau1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho: ");
            string ho = Console.ReadLine();

            Console.Write("Nhap ten lot: ");
            string tenLot = Console.ReadLine();

            Console.Write("Nhap ten: ");
            string ten = Console.ReadLine();

            string hoTen = ho.Trim() + " "
                         + tenLot.Trim() + " "
                         + ten.Trim();

            Console.WriteLine("Ho ten day du: " + hoTen);

            Console.ReadKey();
        }
    }
}