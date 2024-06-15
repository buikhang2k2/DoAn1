using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DoAn1
{
    
    public partial class QuanLySanPham : Form
    {
        SqlConnection connection;
        SqlDataAdapter adaptercbx , adapter;
        DataSet  ds;
        DataTable DT;
        string kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
        string valueHInhAnh = "";
        int valueCheck;
        string vitri;
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(kn);

            adaptercbx = new SqlDataAdapter("Select * from LoaiSanPham  ", connection);
            DT = new DataTable();
            adaptercbx.Fill(DT);
            // load dữ liệu vào cbx 

            string select = string.Format("SELECT * FROM SanPham ");
            adapter = new SqlDataAdapter(select, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            sanPhamDataGridView.DataSource = ds.Tables[0];


            // hiển thị gía trị vào các textbox
            vitri = sanPhamDataGridView.CurrentCell.RowIndex.ToString(); // vị trí của ô trong dòng

            DataRow row = ds.Tables[0].Rows[int.Parse(vitri)];
            textIDSanPham.Text = row["IDSanPham"].ToString();
            TextNameSP.Text = row["TenSanPham"].ToString();
            valueHInhAnh = row["HinhAnh"].ToString();
            btnPicture.Image = Image.FromFile(row["HinhAnh"].ToString());
            TextGia.Text = row["Gia"].ToString();
            TextSoLuong.Text = row["SoLuong"].ToString();
            DateTime dateTime = DateTime.Parse(row["NgayNhap"].ToString());
            TextNgay.Text = dateTime.ToString("yyyy-MM-dd");
            TextThanhPhan.Text = row["ThanhPhan"].ToString();
            string check = row["IDLoaiSP"].ToString();
            if (check == "1")
            {
                radioCafe.Checked = true;
            }
            if (check == "2")
            {
                radioNuoc.Checked = true;
            }
            if (check == "3")
            {
                radioBanh.Checked = true;
            }

        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                btnPicture.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
                valueHInhAnh = open.FileName;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(kn);

            if (radioCafe.Checked)
            {
                valueCheck = 1;
            }
            if (radioNuoc.Checked)
            {
                valueCheck = 2;
            }
            if (radioBanh.Checked)
            {
                valueCheck = 3;
            }
            if (TextNgay.Text == "")
            {
                DateTime dateTime = DateTime.Now;
                TextNgay.Text = dateTime.ToShortDateString();
                MessageBox.Show(TextNgay.Text);
            }



            string insert = string.Format("Insert into [SanPham](TenSanPham,HinhAnh,Gia,SoLuong,NgayNhap,ThanhPhan,IDLoaiSP) values(N'{0}',N'{1}',{2},{3},'{4}',N'{5}',{6})",
                            TextNameSP.Text.Trim(), valueHInhAnh.Trim(), TextGia.Text.Trim(), TextSoLuong.Text.Trim(), TextNgay.Text.Trim(), TextThanhPhan.Text.Trim(), valueCheck).Trim();

            if (TextNameSP.Text == "" || valueHInhAnh == "" || TextGia.Text == "" || TextSoLuong.Text == "" || TextNgay.Text == "" || TextThanhPhan.Text == "")
            {
                MessageBox.Show("Chưa Nhập Đầy Đủ Thông Tin ");
                return;
            }


            try
            {
                connection.Open();
                SqlCommand cmdThem = new SqlCommand(insert, connection);
                int kq = cmdThem.ExecuteNonQuery();
                if (kq != 0)
                {
                    MessageBox.Show("Thêm Thành Công !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QuanLySanPham_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi ");
            }
            finally { connection.Close(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(kn);
            string delete = string.Format("delete from SanPham where IDSanPham={0}", textIDSanPham.Text);

            connection.Open();
            SqlCommand cmdXoa = new SqlCommand(delete, connection);

            try
            {
                int kq = cmdXoa.ExecuteNonQuery();
                if (kq != 0)
                {
                    MessageBox.Show("Xóa Thành Công !!!");
                    QuanLySanPham_Load(sender, e);
                    
                }
                return ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Xóa Không Thành Công!!", "Thông báo", MessageBoxButtons.OK);
            }
            finally
            {
                connection.Close();
            }
        }

        private void radioCafe_CheckedChanged(object sender, EventArgs e)
        {
            valueCheck = 1;
        }

        private void radioNuoc_CheckedChanged(object sender, EventArgs e)
        {
            valueCheck = 2;
        }

        private void radioBanh_CheckedChanged(object sender, EventArgs e)
        {
            valueCheck = 3;
        }

        private void sanPhamDataGridView_SelectionChanged_1(object sender, EventArgs e)
        {
            
            
        }

        private void sanPhamDataGridView_Click(object sender, EventArgs e)
        {
            vitri = sanPhamDataGridView.CurrentCell.RowIndex.ToString(); // vị trí của ô trong dòng

            if (int.Parse(vitri) < sanPhamDataGridView.Rows.Count)
            {
                DataRow row = ds.Tables[0].Rows[int.Parse(vitri)];
                textIDSanPham.Text = row["IDSanPham"].ToString();
                TextNameSP.Text = row["TenSanPham"].ToString();
                valueHInhAnh = row["HinhAnh"].ToString();
                btnPicture.Image = Image.FromFile(row["HinhAnh"].ToString());
                TextGia.Text = row["Gia"].ToString();
                TextSoLuong.Text = row["SoLuong"].ToString();
                DateTime dateTime = DateTime.Parse(row["NgayNhap"].ToString());
                TextNgay.Text = dateTime.ToString("yyyy-MM-dd");
                TextThanhPhan.Text = row["ThanhPhan"].ToString();
                string check = row["IDLoaiSP"].ToString();
                if (check == "1")
                {
                    radioCafe.Checked = true;
                }
                if (check == "2")
                {
                    radioNuoc.Checked = true;
                }
                if (check == "3")
                {
                    radioBanh.Checked = true;
                }
            }

            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (radioCafe.Checked)
            {
                valueCheck = 1;
            }
            if (radioNuoc.Checked)
            {
                valueCheck = 2;
            }
            if (radioBanh.Checked)
            {
                valueCheck = 3;
            }
            if (TextNameSP.Text == "" || valueHInhAnh == "" || TextGia.Text == "" || TextSoLuong.Text == "" || TextNgay.Text == "" || TextThanhPhan.Text == "")
            {
                MessageBox.Show("Chưa Nhập Đầy Đủ ");

            }
            else
            {

                string Update = String.Format("Update [SanPham]  Set TenSanPham =N'{0}', HinhAnh =N'{1}' , Gia='{2}' , SoLuong = {3} , NgayNhap = '{4}' , ThanhPhan= N'{5}', IDLoaiSP = {6}  where IDSanPham = {7} ",
                                            TextNameSP.Text.Trim(), valueHInhAnh.Trim(), TextGia.Text.Trim(), TextSoLuong.Text.Trim(), TextNgay.Text.Trim(), TextThanhPhan.Text.Trim(), valueCheck.ToString(), textIDSanPham.Text.Trim());

                connection = new SqlConnection(kn);
                SqlCommand cmdSua = new SqlCommand(Update, connection);
                connection.Open();
                try
                {


                    int kq = cmdSua.ExecuteNonQuery();
                    if (kq != 0)
                    {
                        MessageBox.Show("Đã Cập Nhật Lại Thành Công ");
                        QuanLySanPham_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Cập Nhật!!");
                }
                finally { connection.Close(); }
            }


        }

       
    }
}
