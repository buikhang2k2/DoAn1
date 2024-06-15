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
    public partial class KhachHang : Form
    {
        DataTable dt;
        SqlConnection Connection;
        
        int vitri = -1; 
        public KhachHang()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(KhachHang_FormClosed);
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            string kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
            Connection = new SqlConnection(kn);
            dt = new DataTable();
            string select = "select * from KhachHang";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(select, Connection);
            sqlDataAdapter.Fill(dt);
            dataGridViewKhachHang.DataSource = dt;

            if (dataGridViewKhachHang.Rows.Count > 0)
            {
                textTenKhachHang.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
                textSDT.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
            }
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            string them = string.Format("insert into KhachHang(TenKhachHang,SDT) values (N'{0}','{1}' )" , textTenKhachHang.Text, textSDT.Text );
            
            try
            {
                SqlCommand sqlCommand = new SqlCommand(them, Connection);
                Connection.Open();
                int vitri = sqlCommand.ExecuteNonQuery();
                if(vitri != -1)
                {
                    MessageBox.Show("Thêm Thành Công !");
                    KhachHang_Load(sender, e);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Lỗi");
            }
            finally 
            { 
                Connection.Close(); 
            } 




        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Xoa = string.Format("Delete from KhachHang where IDKhachHang = {0} " , dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString());
            try
            {
                SqlCommand sqlCommandXoa = new SqlCommand(Xoa, Connection);
                Connection.Open();
                int vitri = sqlCommandXoa.ExecuteNonQuery();
                if (vitri != -1)
                {
                    MessageBox.Show("Xóa Thành Công !");
                    KhachHang_Load(sender, e);
                   
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            finally 
            { 
                Connection.Close(); 
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void KhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dataGridViewKhachHang_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.Rows.Count > 0)
            {
                textTenKhachHang.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
                textSDT.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
