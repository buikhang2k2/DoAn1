using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DoAn1
{
    public partial class QuanLyNhanVien : Form
    {
        string kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
        SqlDataAdapter SqlDataAdapter;
        SqlConnection connection;
        DataTable dt;
        SqlCommand cmd;
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            connection =new SqlConnection(kn);
            string select = "select * from NhanVien";
            SqlDataAdapter = new SqlDataAdapter(select , connection);
            dt = new DataTable();
            SqlDataAdapter.Fill(dt);

            dataGridNhanVien.DataSource = dt;
            // hiện thị dữ liệu trong từ datagriw 
            if (dataGridNhanVien.Rows.Count > 0)
            {
                NumericUpDown numericUpDown = new NumericUpDown();

                textMaSoNV.Text = dataGridNhanVien.CurrentRow.Cells[0].Value.ToString();
                textTenNhanVien.Text = dataGridNhanVien.CurrentRow.Cells[1].Value.ToString();
                textChucVu.Text = dataGridNhanVien.CurrentRow.Cells[2].Value.ToString();
                textLuong.Text = dataGridNhanVien.CurrentRow.Cells[3].Value.ToString();
                textSDT.Text = dataGridNhanVien.CurrentRow.Cells[4].Value.ToString();

                if (dataGridNhanVien.CurrentRow.Cells[5].Value.ToString() != "")
                {
                    numericSoNgayNghi.Value = int.Parse(dataGridNhanVien.CurrentRow.Cells[5].Value.ToString());
                }
                else
                {
                    numericSoNgayNghi.Value = 0;
                }
                textGhiChu.Text = dataGridNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if(textMaSoNV.Text =="" &&  textTenNhanVien.Text == "" && textChucVu.Text == "" && textLuong.Text == ""  )
            {
                MessageBox.Show("Chưa Nhập Đủ thông Tin Cần Thiết ");
                return;
            }
            string insert = String.Format("insert into NhanVien values('{0}',N'{1}',N'{2}' ,{3} ,'{4}',{5},N'{6}')", textMaSoNV.Text, textTenNhanVien.Text, textChucVu.Text, textLuong.Text, textSDT.Text, int.Parse(numericSoNgayNghi.Value.ToString()), textGhiChu.Text );
          
            cmd = new SqlCommand(insert, connection);
            connection.Open();
            try
            {
                int kq = cmd.ExecuteNonQuery();
                if (kq != 0)
                {
                    MessageBox.Show("Thêm Nhân Viên Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                    QuanLyNhanVien_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi ");

            }
            finally { connection.Close(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(kn);
                string delete = string.Format("delete from NhanVien where MaSoNV = '{0}'", textMaSoNV.Text);
                cmd = new SqlCommand(delete, connection);
                connection.Open();
                try
                {
                    int kq = cmd.ExecuteNonQuery();
                    if (kq != 0)
                    {
                        MessageBox.Show("Xóa Nhân Viên Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                        QuanLyNhanVien_Load(sender, e);
                       
                    }
                    return ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi ");

                }
                finally { connection.Close(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (textMaSoNV.Text == "" && textTenNhanVien.Text == "" && textChucVu.Text == "" && textLuong.Text == "")
            {
                MessageBox.Show("Chưa Nhập Đủ thông Tin Cần Thiết ");
                return;
            }

            string update  = String.Format("update NhanVien set  TenNV = N'{0}' , ChucVu = N'{1}' , Luong = {2} , SDT = '{3}' , SoNgayNghi = {4}, GhiChu =N'{5}' where MaSoNV ='{6}'  ",
                textTenNhanVien.Text, textChucVu.Text, textLuong.Text, textSDT.Text, int.Parse(numericSoNgayNghi.Value.ToString()), textGhiChu.Text, textMaSoNV.Text);
            
            cmd = new SqlCommand(update, connection);
            connection.Open();
            try
            {
                int kq = cmd.ExecuteNonQuery();
                if (kq != 0)
                {
                    MessageBox.Show("Update Nhân Viên Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                    QuanLyNhanVien_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi ");

            }
            finally { connection.Close(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridNhanVien_Click(object sender, EventArgs e)
        {
          
            if (dataGridNhanVien.Rows.Count > 0 )
            {
                NumericUpDown numericUpDown = new NumericUpDown();
                
                textMaSoNV.Text = dataGridNhanVien.CurrentRow.Cells[0].Value.ToString();
                textTenNhanVien.Text = dataGridNhanVien.CurrentRow.Cells[1].Value.ToString();
                textChucVu.Text = dataGridNhanVien.CurrentRow.Cells[2].Value.ToString();
                textLuong.Text = dataGridNhanVien.CurrentRow.Cells[3].Value.ToString();
                textSDT.Text = dataGridNhanVien.CurrentRow.Cells[4].Value.ToString();
                
                if (dataGridNhanVien.CurrentRow.Cells[5].Value.ToString() != "")
                {
                    numericSoNgayNghi.Value = int.Parse(dataGridNhanVien.CurrentRow.Cells[5].Value.ToString());
                }
                else
                {
                    numericSoNgayNghi.Value = 0;
                }
                textGhiChu.Text = dataGridNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
        }
    }
}
