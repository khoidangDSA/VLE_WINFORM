using System;

namespace Baitap4_Cau2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho ten day du: ");
            string hoTen = Console.ReadLine();

            string[] cacTu = hoTen.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (cacTu.Length >= 2)
            {
                string ho = cacTu[0];
                string ten = cacTu[cacTu.Length - 1];

                string tenLot = "";

                for (int i = 1; i < cacTu.Length - 1; i++)
                {
                    tenLot = tenLot + cacTu[i] + " ";
                }

                tenLot = tenLot.Trim();

                Console.WriteLine("Ho: " + ho);

                if (tenLot == "")
                {
                    Console.WriteLine("Ten lot: Khong co");
                }
                else
                {
                    Console.WriteLine("Ten lot: " + tenLot);
                }

                Console.WriteLine("Ten: " + ten);
            }
            else
            {
                Console.WriteLine(
                    "Vui long nhap it nhat ho va ten."
                );
            }

            Console.ReadKey();
        }
    }
}