
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Lab03
{
    // LOP CHA
    class HinhHoc
    {
        public double DienTich { get; set; }
        public double ChuVi { get; set; }

        public virtual void tinhDienTichChuVi()
        {
        }

        public override string ToString()
        {
            return "Dien tich: " + DienTich
                + ", Chu vi: " + ChuVi;
        }
    }

    // HINH CHU NHAT
    class HinhChuNhat : HinhHoc
    {
        private double mChieuDai;
        private double mChieuRong;

        public HinhChuNhat()
        {
            mChieuDai = 0;
            mChieuRong = 0;
        }

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            mChieuDai = chieuDai;
            mChieuRong = chieuRong;
            tinhDienTichChuVi();
        }

        public double ChieuDai
        {
            get { return mChieuDai; }
            set
            {
                mChieuDai = value;
                tinhDienTichChuVi();
            }
        }

        public double ChieuRong
        {
            get { return mChieuRong; }
            set
            {
                mChieuRong = value;
                tinhDienTichChuVi();
            }
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = mChieuDai * mChieuRong;
            ChuVi = (mChieuDai + mChieuRong) * 2;
        }

        public override string ToString()
        {
            return "Hinh chu nhat: Chieu dai = " + mChieuDai
                + ", Chieu rong = " + mChieuRong
                + ", " + base.ToString();
        }
    }

    // HINH TRON
    class HinhTron : HinhHoc
    {
        private double mBanKinh;

        public HinhTron()
        {
            mBanKinh = 0;
        }

        public HinhTron(double banKinh)
        {
            mBanKinh = banKinh;
            tinhDienTichChuVi();
        }

        public double BanKinh
        {
            get { return mBanKinh; }
            set
            {
                mBanKinh = value;
                tinhDienTichChuVi();
            }
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = Math.PI * mBanKinh * mBanKinh;
            ChuVi = 2 * Math.PI * mBanKinh;
        }

        public override string ToString()
        {
            return "Hinh tron: Ban kinh = " + mBanKinh
                + ", " + base.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<HinhHoc> ds = new List<HinhHoc>();

            // DOC FILE
            string fileInput = "HinhHoc.txt";
            string fileOutput = "output.txt";

            if (!File.Exists(fileInput))
            {
                Console.WriteLine("Khong tim thay file HinhHoc.txt!");
                Console.WriteLine("Hay dat file trong thu muc chay chuong trinh.");
                Console.ReadKey();
                return;
            }

            string[] lines = File.ReadAllLines(fileInput);

            foreach (string line in lines)
            {
                string dong = line.Trim();

                // Bo qua dong rong va dong chu thich
                if (dong == "" || dong.StartsWith("#"))
                {
                    continue;
                }

                // Tach cac thong so theo khoang trang hoac tab
                string[] parts = dong.Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                int loai;
                if (parts.Length == 0 ||
                    !int.TryParse(parts[0], out loai))
                {
                    continue;
                }

                if (loai == 1 && parts.Length >= 3)
                {
                    double dai = double.Parse(
                        parts[1], CultureInfo.InvariantCulture);
                    double rong = double.Parse(
                        parts[2], CultureInfo.InvariantCulture);

                    ds.Add(new HinhChuNhat(dai, rong));
                }
                else if (loai == 2 && parts.Length >= 2)
                {
                    double banKinh = double.Parse(
                        parts[1], CultureInfo.InvariantCulture);

                    ds.Add(new HinhTron(banKinh));
                }
            }

            if (ds.Count == 0)
            {
                Console.WriteLine("File khong co du lieu hinh hop le.");
                Console.ReadKey();
                return;
            }

            // TINH TONG DIEN TICH VA TONG CHU VI
            double tongDienTich = 0;
            double tongChuVi = 0;

            HinhChuNhat hcnMax = null;
            HinhTron htMin = null;

            foreach (HinhHoc h in ds)
            {
                tongDienTich += h.DienTich;
                tongChuVi += h.ChuVi;

                HinhChuNhat hcn = h as HinhChuNhat;
                if (hcn != null)
                {
                    if (hcnMax == null ||
                        hcn.DienTich > hcnMax.DienTich)
                    {
                        hcnMax = hcn;
                    }
                }

                HinhTron ht = h as HinhTron;
                if (ht != null)
                {
                    if (htMin == null ||
                        ht.ChuVi < htMin.ChuVi)
                    {
                        htMin = ht;
                    }
                }
            }

            // GHI KET QUA RA FILE
            using (StreamWriter sw = new StreamWriter(fileOutput))
            {
                sw.WriteLine("KET QUA QUAN LY HINH HOC");
                sw.WriteLine("========================");
                sw.WriteLine("Tong dien tich: " +
                    tongDienTich.ToString("F2"));
                sw.WriteLine("Tong chu vi: " +
                    tongChuVi.ToString("F2"));

                sw.WriteLine();
                sw.WriteLine("HINH CHU NHAT CO DIEN TICH LON NHAT:");

                if (hcnMax != null)
                {
                    sw.WriteLine(hcnMax.ToString());
                }
                else
                {
                    sw.WriteLine("Khong co hinh chu nhat.");
                }

                sw.WriteLine();
                sw.WriteLine("HINH TRON CO CHU VI NHO NHAT:");

                if (htMin != null)
                {
                    sw.WriteLine(htMin.ToString());
                }
                else
                {
                    sw.WriteLine("Khong co hinh tron.");
                }
            }

            Console.WriteLine("Danh sach hinh hoc:");

            foreach (HinhHoc h in ds)
            {
                Console.WriteLine(h.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Tong dien tich: " + tongDienTich.ToString("F2"));
            Console.WriteLine("Tong chu vi: " + tongChuVi.ToString("F2"));
            Console.WriteLine("Da ghi ket qua vao file output.txt");

            Console.ReadKey();
        }
    }
}
