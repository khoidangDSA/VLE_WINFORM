
using System;
using System.Collections.Generic;

namespace BaiTapClass
{
    // ==================== BAI 1.1: SINH VIEN ====================
    class SinhVien
    {
        private int maSV;
        private string hoTen;
        private DateTime ngaySinh;
        private string diaChi;
        private string dienThoai;

        // Constructor khong tham so
        public SinhVien()
        {
            maSV = 0;
            hoTen = "";
            ngaySinh = DateTime.Now;
            diaChi = "";
            dienThoai = "";
        }

        // Constructor co tham so
        public SinhVien(int maSV, string hoTen, DateTime ngaySinh,
                        string diaChi, string dienThoai)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }

        // Properties
        public int MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }

        // Property chi doc: tinh tuoi sinh vien
        public int LayTuoi
        {
            get
            {
                int tuoi = DateTime.Now.Year - ngaySinh.Year;

                if (DateTime.Now < ngaySinh.AddYears(tuoi))
                {
                    tuoi--;
                }

                return tuoi;
            }
        }

        public override string ToString()
        {
            return "Ma SV: " + MaSV
                + ", Ho ten: " + HoTen
                + ", Ngay sinh: " + NgaySinh.ToShortDateString()
                + ", Dia chi: " + DiaChi
                + ", Dien thoai: " + DienThoai
                + ", Tuoi: " + LayTuoi;
        }
    }

    // ==================== BAI 1.2: HINH CHU NHAT ====================
    class HinhChuNhat
    {
        private double mChieuCao;
        private double mChieuRong;

        // Constructor khong tham so
        public HinhChuNhat()
        {
            mChieuCao = 0;
            mChieuRong = 0;
        }

        // Constructor co tham so
        public HinhChuNhat(double chieuCao, double chieuRong)
        {
            mChieuCao = chieuCao;
            mChieuRong = chieuRong;
        }

        // Properties
        public double ChieuCao
        {
            get { return mChieuCao; }
            set { mChieuCao = value; }
        }

        public double ChieuRong
        {
            get { return mChieuRong; }
            set { mChieuRong = value; }
        }

        // Tinh chu vi
        public double TinhChuVi()
        {
            return (mChieuCao + mChieuRong) * 2;
        }

        // Tinh dien tich
        public double TinhDienTich()
        {
            return mChieuCao * mChieuRong;
        }

        // Kiem tra hinh vuong
        public bool LaHinhVuong()
        {
            return mChieuCao == mChieuRong;
        }

        // Xuat thong tin
        public void XuatThongTin()
        {
            Console.WriteLine("Chieu cao: " + mChieuCao);
            Console.WriteLine("Chieu rong: " + mChieuRong);
            Console.WriteLine("Dien tich: " + TinhDienTich());
            Console.WriteLine("Chu vi: " + TinhChuVi());

            if (LaHinhVuong())
            {
                Console.WriteLine("Day la hinh vuong.");
            }
            else
            {
                Console.WriteLine("Day khong phai hinh vuong.");
            }
        }
    }

    // ==================== BAI 1.3: SAN PHAM ====================
    class SanPham
    {
        private string ma;
        private string ten;
        private double gia;

        // Constructor mac dinh
        public SanPham()
        {
            ma = "";
            ten = "";
            gia = 0;
        }

        // Constructor co 3 doi so
        public SanPham(string ma, string ten, double gia)
        {
            this.ma = ma;
            this.ten = ten;
            this.gia = gia;
        }

        // Phuong thuc tinh thue VAT (10%)
        public double TinhVAT()
        {
            return gia * 0.1;
        }

        // Nhap thong tin san pham
        public void Nhap()
        {
            Console.Write("Nhap ma san pham: ");
            ma = Console.ReadLine();

            Console.Write("Nhap ten san pham: ");
            ten = Console.ReadLine();

            Console.Write("Nhap gia san pham: ");
            gia = double.Parse(Console.ReadLine());
        }

        // Xuat thong tin san pham
        public void Xuat()
        {
            Console.WriteLine("Ma san pham: " + ma);
            Console.WriteLine("Ten san pham: " + ten);
            Console.WriteLine("Gia san pham: " + gia);
            Console.WriteLine("Thue VAT: " + TinhVAT());
        }
    }

    // ==================== MAIN ====================
    class Program
    {
        static void Main(string[] args)
        {
            // KIEM TRA BAI 1.1
            Console.WriteLine("===== BAI 1.1: SINH VIEN =====");

            List<SinhVien> dssv = new List<SinhVien>();

            dssv.Add(new SinhVien
            {
                MaSV = 1,
                HoTen = "Tran Van Teo",
                DienThoai = "0909789567",
                DiaChi = "123 Truong Dinh",
                NgaySinh = new DateTime(2000, 11, 28)
            });

            dssv.Add(new SinhVien(
                2, "Tran Van Quang",
                new DateTime(1999, 11, 28),
                "123 Truong Cong Dinh",
                "0909567789"
            ));

            foreach (SinhVien sv in dssv)
            {
                Console.WriteLine(sv);
            }

            // KIEM TRA BAI 1.2
            Console.WriteLine("\n===== BAI 1.2: HINH CHU NHAT =====");

            HinhChuNhat hcn = new HinhChuNhat();

            Console.Write("Nhap chieu cao: ");
            hcn.ChieuCao = double.Parse(Console.ReadLine());

            Console.Write("Nhap chieu rong: ");
            hcn.ChieuRong = double.Parse(Console.ReadLine());

            hcn.XuatThongTin();

            // KIEM TRA BAI 1.3
            Console.WriteLine("\n===== BAI 1.3: SAN PHAM =====");

            SanPham sp1 = new SanPham();
            SanPham sp2 = new SanPham();

            Console.WriteLine("\nNhap san pham thu nhat:");
            sp1.Nhap();

            Console.WriteLine("\nNhap san pham thu hai:");
            sp2.Nhap();

            Console.WriteLine("\nThong tin san pham thu nhat:");
            sp1.Xuat();

            Console.WriteLine("\nThong tin san pham thu hai:");
            sp2.Xuat();

            Console.ReadKey();
        }
    }
}
