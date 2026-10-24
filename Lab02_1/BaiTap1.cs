using System;

namespace Baitap1
{
    // Tao ngoai le rieng khi bieu thuc duoi can am
    class NotNegativeException : Exception
    {
        public NotNegativeException()
            : base("Bieu thuc duoi dau can phai >= 0!")
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Nhap x
                Console.Write("Nhap x: ");
                int x = int.Parse(Console.ReadLine());

                // Nhap y
                Console.Write("Nhap y: ");
                int y = int.Parse(Console.ReadLine());

                // Tinh tu so va mau so
                double tuSo = 3 * x + 2 * y;
                double mauSo = 2 * x - y;

                // Kiem tra chia cho 0
                if (mauSo == 0)
                {
                    throw new DivideByZeroException();
                }

                // Tinh bieu thuc duoi dau can
                double bieuThuc = tuSo / mauSo;

                // Kiem tra bieu thuc duoi can
                if (bieuThuc < 0)
                {
                    throw new NotNegativeException();
                }

                // Tinh can bac hai
                double H = Math.Sqrt(bieuThuc);

                Console.WriteLine("Gia tri H = " + H);
            }
            catch (FormatException)
            {
                Console.WriteLine("Loi: Vui long nhap so nguyen hop le!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Loi: Mau so bang 0, khong the chia!");
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}