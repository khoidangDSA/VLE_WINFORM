using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string[] folderFile = null;
        private int selected = 0;
        private int begin = 0;
        private int end = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void nextImage()
        {
            if (selected == end)
            {
                selected = begin;
            }
            else
            {
                selected++;
            }

            showImage(folderFile[selected]);
        }
        private void prevImage()
        {
            if (selected == begin)
            {
                selected = end;
            }
            else
            {
                selected--;
            }

            showImage(folderFile[selected]);
        }
        private void showImage(string path)
        {
            Image imgtemp = Image.FromFile(path);

            pictureBox1.Width = imgtemp.Width / 2;
            pictureBox1.Height = imgtemp.Height / 2;

            pictureBox1.Image = imgtemp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Chọn hình ảnh";
            openFileDialog1.Filter =
                "Image Files|*.jpg;*.jpeg;*.bmp";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                folderFile = openFileDialog1.FileNames;

                selected = 0;
                begin = 0;
                end = folderFile.Length - 1;

                showImage(folderFile[selected]);

                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnStart.Enabled = true;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (folderFile != null && folderFile.Length > 0)
            {
                prevImage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (folderFile != null && folderFile.Length > 0)
            {
                nextImage();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                btnStart.Text = "<< Bắt đầu Slide Show >>";
            }
            else
            {
                if (folderFile == null || folderFile.Length == 0)
                {
                    MessageBox.Show("Vui lòng mở thư mục hình ảnh!");
                    return;
                }

                timer1.Enabled = true;
                btnStart.Text = "<< Kết thúc Slide Show >>";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextImage();
        }
    }
}
