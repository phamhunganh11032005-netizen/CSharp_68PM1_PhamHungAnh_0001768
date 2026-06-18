using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSharp_68PM1_PhamHungAnh_0001768
{
    public partial class UC_QLLop : UserControl
    {
        private string strConnect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLSV;Integrated Security=True;TrustServerCertificate=True";

        public UC_QLLop()
        {
            InitializeComponent();
        }

        private void UC_QLLop_Load(object sender, EventArgs e)
        {
            LoadDanhSachLopHoc();
        }

        public void LoadDanhSachLopHoc()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop, GhiChu FROM LopHoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLopHoc.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi load: " + ex.Message); }
            }
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];
                txtMaLop.Text = row.Cells[0].Value.ToString();
                txtTenLop.Text = row.Cells[1].Value.ToString();
                txtGhiChu.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    conn.Open();
                    // Kiểm tra trùng khóa chính
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM LopHoc WHERE MaLop = @MaLop", conn);
                    checkCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    if ((int)checkCmd.ExecuteScalar() > 0) { MessageBox.Show("Mã lớp đã tồn tại!"); return; }

                    SqlCommand cmd = new SqlCommand("INSERT INTO LopHoc (MaLop, TenLop, GhiChu) VALUES (@MaLop, @TenLop, @GhiChu)", conn);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadDanhSachLopHoc();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE LopHoc SET TenLop = @TenLop, GhiChu = @GhiChu WHERE MaLop = @MaLop", conn);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadDanhSachLopHoc();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM LopHoc WHERE MaLop = @MaLop", conn);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadDanhSachLopHoc();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear(); txtTenLop.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
            LoadDanhSachLopHoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaLop, TenLop, GhiChu FROM LopHoc WHERE MaLop LIKE @Key OR TenLop LIKE @Key", conn);
                    da.SelectCommand.Parameters.AddWithValue("@Key", "%" + txtTimKiem.Text.Trim() + "%");
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dgvLopHoc.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm: " + ex.Message); }
        }

        private void btnXemDSSV_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow != null)
            {
                string maLop = dgvLopHoc.CurrentRow.Cells[0].Value.ToString();
                MainForm main = this.FindForm() as MainForm;
                if (main != null)
                {
                    main.tabControl1.SelectedTab = main.tabQLSinhVien;
                    main.uC_QLSV1.LoadSinhVienTheoLop(maLop);
                }
            }
        }
    }
}