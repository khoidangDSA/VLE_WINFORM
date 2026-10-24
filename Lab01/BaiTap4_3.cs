using System;
using System.Globalization;

namespace Baitap4_Cau3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine();

            // Xoa khoang trang dau va cuoi, tach cac tu
            string[] cacTu = hoTen.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (cacTu.Length == 0)
            {
                Console.WriteLine("Ho ten khong duoc de trong.");
            }
            else
            {
                CultureInfo vanHoa = new CultureInfo("vi-VN");

                // Chuan hoa tung tu
                for (int i = 0; i < cacTu.Length; i++)
                {
                    cacTu[i] = cacTu[i].ToLower(vanHoa);

                    cacTu[i] = cacTu[i].Substring(0, 1)
                                 .ToUpper(vanHoa)
                                 + cacTu[i].Substring(1);
                }

                // Noi cac tu bang mot khoang trang
                string hoTenChuan = string.Join(" ", cacTu);

                Console.WriteLine("Ho ten chuan: " + hoTenChuan);
            }

            Console.ReadKey();
        }
    }
}