
using System;

namespace DuongTron
{
    class DuongTron
    {
        private Diem tam;
        private int banKinh;

        public Diem Tam
        {
            get { return tam; }
            set
            {
                if (value != null)
                    tam = new Diem(value);
                else
                    throw new ArgumentException("Tam khong duoc null.");
            }
        }

        public int BanKinh
        {
            get { return banKinh; }
            set
            {
                if (value >= 0)
                    banKinh = value;
                else
                    throw new ArgumentException("Ban kinh phai >= 0.");
            }
        }

        // Constructor mac dinh
        public DuongTron()
        {
            tam = new Diem();
            banKinh = 0;
        }

        // Constructor co tham so
        public DuongTron(Diem t, int r)
        {
            Tam = t;
            BanKinh = r;
        }

        // Constructor sao chep
        public DuongTron(DuongTron dt)
        {
            Tam = dt.Tam;
            BanKinh = dt.BanKinh;
        }

        // Nhap duong tron
        public void Nhap()
        {
            Console.WriteLine("Nhap tam duong tron:");
            Diem p = new Diem();
            p.Nhap();
            Tam = p;

            Console.Write("Nhap ban kinh: ");
            BanKinh = int.Parse(Console.ReadLine());
        }

        // Xuat duong tron
        public void Xuat()
        {
            Console.WriteLine("Tam: " + Tam
                + ", Ban kinh: " + BanKinh);
        }

        // Tinh dien tich
        public double DienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }

        // Tinh chu vi
        public double ChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        // Kiem tra vi tri tuong doi cua diem
        public string ViTriDiem(Diem p)
        {
            double d = Tam.KhoangCach(p);

            if (d < BanKinh)
                return "Diem nam trong duong tron.";

            if (d == BanKinh)
                return "Diem nam tren duong tron.";

            return "Diem nam ngoai duong tron.";
        }

        // Kiem tra vi tri tuong doi cua hai duong tron
        public string ViTriDuongTron(DuongTron dt)
        {
            double d = Tam.KhoangCach(dt.Tam);
            double tongBanKinh = BanKinh + dt.BanKinh;
            double hieuBanKinh = Math.Abs(BanKinh - dt.BanKinh);

            if (d == 0 && BanKinh == dt.BanKinh)
                return "Hai duong tron trung nhau.";

            if (d > tongBanKinh)
                return "Hai duong tron nam ngoai nhau.";

            if (d == tongBanKinh)
                return "Hai duong tron tiep xuc ngoai.";

            if (d < hieuBanKinh)
                return "Mot duong tron nam trong duong tron kia va khong tiep xuc.";

            if (d == hieuBanKinh)
                return "Hai duong tron tiep xuc trong.";

            return "Hai duong tron cat nhau tai hai diem.";
        }
    }
}
