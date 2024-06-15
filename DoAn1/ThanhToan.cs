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
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;
using System.Globalization;

namespace DoAn1
{
    public partial class ThanhToan : Form
    {
        string kn =global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dtOrder;
        DataTable dtBan;
        List<string> listBan;
        public ThanhToan()
        {
            InitializeComponent();
          


        }
        private void LoadCbx()
        {
            connection = new SqlConnection(kn);
            string select = string.Format("select DISTINCT IDBan from [Order] where TrangThai = 0 ");
            // Load cbx 
            if (select!=null)
            {
                adapter = new SqlDataAdapter(select, connection);
                dtBan = new DataTable();
                adapter.Fill(dtBan);
                cbxBan.DataSource = dtBan;
                cbxBan.DisplayMember = "IDBan";
                cbxBan.ValueMember = "IDBan";
                cbxBan.SelectedIndexChanged += cbxBan_SelectedIndexChanged;
            }
        }
        private void LoadHoaDon()
        {
            string selectHoaDon = string.Format("SELECT [Order].IDOrder , SanPham.TenSanPham, [Order].SoLuong, [Order].Gia,  KhachHang.TenKhachHang  FROM SanPham INNER JOIN [Order] ON SanPham.IDSanPham = [Order].IDSanPham " +
                    " INNER JOIN KhachHang on KhachHang.IDKhachHang = [Order].IDKhachHang where  [Order].TrangThai = 1 ");
            SqlDataAdapter AdapterHoaDon = new SqlDataAdapter( selectHoaDon, connection);
            DataTable dtHoaDon = new DataTable();
            AdapterHoaDon.Fill(dtHoaDon);
            dataGridViewHoaDon.DataSource = dtHoaDon;   

        }

        public void datagrid(string soBan = "")
        {
            string selectMon;
            connection = new SqlConnection(kn);
            
            if (soBan !="")
            {
                selectMon = string.Format("SELECT [Order].IDOrder ,  SanPham.TenSanPham, [Order].SoLuong, [Order].Gia ,[Order].IDBan ,  KhachHang.TenKhachHang  FROM SanPham INNER JOIN [Order] ON SanPham.IDSanPham = [Order].IDSanPham " +
                    " INNER JOIN KhachHang on KhachHang.IDKhachHang = [Order].IDKhachHang where IDBan={0} and [Order].TrangThai = 0 ", soBan);

            }
            else
            {
                selectMon = string.Format("SELECT [Order].IDOrder , SanPham.TenSanPham, [Order].SoLuong, [Order].Gia ,[Order].IDBan , KhachHang.TenKhachHang FROM SanPham INNER JOIN [Order] ON SanPham.IDSanPham = [Order].IDSanPham " +
                    " INNER JOIN KhachHang on KhachHang.IDKhachHang = [Order].IDKhachHang where IDBan={0} and [Order].TrangThai = 0 ", cbxBan.SelectedValue.ToString());
            }
 

            SqlDataAdapter adapterMon = new SqlDataAdapter(selectMon, connection);
            dtOrder = new DataTable();
            adapterMon.Fill(dtOrder);
            dataGridThanhToan.DataSource = dtOrder;
            textGia.Text = TongTien().ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN"));


        }

        private long TongTien()
        {
            long total = 0;
            foreach(DataRow rowOrder in dtOrder.Rows)
            {
                total +=  Int64.Parse(rowOrder["Gia"].ToString());
            }
            return total;
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            LoadCbx();
            LoadHoaDon();
        }

        private void cbxBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)cbxBan.SelectedItem;
            string selectedValue = selectedRow["IDBan"].ToString();
            datagrid(selectedValue);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (btnThanhToan.Text!="")
            {
                string bill = "";
                int CapNhatSoLuong = 0;
                int TongGiaSanPham = 0;
                int CapNhatLaiTongGiaTienBanDuoc = 0;
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Value = DateTime.Now;


                // Duyệt qua từng dòng để in hóa đơn, đồng thời thêm vào bảng Doanh Thu 
                SqlCommand sqlCommand = new SqlCommand();
                foreach (DataRow dr in dtOrder.Rows)
                {
                    // Lấy Giá  Tiền Của Sản Phẩm Tại Dòng 
                    TongGiaSanPham = int.Parse(dr["SoLuong"].ToString()) * int.Parse(dr["Gia"].ToString());                    // thêm Những sản phẩm đã order vào trong doanh thu 
                   
                    // lấy dữ liệu trong doanh thu khi thỏa mãng tenSP và Ngày Bàn 
                    /*string selectDoanhThu = string.Format("select SanPham.TenSanPham , [Order].Gia , [Order].SoLuong from HoaDon inner join [Order] On HoaDon.IDOrder = [Order].IDOrder inner join SanPham on SanPham.IDSanPham= [Order].IDSanPham  where NgayBan ='{0}'",  dateTimePicker.Value.ToString("yyyy-MM-dd"));
                    SqlDataAdapter adapter = new SqlDataAdapter(selectDoanhThu,connection);    
                    DataTable TableHoaDon = new DataTable();  
                    adapter.Fill(TableHoaDon);
                    if (TableHoaDon.Rows.Count > 0)
                    {
                        foreach (DataRow rowDoanhThu in TableHoaDon.Rows)
                        {
                            CapNhatLaiTongGiaTienBanDuoc = TongGiaSanPham + int.Parse(rowDoanhThu["Gia"].ToString());
                            CapNhatSoLuong = int.Parse(dr["SoLuong"].ToString()) + int.Parse(rowDoanhThu["SoLuong"].ToString());
                            string UpdateSoLuong = string.Format("Update HoaDon set SoLuong  = {0} ,  Gia = {1} where  IDOrder ={2} and NgayBan ='{3}' ", CapNhatSoLuong.ToString(), CapNhatLaiTongGiaTienBanDuoc.ToString(), dr["IDOrder"].ToString(), dateTimePicker.Value.ToString("yyyy-MM-dd"));
                            sqlCommand = new SqlCommand(UpdateSoLuong, connection);
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    else
                    {
                        
                    }*/
                    string insert = string.Format("insert into HoaDon(IDOrder,NgayBan) values({0},'{1}')",
                                         dr["IDOrder"].ToString(), dateTimePicker.Value.ToString("yyyy-MM-dd"));
                    sqlCommand = new SqlCommand(insert, connection);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();

                    //Cập Nhật Lại Trạng Thái Đã ThanhToan
                    string UpdateTrangThai = string.Format(" Update [Order] set TrangThai = 1  where IDOrder ={0} ", dr["IDOrder"].ToString());

                    sqlCommand = new SqlCommand(UpdateTrangThai, connection);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();

                    bill += string.Format("Món:" + dr["TenSanPham"].ToString() + ", Số Lương: " + dr["SoLuong"].ToString() + ", Giá: " + dr["Gia"].ToString() + "\n");
                }

                bill += "Tổng Số Tiền:" + textGia.Text;

                MessageBox.Show(bill, string.Format(" Hóa Đơn Bàn Số {0}", cbxBan.Text));


                // Cập Nhật lại trạng thai bàn 
                string Update = string.Format(" Update Ban set TrangThai = 0 where IDBan ={0}", cbxBan.Text);
                sqlCommand = new SqlCommand(Update, connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                ThanhToan_Load(sender, e);
            }
        }

        private void backlink_Click(object sender, EventArgs e)
        {
            ChucNang chucnang = new ChucNang();
            chucnang.Show();
            this.Hide();
        }


        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.doAn1DataSet);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
