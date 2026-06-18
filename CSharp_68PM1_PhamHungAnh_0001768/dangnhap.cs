using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_68PM1_PhamHungAnh_0001768
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            string emailSinhVien = "anh0001768@st.huce.edu.vn";
            string mssv = "0001768";

            if (tenDangNhap == emailSinhVien && matKhau == mssv)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin từ TextBox
            string taiKhoan = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // 2. Kiểm tra thông tin (Ví dụ: admin/123)
            if (taiKhoan == "email@sinhvien.vn" && matKhau == "mssv123")
            {
                MessageBox.Show("Đăng nhập thành công!");

                // 3. CHUYỂN FORM:
                // Khởi tạo đối tượng Form2
                Form2 f2 = new Form2();

                // Hiển thị Form2
                f2.Show();

                // Ẩn Form hiện tại (Form1) đi
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác!");
            }
        }

        private static object GetDebuggerDisplay()
        {
            throw new NotImplementedException();
        }
    }
}