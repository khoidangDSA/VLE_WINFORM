
using System;

namespace DuongTron
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constructor mac dinh
            Console.WriteLine("DUONG TRON 1:");
            DuongTron dt1 = new DuongTron();
            dt1.Xuat();

            // Constructor co tham so
            Console.WriteLine("\nDUONG TRON 2:");
            Diem p = new Diem(1, 3);
            DuongTron dt2 = new DuongTron(p, 10);
            dt2.Xuat();

            Console.WriteLine("Dien tich: " + dt2.DienTich());
            Console.WriteLine("Chu vi: " + dt2.ChuVi());

            // Constructor sao chep
            Console.WriteLine("\nDUONG TRON 3 (SAO CHEP):");
            DuongTron dt3 = new DuongTron(dt2);
            dt3.Xuat();

            // Nhap duong tron
            Console.WriteLine("\nNHAP DUONG TRON:");
            DuongTron dt4 = new DuongTron();
            dt4.Nhap();
            dt4.Xuat();

            Console.WriteLine("Dien tich: " + dt4.DienTich());
            Console.WriteLine("Chu vi: " + dt4.ChuVi());

            // Kiem tra vi tri diem
            Console.WriteLine("\nKIEM TRA VI TRI DIEM:");
            Diem diem = new Diem(5, 5);
            Console.WriteLine("Diem can kiem tra: " + diem);
            Console.WriteLine(dt2.ViTriDiem(diem));

            // Kiem tra vi tri hai duong tron
            Console.WriteLine("\nKIEM TRA VI TRI HAI DUONG TRON:");
            Console.WriteLine(dt2.ViTriDuongTron(dt4));

            Console.ReadKey();
        }
    }
}
