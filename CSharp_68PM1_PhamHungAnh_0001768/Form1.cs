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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Được gọi khi Form đăng nhập hiển thị lên, để trống nếu không xử lý gì
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ các ô TextBox người dùng nhập vào
            string tenDangNhap = textBox1.Text.Trim();
            string matKhau = textBox2.Text.Trim();

            // 2. Thông tin tài khoản chuẩn theo mã số sinh viên của bạn
            string emailSinhVien = "anh0001768@st.huce.edu.vn";
            string mssv = "0001768";

            // 3. Kiểm tra điều kiện tài khoản và mật khẩu
            if (tenDangNhap == emailSinhVien && matKhau == mssv)
            {
                // Hiển thị thông báo thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Khởi tạo và hiển thị màn hình chính (Form2)
                Form2 f2 = new Form2();
                f2.Show();

                // Ẩn màn hình đăng nhập hiện tại đi
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo thất bại nếu nhập sai tài khoản hoặc mật khẩu
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không chính xác!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Trỏ con trỏ chuột về ô mật khẩu và bôi đen để người dùng nhập lại nhanh hơn
                textBox2.Clear();
                textBox2.Focus();
            }
        }
    }
}