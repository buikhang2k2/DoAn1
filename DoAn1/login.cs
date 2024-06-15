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
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace DoAn1
{
    public partial class login : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapterTK;
        SqlDataAdapter adapterTKMK;
        DataTable dtTk ;
        DataTable dtTkMK;
        SqlCommand command;



         
        string kn;
        string valueTenDangNhap = "";
        string valueMatKhau = "";
        string valueSDT = "";


        public int k = 0; 

        public login()
        {
            InitializeComponent();
        }

        

        private void login_Load(object sender, EventArgs e)
        {
            tbxTenDangNhap.Focus();
            btnDangky2.Enabled = false;
            btnDangky2.Visible = false;

            lbEmail.Enabled = false;
            lbEmail.Visible = false;

            tbxSDT.Visible = false;
            tbxSDT.Enabled = false;

            btnDangNhap.Enabled = true;
            btnDangNhap.Visible = true;

            btnDangKy.Enabled = true;
            btnDangKy.Visible = true;

            lbErr.Visible = true;
            lbErr.Enabled = true;
            lbNotice.Text = "";

            DangNhapShow.Enabled = false;
            DangNhapShow.Visible = false;

            kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString; 
            connection = new SqlConnection(kn);

        }

        private void tbxTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            string valueName = tbxTenDangNhap.Text;
            if (valueName.StartsWith(" "))
            {
                tbxTenDangNhap.Text = "";
            }
            
        }

        private void tbxMatKhau_TextChanged(object sender, EventArgs e)
        {
            string valueMatKhau = tbxMatKhau.Text;
            if (valueMatKhau.StartsWith(" "))
            {
                tbxMatKhau.Text = "";
            }
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            string valueEmail = tbxSDT.Text;
            if (valueEmail.StartsWith(" "))
            {
                tbxSDT.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            login_Load(sender, e);
        }



      



        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (panel1.Dock == DockStyle.Left)
            {
                panel1.Dock = DockStyle.Right;

            }
            else
            {
                panel1.Dock = DockStyle.Left;
            }


            btnDangNhap.Enabled = false;
            btnDangNhap.Visible = false;

            btnDangKy.Enabled = false;
            btnDangKy.Visible = false;

            lbErr.Visible = false;
            lbErr.Enabled = false;

            btnDangky2.Enabled = true;
            btnDangky2.Visible = true;

            lbEmail.Enabled = true;
            lbEmail.Visible = true;

            tbxSDT.Visible = true;
            tbxSDT.Enabled = true;
             
            DangNhapShow.Enabled = true;
            DangNhapShow.Visible = true;
           
        }

        private void btnDangky2_Click_1(object sender, EventArgs e)
        {
            valueTenDangNhap = tbxTenDangNhap.Text;
            valueMatKhau = tbxMatKhau.Text;
            valueSDT = tbxSDT.Text;
            if (valueTenDangNhap == "" || valueMatKhau == "" || valueSDT == "")
            {
                lbNotice.Text = "Chưa Nhập Đầy Đủ";
                return;
            }
            string selectTkOld = String.Format("select * from LogUP where SDT = '{0}' ", valueSDT);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectTkOld,connection);   
            DataTable dt = new DataTable();
            dt.Clear();
            sqlDataAdapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                lbNotice.Text = "";
                string upadteTk = string.Format("Update LogUP set TenDangNhap ='{0}' , MatKhau = '{1}' where Email = '{2}'", valueTenDangNhap, valueMatKhau, valueSDT);
                command = new SqlCommand(upadteTk, connection);
                connection.Open();
                int kq = command.ExecuteNonQuery();
                if(kq != 0)
                {
                    MessageBox.Show("Đăng Kí Thành Công!!!");
                    tbxTenDangNhap.Text = "";
                    tbxMatKhau.Text = "";
                    tbxSDT.Text = "";
                    
                }
                connection.Close();
                return;
            }
            else
            {
                string insert = string.Format("insert into LogUP(TenDangNhap, MatKhau , SDT , LoaiTK) values('{0}','{1}','{2}' , {3})", valueTenDangNhap, valueMatKhau, valueSDT, 0);

                lbNotice.Text = "";
                command = new SqlCommand(insert, connection);
                connection.Open();

                try
                {
                    int kq = command.ExecuteNonQuery(); // dùng để sử lý câu lệnh sql cập nhật thông tin
                    if (kq != 0)
                    {
                        MessageBox.Show("Đăng Kí Thành Công!!!");
                        tbxTenDangNhap.Text = "";
                        tbxMatKhau.Text = "";
                        tbxSDT.Text = "";
                        login_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đăng Kí Thất Bại !!");
                }
                finally
                {
                    connection.Close();
                }
            }


           



        }

        private void tbxTenDangNhap_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            valueTenDangNhap = tbxTenDangNhap.Text;
            valueMatKhau = tbxMatKhau.Text;
            string select = string.Format("select * from LogUP where TenDangNhap = '{0}'", valueTenDangNhap);
            string selectTKMK = string.Format(" select * from LogUP where TenDangNhap = '{0}' and MatKhau = '{1}'", valueTenDangNhap, valueMatKhau);
            adapterTK = new SqlDataAdapter(select, connection);
            dtTk = new DataTable();
            adapterTK.Fill(dtTk);

            adapterTKMK = new SqlDataAdapter(selectTKMK, connection);
            dtTkMK = new DataTable();
            adapterTKMK.Fill(dtTkMK);

            // kiểm tra tên đăng nhập 
            if (valueTenDangNhap != "")
            {
                lbErr.Text = "";
                if (dtTk != null && dtTk.Rows.Count > 0)
                {
                    if (dtTkMK != null && dtTkMK.Rows.Count > 0)
                    {
                        ChucNang chucnang = new ChucNang();
                        foreach (DataRow dr in dtTkMK.Rows)
                        {
                            chucnang.kt = int.Parse(dr["LoaiTK"].ToString());
                        }
                        this.Hide();
                        chucnang.Show();
                    }
                    else
                    {
                        lbErr.Text = "Mật Khẩu Sai";
                    }
                }
                else
                {
                    lbErr.Text = "Tài Khoản Không Tồn Tại";
                }

            }
            else
            {
                lbErr.Text = "Lỗi Đăng Nhập ";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DangNhapShow_Click(object sender, EventArgs e)
        {
            login_Load(sender, e);
            if (panel1.Dock == DockStyle.Left )
            {
                panel1.Dock = DockStyle.Right;

            }
            else
            {
                panel1.Dock = DockStyle.Left;
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("ban co muon thoat ", "thon bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbxMatKhau.PasswordChar = '\0';
            }
            else
            {
                tbxMatKhau.PasswordChar = '*';
            }
        }

        private void tbxTenDangNhap_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
