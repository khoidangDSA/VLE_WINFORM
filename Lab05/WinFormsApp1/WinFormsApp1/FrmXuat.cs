
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
namespace WinFormsApp1
{
    public partial class FrmXuat : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(
    DesignerSerializationVisibility.Hidden)]
        public int SoDong { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        public int SoCot { get; set; }

        int h = 35, margin = 5;

        public FrmXuat(int dong = 1, int cot = 1)
        {
            InitializeComponent();

            SoDong = dong;
            SoCot = cot;
            int count = 1; // Biến đếm tăng dần từ 1
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    TextBox txt = new TextBox();

                    // 1. TĂNG CHIỀU RỘNG Ô (để hiện đủ 2-3 chữ số không bị mất đuôi)
                    txt.Width = 45;
                    txt.Height = 30;

                    // 2. Căn giữa chữ cho đẹp (tùy chọn)
                    txt.TextAlign = HorizontalAlignment.Center;

                    // 3. Gán giá trị tăng dần
                    txt.Text = count.ToString();

                    // 4. Tính vị trí X, Y (Cộng thêm khoảng cách giữa các ô)
                    txt.Left = j * (txt.Width + 8) + 15;
                    txt.Top = i * (txt.Height + 8) + 15;

                    // Thêm vào Form (hoặc Panel)
                    this.Controls.Add(txt);

                    count++; // Tăng biến đếm lên 2, 3, 4...
                }

                this.ClientSize = new Size(
                SoCot * (h + margin + 1),
                SoDong * (h + margin + 1));
            }
        }

        private void HoChuotLenButton(object sender, EventArgs e)
        {
            this.Text = (sender as Button).Tag.ToString();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Text);
        }
    }
}
