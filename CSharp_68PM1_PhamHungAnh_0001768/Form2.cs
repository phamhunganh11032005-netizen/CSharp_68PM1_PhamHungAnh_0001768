using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_68PM1_PhamHungAnh_0001768
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Tự động nạp giao diện Sinh viên (UC_QLSV) ngay khi vừa mở Form2 lên
            UC_QLSV ucSinhVien = new UC_QLSV();
            ShowUserControl(ucSinhVien);
        }

        // Sự kiện khi bấm vào menu "Quản lý Sinh viên" trên thanh công cụ
        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_QLSV ucSinhVien = new UC_QLSV();
            ShowUserControl(ucSinhVien);
        }

        // Sự kiện khi bấm vào menu "Quản lý Lớp học" trên thanh công cụ
        private void quảnLýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_QLLop ucLop = new UC_QLLop();
            ShowUserControl(ucLop);
        }

        // Sự kiện khi bấm vào nút "Đăng xuất"
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Đóng Form2 lại để quay về hoặc thoát chương trình
                this.Close();
            }
        }

        // Hàm bổ trợ: Xóa vùng hiển thị cũ và nạp giao diện con mới vào panelContent
        private void ShowUserControl(UserControl uc)
        {
            // Xóa sạch các giao diện cũ đang chạy trong Panel để tránh chồng chéo dữ liệu
            panelContent.Controls.Clear();

            // Ép giao diện con giãn nở vừa khít với toàn bộ khung chứa
            uc.Dock = DockStyle.Fill;

            // Thêm giao diện con vào khung chứa và đẩy lên trên cùng
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Để trống nếu không xử lý gì khi Form2 load
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}