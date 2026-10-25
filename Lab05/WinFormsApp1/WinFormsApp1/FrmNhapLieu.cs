
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmNhapLieu : Form
    {
        public FrmNhapLieu()
        {
            InitializeComponent();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            int sodong, socot;

            if (!int.TryParse(txtSoDong.Text, out sodong))
                sodong = 1;

            if (!int.TryParse(txtSoCot.Text, out socot))
                socot = 1;

            if (sodong < 1 || socot < 1)
            {
                MessageBox.Show(
                    "Số dòng và số cột phải lớn hơn 0!");
                return;
            }

            FrmXuat frmX = new FrmXuat(sodong, socot);

            frmX.StartPosition =
                FormStartPosition.CenterScreen;

            frmX.ShowDialog();
        }
    }
}
