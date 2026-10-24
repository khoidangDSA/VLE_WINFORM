
using System;

namespace BaiTapQuanLyNhanVien
{
    // ================= LOP NGUOI =================
    class Nguoi
    {
        private string hoTen;
        private DateTime ngaySinh;
        private string diaChi;

        // Constructor khong tham so
        public Nguoi()
        {
            hoTen = "";
            ngaySinh = new DateTime(2000, 1, 1);
            diaChi = "";
        }

        // Constructor co tham so
        public Nguoi(string hoTen, DateTime ngaySinh, string diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }

        // Properties
        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    hoTen = value;
                else
                    throw new ArgumentException("Ho ten khong duoc de trong.");
            }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set
            {
                if (value <= DateTime.Now)
                    ngaySinh = value;
                else
                    throw new ArgumentException("Ngay sinh khong hop le.");
            }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    diaChi = value;
                else
                    throw new ArgumentException("Dia chi khong duoc de trong.");
            }
        }

        // Property chi doc: LayTuoi
        public int LayTuoi
        {
            get
            {
                int tuoi = DateTime.Now.Year - ngaySinh.Year;

                if (DateTime.Now < ngaySinh.AddYears(tuoi))
                    tuoi--;

                return tuoi;
            }
        }

        // Phuong thuc xem thong tin
        public virtual void XemThongTin()
        {
            Console.WriteLine("Ho ten: " + HoTen);
            Console.WriteLine("Ngay sinh: " + NgaySinh.ToShortDateString());
            Console.WriteLine("Dia chi: " + DiaChi);
            Console.WriteLine("Tuoi: " + LayTuoi);
        }
    }

    // ================= LOP SINH VIEN =================
    class SinhVien : Nguoi
    {
        private string maSV;
        private string maLop;
        private string email;
        private string dienThoai;

        // Constructor khong tham so
        public SinhVien() : base()
        {
            maSV = "";
            maLop = "";
            email = "";
            dienThoai = "";
        }

        // Constructor co tham so
        public SinhVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maSV, string maLop, string email,
                        string dienThoai)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaSV = maSV;
            MaLop = maLop;
            Email = email;
            DienThoai = dienThoai;
        }

        public string MaSV
        {
            get { return maSV; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    maSV = value;
                else
                    throw new ArgumentException("Ma sinh vien khong duoc de trong.");
            }
        }

        public string MaLop
        {
            get { return maLop; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    maLop = value;
                else
                    throw new ArgumentException("Ma lop khong duoc de trong.");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    value.Contains("@"))
                    email = value;
                else
                    throw new ArgumentException("Email khong hop le.");
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    dienThoai = value;
                else
                    throw new ArgumentException("Dien thoai khong duoc de trong.");
            }
        }

        public override void XemThongTin()
        {
            Console.WriteLine("\n===== THONG TIN SINH VIEN =====");
            base.XemThongTin();
            Console.WriteLine("Ma sinh vien: " + MaSV);
            Console.WriteLine("Ma lop: " + MaLop);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Dien thoai: " + DienThoai);
        }
    }

    // ================= LOP NHAN VIEN =================
    class NhanVien : Nguoi
    {
        private string maNhanVien;
        private string email;
        private string dienThoai;
        private DateTime ngayLamViec;
        private string maCongTy;

        // Constructor khong tham so
        public NhanVien() : base()
        {
            maNhanVien = "";
            email = "";
            dienThoai = "";
            ngayLamViec = DateTime.Now;
            maCongTy = "";
        }

        // Constructor co tham so
        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maNhanVien, string email, string dienThoai,
                        DateTime ngayLamViec, string maCongTy)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaNhanVien = maNhanVien;
            Email = email;
            DienThoai = dienThoai;
            NgayLamViec = ngayLamViec;
            MaCongTy = maCongTy;
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    maNhanVien = value;
                else
                    throw new ArgumentException("Ma nhan vien khong duoc de trong.");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    value.Contains("@"))
                    email = value;
                else
                    throw new ArgumentException("Email khong hop le.");
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    dienThoai = value;
                else
                    throw new ArgumentException("Dien thoai khong duoc de trong.");
            }
        }

        public DateTime NgayLamViec
        {
            get { return ngayLamViec; }
            set
            {
                if (value <= DateTime.Now)
                    ngayLamViec = value;
                else
                    throw new ArgumentException("Ngay lam viec khong hop le.");
            }
        }

        public string MaCongTy
        {
            get { return maCongTy; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    maCongTy = value;
                else
                    throw new ArgumentException("Ma cong ty khong duoc de trong.");
            }
        }

        public override void XemThongTin()
        {
            Console.WriteLine("\n===== THONG TIN NHAN VIEN =====");
            base.XemThongTin();
            Console.WriteLine("Ma nhan vien: " + MaNhanVien);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Dien thoai: " + DienThoai);
            Console.WriteLine("Ngay lam viec: " + NgayLamViec.ToShortDateString());
            Console.WriteLine("Ma cong ty: " + MaCongTy);
        }
    }

    // ================= MAIN =================
    class Program
    {
        static void Main(string[] args)
        {
            // Kiem tra lop Nguoi
            Nguoi n = new Nguoi(
                "Nguyen Van An",
                new DateTime(2000, 5, 10),
                "TP Ho Chi Minh"
            );

            n.XemThongTin();

            // Kiem tra lop SinhVien
            SinhVien sv = new SinhVien(
                "Tran Thi Binh",
                new DateTime(2004, 8, 15),
                "TP Ho Chi Minh",
                "SV001",
                "CNTT02",
                "binh@gmail.com",
                "0901234567"
            );

            sv.XemThongTin();

            // Kiem tra lop NhanVien
            NhanVien nv = new NhanVien(
                "Le Van Cuong",
                new DateTime(1995, 3, 20),
                "Binh Duong",
                "NV001",
                "cuong@gmail.com",
                "0912345678",
                new DateTime(2020, 6, 1),
                "CTY01"
            );

            nv.XemThongTin();

            Console.ReadKey();
        }
    }
}
