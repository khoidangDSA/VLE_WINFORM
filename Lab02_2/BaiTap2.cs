
using System;
using System.Collections.Generic;

namespace BaiTap3
{
    // Khai bao cau truc mat hang
    class MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public double DonGia;

        // Constructor
        public MatHang(int maMH, string tenMH, int soLuong, double donGia)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        // Ham tinh thanh tien
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
    }

    class Program
    {
        // Ham them mat hang vao danh sach
        static void ThemMatHang(List<MatHang> ds, MatHang mh)
        {
            ds.Add(mh);
        }

        // Ham tim mat hang theo ma, co thi tra ve true
        static bool TimMatHang(List<MatHang> ds, int maMH)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaMH == maMH)
                {
                    return true;
                }
            }

            return false;
        }

        // Ham xuat danh sach mat hang
        static void XuatDanhSach(List<MatHang> ds)
        {
            Console.WriteLine("\nDANH SACH MAT HANG");
            Console.WriteLine("MaMH\tTenMH\tSoLuong\tDonGia\tThanhTien");

            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine(
                    ds[i].MaMH + "\t" +
                    ds[i].TenMH + "\t" +
                    ds[i].SoLuong + "\t" +
                    ds[i].DonGia + "\t" +
                    ds[i].ThanhTien()
                );
            }
        }

        // Ham xoa mat hang theo ma
        static void XoaMatHang(List<MatHang> ds, int maMH)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaMH == maMH)
                {
                    ds.RemoveAt(i);
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            List<MatHang> ds = new List<MatHang>();
            string tiepTuc;

            // Nhap danh sach mat hang
            do
            {
                int maMH;
                string tenMH;
                int soLuong;
                double donGia;

                Console.Write("Nhap ma mat hang: ");
                maMH = int.Parse(Console.ReadLine());

                Console.Write("Nhap ten mat hang: ");
                tenMH = Console.ReadLine();

                Console.Write("Nhap so luong: ");
                soLuong = int.Parse(Console.ReadLine());

                Console.Write("Nhap don gia: ");
                donGia = double.Parse(Console.ReadLine());

                MatHang mh = new MatHang(maMH, tenMH, soLuong, donGia);

                ThemMatHang(ds, mh);

                Console.Write("Ban co muon nhap tiep khong? (c/k): ");
                tiepTuc = Console.ReadLine();

            } while (tiepTuc.ToLower() == "c");

            // Xuat danh sach
            XuatDanhSach(ds);

            // Tim va xoa mat hang
            int maCanTim;
            Console.Write("\nNhap ma mat hang can tim va xoa: ");
            maCanTim = int.Parse(Console.ReadLine());

            if (TimMatHang(ds, maCanTim))
            {
                Console.WriteLine("Tim thay mat hang. Tien hanh xoa...");
                XoaMatHang(ds, maCanTim);

                Console.WriteLine("Danh sach sau khi xoa:");
                XuatDanhSach(ds);
            }
            else
            {
                Console.WriteLine("Khong tim thay mat hang co ma " + maCanTim);
            }

            Console.ReadKey();
        }
    }
}
