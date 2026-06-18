namespace CSharp_68PM1_PhamHungAnh_0001768
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQLSinhVien = new System.Windows.Forms.TabPage();
            this.tabQLLopHoc = new System.Windows.Forms.TabPage();
            this.uC_QLSV1 = new CSharp_68PM1_PhamHungAnh_0001768.UC_QLSV();
            this.uC_QLLop1 = new CSharp_68PM1_PhamHungAnh_0001768.UC_QLLop();
            this.tabControl1.SuspendLayout();
            this.tabQLSinhVien.SuspendLayout();
            this.tabQLLopHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabQLSinhVien);
            this.tabControl1.Controls.Add(this.tabQLLopHoc);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1192, 663);
            this.tabControl1.TabIndex = 0;
            // 
            // tabQLSinhVien
            // 
            this.tabQLSinhVien.Controls.Add(this.uC_QLSV1);
            this.tabQLSinhVien.Location = new System.Drawing.Point(4, 25);
            this.tabQLSinhVien.Name = "tabQLSinhVien";
            this.tabQLSinhVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLSinhVien.Size = new System.Drawing.Size(1184, 634);
            this.tabQLSinhVien.TabIndex = 0;
            this.tabQLSinhVien.Text = "tabPage1";
            this.tabQLSinhVien.UseVisualStyleBackColor = true;
            this.tabQLSinhVien.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabQLLopHoc
            // 
            this.tabQLLopHoc.Controls.Add(this.uC_QLLop1);
            this.tabQLLopHoc.Location = new System.Drawing.Point(4, 25);
            this.tabQLLopHoc.Name = "tabQLLopHoc";
            this.tabQLLopHoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLLopHoc.Size = new System.Drawing.Size(1168, 610);
            this.tabQLLopHoc.TabIndex = 1;
            this.tabQLLopHoc.Text = "tabPage2";
            this.tabQLLopHoc.UseVisualStyleBackColor = true;
            // 
            // uC_QLSV1
            // 
            this.uC_QLSV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_QLSV1.Location = new System.Drawing.Point(3, 3);
            this.uC_QLSV1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_QLSV1.Name = "uC_QLSV1";
            this.uC_QLSV1.Size = new System.Drawing.Size(1178, 628);
            this.uC_QLSV1.TabIndex = 0;
            // 
            // uC_QLLop1
            // 
            this.uC_QLLop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_QLLop1.Location = new System.Drawing.Point(3, 3);
            this.uC_QLLop1.Name = "uC_QLLop1";
            this.uC_QLLop1.Size = new System.Drawing.Size(1162, 604);
            this.uC_QLLop1.TabIndex = 0;
            this.uC_QLLop1.Load += new System.EventHandler(this.uC_QLLop1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 663);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabQLSinhVien.ResumeLayout(false);
            this.tabQLLopHoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Đã sửa thành public để các UserControl có thể truy cập
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabQLSinhVien;
        public System.Windows.Forms.TabPage tabQLLopHoc;
        public UC_QLSV uC_QLSV1;
        public UC_QLLop uC_QLLop1;
    }
}