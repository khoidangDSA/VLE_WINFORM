using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            FrmLogin fLogin = new FrmLogin();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                // Khi đăng nhập thành công
                mnuDangNhap.Enabled = false; // Mờ Đăng nhập
                mnuDangXuat.Enabled = true;  // Sáng Đăng xuất
                mnuQuanLy.Enabled = true;    // Sáng Quản lý
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng tất cả các form con (MDI children) đang mở
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Đổi trạng thái menu về ban đầu
            mnuDangNhap.Enabled = true;  // Sáng Đăng nhập
            mnuDangXuat.Enabled = false; // Mờ Đăng xuất
            mnuQuanLy.Enabled = false;   // Mờ Quản lý

            MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
            frmLop fLop = new frmLop();
            fLop.MdiParent = this;
            fLop.Show();
        }

        private void mnuHocSinh_Click(object sender, EventArgs e)
        {
            FrmHocSinh fHS = new FrmHocSinh();
            fHS.MdiParent = this;
            fHS.Show();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}