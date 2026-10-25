using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmHocSinh : Form
    {
        private string chuoiketnoi = @"Data Source=127.0.0.1,1433;Initial Catalog=DBHocSinh;User ID=sa;Password=YourPassword123!;TrustServerCertificate=True";

        public FrmHocSinh()
        {
            InitializeComponent();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            lvHocSinh.View = View.Details;
            lvHocSinh.FullRowSelect = true;
            lvHocSinh.Columns.Clear();
            lvHocSinh.Columns.Add("Mã HS", 80);
            lvHocSinh.Columns.Add("Họ Tên", 150);
            lvHocSinh.Columns.Add("Ngày Sinh", 100);
            lvHocSinh.Columns.Add("Phái", 60);
            lvHocSinh.Columns.Add("Mã Lớp", 80);

            if (cboPhai.Items.Count > 0)
                cboPhai.SelectedIndex = 0;

            loadDanhSachHS();
        }

        void loadDanhSachHS()
        {
            lvHocSinh.Items.Clear();
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HocSinh", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lvi = new ListViewItem(dr["MaHS"].ToString());
                    lvi.Tag = dr["MaHS"].ToString();
                    lvi.SubItems.Add(dr["HoTen"].ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(dr["NgaySinh"]).ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(dr["Phai"].ToString());
                    lvi.SubItems.Add(dr["MaLop"].ToString());
                    lvHocSinh.Items.Add(lvi);
                }
            }
        }

        private void lvHocSinh_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                txtMaHS.Text = e.Item.Text;
                txtHoTen.Text = e.Item.SubItems[1].Text;
                if (DateTime.TryParseExact(e.Item.SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgaySinh.Value = dt;
                }
                cboPhai.Text = e.Item.SubItems[3].Text;
                txtMaLop.Text = e.Item.SubItems[4].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string sql = "INSERT INTO HocSinh(MaHS, HoTen, NgaySinh, Phai, MaLop) VALUES (@MaHS, @HoTen, @NgaySinh, @Phai, @MaLop)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
                cmd.Parameters.AddWithValue("@Phai", cboPhai.Text);
                cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                cmd.ExecuteNonQuery();
            }
            loadDanhSachHS();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0) return;
            string maHS = lvHocSinh.SelectedItems[0].Tag.ToString();

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string sql = "UPDATE HocSinh SET HoTen=@HoTen, NgaySinh=@NgaySinh, Phai=@Phai, MaLop=@MaLop WHERE MaHS=@MaHS";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaHS", maHS);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
                cmd.Parameters.AddWithValue("@Phai", dtpNgaySinh.Value.Date);
                cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                cmd.ExecuteNonQuery();
            }
            loadDanhSachHS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0) return;
            string maHS = lvHocSinh.SelectedItems[0].Tag.ToString();

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM HocSinh WHERE MaHS = @MaHS", con);
                cmd.Parameters.AddWithValue("@MaHS", maHS);
                cmd.ExecuteNonQuery();
            }
            loadDanhSachHS();
        }
    }
}