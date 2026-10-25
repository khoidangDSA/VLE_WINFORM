namespace WinFormsApp1
{
    partial class FrmNhapLieu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSoDong = new TextBox();
            txtSoCot = new TextBox();
            btnKhoiTao = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 106);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 0;
            label1.Text = "Số dòng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 169);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 1;
            label2.Text = "Số cột:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(189, 37);
            label3.Name = "label3";
            label3.Size = new Size(124, 32);
            label3.TabIndex = 2;
            label3.Text = "Nhập liệu";
            // 
            // txtSoDong
            // 
            txtSoDong.Location = new Point(152, 106);
            txtSoDong.Name = "txtSoDong";
            txtSoDong.Size = new Size(150, 31);
            txtSoDong.TabIndex = 3;
            // 
            // txtSoCot
            // 
            txtSoCot.Location = new Point(152, 166);
            txtSoCot.Name = "txtSoCot";
            txtSoCot.Size = new Size(150, 31);
            txtSoCot.TabIndex = 4;
            // 
            // btnKhoiTao
            // 
            btnKhoiTao.Location = new Point(340, 123);
            btnKhoiTao.Name = "btnKhoiTao";
            btnKhoiTao.Size = new Size(132, 59);
            btnKhoiTao.TabIndex = 5;
            btnKhoiTao.Text = "Khởi tạo ";
            btnKhoiTao.UseVisualStyleBackColor = true;
            btnKhoiTao.Click += btnKhoiTao_Click;
            // 
            // FrmNhapLieu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 279);
            Controls.Add(btnKhoiTao);
            Controls.Add(txtSoCot);
            Controls.Add(txtSoDong);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmNhapLieu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSoDong;
        private TextBox txtSoCot;
        private Button btnKhoiTao;
    }
}
