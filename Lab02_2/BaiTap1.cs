
using System;
using System.Collections.Generic;

namespace BaiTapList
{
    class Program
    {
        // Ham nhap danh sach hang hoa
        static void NhapDanhSach(List<string> ds)
        {
            string ten;

            do
            {
                Console.Write("Nhap ten hang hoa (nhap stop de dung): ");
                ten = Console.ReadLine();

                if (ten.ToLower() != "stop")
                {
                    ds.Add(ten);
                }

            } while (ten.ToLower() != "stop");
        }

        // Ham xuat danh sach
        static void XuatDanhSach(List<string> ds)
        {
            Console.WriteLine("\nDanh sach hang hoa:");

            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine(i + ". " + ds[i]);
            }
        }

        // Ham tim kiem, tra ve true hoac false
        static bool TimHangHoa(List<string> ds, string ten)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].ToLower() == ten.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        // Ham xoa hang hoa theo ten
        static bool XoaHangHoa(List<string> ds, string ten)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].ToLower() == ten.ToLower())
                {
                    ds.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        // Ham them hang hoa vao vi tri index
        static bool ThemTaiViTri(List<string> ds, string ten, int index)
        {
            if (index < 0 || index > ds.Count)
            {
                return false;
            }

            ds.Insert(index, ten);
            return true;
        }

        static void Main(string[] args)
        {
            List<string> ds = new List<string>();

            // 1. Nhap danh sach
            NhapDanhSach(ds);

            // 2. Xuat danh sach
            XuatDanhSach(ds);

            // 3. Tim kiem hang hoa
            Console.Write("\nNhap ten hang hoa can tim: ");
            string tenTim = Console.ReadLine();

            if (TimHangHoa(ds, tenTim))
            {
                Console.WriteLine("Tim thay hang hoa.");
            }
            else
            {
                Console.WriteLine("Khong tim thay hang hoa.");
            }

            // 4. Xoa hang hoa
            Console.Write("\nNhap ten hang hoa can xoa: ");
            string tenXoa = Console.ReadLine();

            if (XoaHangHoa(ds, tenXoa))
            {
                Console.WriteLine("Xoa thanh cong.");
                XuatDanhSach(ds);
            }
            else
            {
                Console.WriteLine("Khong tim thay hang hoa de xoa.");
            }

            // 5. Them hang hoa vao vi tri index
            Console.Write("\nNhap ten hang hoa can them: ");
            string tenThem = Console.ReadLine();

            Console.Write("Nhap vi tri index: ");
            int index = int.Parse(Console.ReadLine());

            if (ThemTaiViTri(ds, tenThem, index))
            {
                Console.WriteLine("Them thanh cong.");
                XuatDanhSach(ds);
            }
            else
            {
                Console.WriteLine("Index khong hop le.");
            }

            Console.ReadKey();
        }
    }
}
