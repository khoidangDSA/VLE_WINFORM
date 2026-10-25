using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManager
{
    // Đã đổi chữ FrmLop thành frmLop (chữ 'f' thường) cho khớp 100% với Designer
    public partial class frmLop : Form
    {
        // Chuỗi kết nối tới SQL Server Docker trên máy ông
        private string chuoiketnoi = @"Data Source=127.0.0.1,1433;Initial Catalog=DBHocSinh;User ID=sa;Password=YourPassword123!;TrustServerCertificate=True";

        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            // Cấu hình các cột hiển thị cho ListView
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.Columns.Clear();
            lvLop.Columns.Add("Mã Lớp", 100);
            lvLop.Columns.Add("Tên Lớp", 150);
            lvLop.Columns.Add("Sĩ Số", 100);

            // Tải dữ liệu từ SQL lên
            loadDanhSach();
        }

        void loadDanhSach()
        {
            lvLop.Items.Clear();
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Lop", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lvi = new ListViewItem(dr["MaLop"].ToString());
                    lvi.Tag = dr["MaLop"].ToString();
                    lvi.SubItems.Add(dr["TenLop"].ToString());
                    lvi.SubItems.Add(dr["SiSo"].ToString());
                    lvLop.Items.Add(lvi);
                }
            }
        }

        // Sự kiện click chọn 1 dòng trên ListView
        private void lvLop_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                txtMaLop.Text = e.Item.Text;
                txtTenLop.Text = e.Item.SubItems[1].Text;
                txtSiSo.Text = e.Item.SubItems[2].Text;
            }
        }

        // Sự kiện bấm nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string sql = "INSERT INTO Lop(MaLop, TenLop, SiSo) VALUES (@MaLop, @TenLop, @SiSo)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@SiSo", int.Parse(txtSiSo.Text));
                cmd.ExecuteNonQuery();
            }
            loadDanhSach();
        }

        // Sự kiện bấm nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0) return;
            string maLop = lvLop.SelectedItems[0].Tag.ToString();

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string sql = "UPDATE Lop SET TenLop = @TenLop, SiSo = @SiSo WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@SiSo", int.Parse(txtSiSo.Text));
                cmd.ExecuteNonQuery();
            }
            loadDanhSach();
        }

        // Sự kiện bấm nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0) return;
            string maLop = lvLop.SelectedItems[0].Tag.ToString();

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Lop WHERE MaLop = @MaLop", con);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.ExecuteNonQuery();
            }
            loadDanhSach();
        }
    }
}