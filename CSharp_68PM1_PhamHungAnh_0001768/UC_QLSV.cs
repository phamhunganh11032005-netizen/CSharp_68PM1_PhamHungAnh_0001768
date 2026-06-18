using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSharp_68PM1_PhamHungAnh_0001768
{
    public partial class UC_QLSV : UserControl
    {
        private string strConnect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLSV;Integrated Security=True;TrustServerCertificate=True";

        public UC_QLSV()
        {
            InitializeComponent();
            this.Load += new EventHandler(UC_QLSV_Load);
            this.dgvSinhVien.CellClick += new DataGridViewCellEventHandler(dgvSinhVien_CellClick);
        }

        private void UC_QLSV_Load(object sender, EventArgs e)
        {
            LoadDanhSachHocSinh();
            LoadGioiTinhCBX();
            LoadLopVaoComboBox(); // Nạp danh sách lớp từ bảng LopHoc
        }

        private void LoadLopVaoComboBox()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop FROM LopHoc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLop.DataSource = dt;
                    cboLop.DisplayMember = "MaLop";
                    cboLop.ValueMember = "MaLop";
                    cboLop.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp danh sách lớp: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachHocSinh()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaSV, HoTen, GioiTinh, Lop, QueQuan FROM SinhVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSinhVien.AutoGenerateColumns = false;
                    dgvSinhVien.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy danh sách học sinh: " + ex.Message);
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value?.ToString(); // MaSV
                textBox2.Text = row.Cells[1].Value?.ToString(); // HoTen

                if (comboBox2.Items.Contains(row.Cells[2].Value?.ToString()))
                    comboBox2.SelectedItem = row.Cells[2].Value?.ToString();

                // --- SỬA ĐOẠN NÀY ĐỂ TRÁNH LỖI ---
                string maLop = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(maLop))
                {
                    // Kiểm tra xem giá trị này có trong danh sách không trước khi gán
                    if (cboLop.Items.Count > 0)
                    {
                        cboLop.SelectedValue = maLop;
                    }
                }
                else
                {
                    cboLop.SelectedIndex = -1; // Nếu lớp bị null thì bỏ chọn
                }
            }
        }

        private void LoadGioiTinhCBX()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Nam");
            comboBox2.Items.Add("Nữ");
        }

        private void button1_Click(object sender, EventArgs e) // Nút Thêm
        {
            if (string.IsNullOrEmpty(textBox1.Text) || cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập Mã SV và chọn Lớp!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, Lop, QueQuan) VALUES (@MaSV, @HoTen, @GioiTinh, @Lop, @QueQuan)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSV", textBox1.Text);
                    cmd.Parameters.AddWithValue("@HoTen", textBox2.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Lop", cboLop.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@QueQuan", "Chưa nhập");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadDanhSachHocSinh();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void Sửa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE SinhVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, Lop = @Lop WHERE MaSV = @MaSV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSV", textBox1.Text);
                    cmd.Parameters.AddWithValue("@HoTen", textBox2.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Lop", cboLop.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDanhSachHocSinh();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Nút Xóa
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSV = @MaSV", conn);
                    cmd.Parameters.AddWithValue("@MaSV", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhSachHocSinh();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void button4_Click(object sender, EventArgs e) // Nút Làm mới
        {
            textBox1.Clear();
            textBox2.Clear();
            cboLop.SelectedIndex = -1;
            LoadDanhSachHocSinh();
        }
        public void LoadSinhVienTheoLop(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    // Lọc sinh viên theo MaLop truyền vào từ bên ngoài
                    string query = "SELECT MaSV, HoTen, GioiTinh, Lop, QueQuan FROM SinhVien WHERE Lop = @Lop";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Lop", maLop);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSinhVien.AutoGenerateColumns = false;
                    dgvSinhVien.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lọc danh sách sinh viên: " + ex.Message);
                }
            }
        }
    }
}