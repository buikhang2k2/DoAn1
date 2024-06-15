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
using System.IO;
using System.Xml.Serialization;
namespace DoAn1
{
    public partial class Order : Form
    {
        public delegate void UpdateDataHandler();
        public event UpdateDataHandler UpdateDataEvent;

        string kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dtDatMon;
        DataTable dtMon;
        Button btnMon, btnBan;
        Label gia;

        int wbtnMon = 120, hbtnMon = 60;
        int xMon, yMon, xGia, yGia;

        int wbtnBan = 60, hbtnBan = 35;
        int xBan, yBan;

        public List<Button> listButton = new List<Button>();
        public List<Label> listLabel = new List<Label>();

        public Order()
        {
            InitializeComponent();
           

        }

       
        private void LoadDataSP(string TimKem = "" )
        {
            panel1.Controls.Clear();
            dtMon = new DataTable();
            dtMon.Rows.Clear();

            connection = new SqlConnection(kn);  
            string selectMon = "Select * from SanPham";

            if ( TimKem!="")
            {
                selectMon = string.Format("Select * from SanPham where TenSanPham Like N'%{0}%'", TimKem);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(selectMon, connection);
            adapter.Fill(dtMon);

            yMon = hbtnMon / 2;
            yGia = yMon + hbtnMon + 2;
            int i = 1;
            // Load Gia tiền  và  Món Ắn 
            foreach (DataRow dr in dtMon.Rows)
            {
                if (i <= dtMon.Rows.Count)
                {

                    gia = new Label();
                    gia.Text = dr["Gia"].ToString(); // Gán Gia tiền 
                    gia.Name = "giaSp" + i.ToString();
                    gia.Font = new Font(gia.Font.FontFamily, 7, FontStyle.Bold);
                    gia.ForeColor = Color.Black;

                    btnMon = new Button();
                    btnMon.Name = "Mon" + i;
                    btnMon.Text = dr["TenSanPham"].ToString();
                    btnMon.Font = new Font(gia.Font.FontFamily, 9, FontStyle.Bold);
                    btnMon.Click += HandleClickButton;
                    btnMon.ForeColor = Color.Red;
                    btnMon.Size = new Size(wbtnMon, hbtnMon);
                    btnMon.TextAlign = ContentAlignment.BottomCenter;
                    btnMon.Padding = new Padding(2);

                    string linkAnh = dr["HinhAnh"].ToString();
                    string fullPath = Path.Combine(Application.StartupPath, @"..\..\asset\", linkAnh);
                    // Trong phương thức khởi tạo của Form hoặc bất kỳ nơi nào trước khi Button được hiển thị  ..\..\asset\"+ Linkanh
                    btnMon.BackgroundImage = Image.FromFile(fullPath);
                    btnMon.BackgroundImageLayout = ImageLayout.Stretch;
                    if (int.Parse(dr["SoLuong"].ToString()) == 0)
                    {
                        gia.Enabled = false;
                        btnMon.Enabled = false;
                        gia.Text = "Hết Hàng ";
                    }
                    if (i % 2 == 0)
                    {

                        xMon = wbtnMon + wbtnMon / 2;
                        btnMon.Location = new Point(xMon, yMon);
                        yMon += hbtnMon + hbtnMon / 2;

                        // xét point cho lable gia
                        xGia = xMon + wbtnMon / 3;
                        gia.Location = new Point(xGia, yGia);
                        yGia = yMon + hbtnMon;
                    }
                    else
                    {
                        xMon = wbtnMon / 2 / 2;
                        btnMon.Location = new Point(xMon, yMon);


                        xGia = xMon + wbtnMon / 3;
                        gia.Location = new Point(xGia, yGia);

                    }
                    i++;
                    panel1.Controls.Add(gia);
                    panel1.Controls.Add(btnMon);
                    listLabel.Add(gia);
                }
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        // Load Bàn và  LoadDataSP();
        public void Order_Load(object sender, EventArgs e)
        {
            LoadDataSP();
            connection = new SqlConnection(kn);
            string select = string.Format("select * from Ban");
            adapter = new SqlDataAdapter(select, connection);
            DataTable dtBan = new DataTable();
            adapter.Fill(dtBan);

            CbxSelectBan.DataSource = dtBan;
            CbxSelectBan.DisplayMember = "IDBan";


            //tạo  vùng lưu trữ các sản phẩm đã order
            dtDatMon = new DataTable();
            dtDatMon.Columns.Add("MonOrder");
            dtDatMon.Columns.Add("Gia");
            dtDatMon.Columns.Add("SoLuong");
            dataGridViewOrder.DataSource = dtDatMon;

            
            int nhanbt = 0;
            yBan = hbtnBan / 2;

            int j = 1;
            foreach (DataRow dr in dtBan.Rows)
            {
                // cấu hình button 
                btnBan = new Button();
                btnBan.Name = dr["IDBan"].ToString();
                btnBan.Text = dr["IDBan"].ToString();
                btnBan.Anchor = AnchorStyles.None;
                btnBan.Size = new Size(wbtnBan, hbtnBan);
                btnBan.ForeColor = Color.Black;
                btnBan.TextAlign = ContentAlignment.MiddleCenter;
                btnBan.Padding = new Padding(2);
                btnBan.Click += btnBan_Click;

                // xét x cho btn 
                xBan = nhanbt * wbtnBan + (wbtnBan / 3);
                btnBan.Location = new Point(xBan, yBan);
                nhanbt++;

                if (j % 4 == 0)
                {
                    yBan = yBan + hbtnBan + hbtnBan / 2;
                    nhanbt = 0;
                }
                panel3.Controls.Add(btnBan);
                listButton.Add(btnBan);
                j++;
            }

            // hiển thị những bàn đã đặt 

            string selectBan = string.Format("select * from Ban");
            SqlDataAdapter sqlAdapterBan = new SqlDataAdapter(selectBan ,connection);
            DataTable TableBan = new DataTable();
            sqlAdapterBan.Fill(TableBan);

            foreach (DataRow dr in TableBan.Rows)
            {
                if (dr["TrangThai"].ToString() == "1")
                {
                    foreach (Button btn in listButton)
                    {
                        if (btn.Name == dr["IDBan"].ToString())
                        {
                            btn.BackColor = Color.Red;
                        }
                    }
                }
            }

            string selectKhach = "Select * from KhachHang";
            SqlDataAdapter adapterKhach = new SqlDataAdapter(selectKhach, connection);
            DataTable TableKhach = new DataTable();
            adapterKhach.Fill(TableKhach);
            cbxKhachHang.DataSource = TableKhach;
            cbxKhachHang.DisplayMember = "TenKhachHang";
            cbxKhachHang.ValueMember = "IDKhachhang";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textSearch.Text))
            {

                LoadDataSP(textSearch.Text);
            }
            else
            {
                LoadDataSP();

            }
        }

        private void btnThemKhachhang_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.FormClosed += khachhang_FormClosed; // Đăng ký sự kiện
            khachhang.Show();
        }
        private void khachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Order_Load(sender,e); // Gọi hàm tải lại dữ liệu
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textSearch.Text))
            {

                LoadDataSP(textSearch.Text);
            }
            else
            {
                LoadDataSP();

            }


        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            CbxSelectBan.Text = clickedButton.Text; 
        }

        private void link_Click(object sender, EventArgs e)
        {
            ChucNang chucnang = new ChucNang();
            chucnang.Show();
            this.Hide();
        }

        private void btnDatMon_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(kn);
            string HoaDon = "";
            if (dtDatMon.Rows.Count <= 0)
            {
                MessageBox.Show("Chưa Đặt Món !!!" , "Thông Báo " , MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }

            if (CbxSelectBan.Text != "")
            {
                foreach (DataRow rowMonDat in dtDatMon.Rows)
                {
                    // Thêm Những dữ liêu đã order vào bảng order
                    HoaDon += string.Format("Món: " + " " + rowMonDat["MonOrder"].ToString() + " " + "  Số Lượng :" + " " + rowMonDat["SoLuong"].ToString() + "Gia: " + rowMonDat["Gia"].ToString() + "\n");
                    foreach (DataRow drSP in dtMon.Rows)
                    {
                        if (drSP["TenSanPham"].ToString() == rowMonDat["MonOrder"].ToString())
                        {                           
                            string selectOrder = string.Format("Select * from [Order] where IDSanPham = {0} and IDBan = {1} and TrangThai = {2} and IDKhachHang ={3}", drSP["IDSanPham"] , CbxSelectBan.Text , 0 ,cbxKhachHang.SelectedValue.ToString());
                            SqlDataAdapter adapter = new SqlDataAdapter(selectOrder , connection);
                            DataTable dtOrder = new DataTable();
                            adapter.Fill(dtOrder);
                            if (dtOrder.Rows.Count > 0)
                            {
                                long capNhatLaiGia = 0;
                                 int capNhatSoLuong = 0;
      
                                foreach (DataRow drOrder in dtOrder.Rows)
                                {
                                    capNhatLaiGia  = Int64.Parse(drOrder["Gia"].ToString()) + Int64.Parse(rowMonDat["Gia"].ToString());
                                    capNhatSoLuong = Int32.Parse(drOrder["SoLuong"].ToString()) + Int32.Parse(rowMonDat["Soluong"].ToString());
                                }
                                // cập nhật lại số lượng món bên order 
                                string updateSLOrder = string.Format("update [Order] set Soluong = {0}  , Gia = {1}   where IDSanPham ={2} and IDBan= {3} and TrangThai = {4} " , capNhatSoLuong , capNhatLaiGia, drSP["IDSanPham"].ToString(), CbxSelectBan.Text , 0);
                                 SqlCommand updateSL  = new SqlCommand(updateSLOrder , connection);
                                connection.Open();
                                updateSL.ExecuteNonQuery();
                                connection.Close();

                            }
                            else
                            {
                                // thêm vào Order 

                                string insert = String.Format("Insert into [Order](IDSanPham,Gia,SoLuong,IDBan,TrangThai ,IDKhachHang) Values({0},{1},{2} ,{3},{4} ,{5})",
                                            drSP["IDSanPham"].ToString(), rowMonDat["Gia"].ToString(), rowMonDat["SoLuong"].ToString().Trim(), CbxSelectBan.Text.Trim(), 0 , cbxKhachHang.SelectedValue.ToString());
                                SqlCommand cmd = new SqlCommand(insert, connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }


                            // Cập  Nhật Lại Số Lượng Món đã Đặt 
                            int CapNhatSoLuong = int.Parse(drSP["SoLuong"].ToString()) - int.Parse(rowMonDat["SoLuong"].ToString());
                            string UpdateSoLuong = string.Format("Update SanPham set SoLuong = {0} where TenSanPham = N'{1}'", CapNhatSoLuong.ToString(), drSP["TenSanPham"].ToString());
                            SqlCommand cmdUpdate = new SqlCommand(UpdateSoLuong, connection);
                            connection.Open();
                            cmdUpdate.ExecuteNonQuery();
                            connection.Close();
                            LoadDataSP();
                        }
                    }

                }
/*                //  Xóa Các Sản Phẩm CÓ Sô Lượng bằng 0 ;
                string Delete = " Delete  from SanPham where SoLuong = 0 ";
                SqlCommand sqlCommandXOA = new SqlCommand(Delete, connection);
                connection.Open();
                sqlCommandXOA.ExecuteNonQuery();
                connection.Close();*/

                // Cập Nhật Lại trạng Thái Bàn 
                string update = string.Format("Update Ban set TrangThai = 1 where IDBan = {0}", CbxSelectBan.Text);
                SqlCommand sqlCommandUpdate = new SqlCommand(update , connection);
                connection.Open();
                sqlCommandUpdate.ExecuteNonQuery();
                connection.Close();
                
                // In Ra Những Món Đã Order
                MessageBox.Show(HoaDon, " Order Thành Công ", MessageBoxButtons.OK);
                dtDatMon.Rows.Clear();

                Order_Load(sender, e);
            }

        }

        private void btnXoa1Mon_Click(object sender, EventArgs e)
        {
            if (dtDatMon.Rows.Count <= 0)
            {
                MessageBox.Show("Chưa có Món để Xóa !!!", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = -1;
            index = dataGridViewOrder.CurrentRow.Index;
            if (index != -1)
            {
                dtDatMon.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Chưa Chọn Mục Muốn Xóa", "Thông Báo");
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if(dtDatMon.Rows.Count == 0)
            {
                MessageBox.Show("Không Có Gì Để Xóa ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dtDatMon.Rows.Clear();
            }
        }
        private void HandleClickButton(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            foreach (DataRow  row in dtDatMon.Rows )
            {
                if (row["MonOrder"].ToString() == clickedButton.Text)
                {
                   foreach(DataRow drMon in dtMon.Rows)
                    {
                        if (drMon["TenSanPham"].ToString() == row["MonOrder"].ToString())
                        {
                            if (int.Parse(row["SoLuong"].ToString())  < int.Parse(drMon["SoLuong"].ToString()) )
                            {
                                row["SoLuong"] = int.Parse(row["SoLuong"].ToString()) + 1;
                                row["Gia"] = Int64.Parse(row["Gia"].ToString()) + Int64.Parse(drMon["Gia"].ToString());
                                return;
                            }
                            MessageBox.Show("Món :" + row["MonOrder"].ToString() + "Đã Chọn Tối Đa Không Thể Chọn Được Nữa ,Vui Lòng Chọn Món Khác  " , "Thông Báo" , MessageBoxButtons.OK);
                            return;
                        }

                    }
                }

            }
            DataRow dr = dtDatMon.NewRow();
            dr["MonOrder"] = clickedButton.Text;
            dr["SoLuong"] = 1;
            foreach(Label lb in listLabel)
            {
                if (lb.Name.EndsWith(clickedButton.Name[clickedButton.Name.Length-1].ToString()))
                {
                    dr["Gia"] = lb.Text;
                }
            }

            dtDatMon.Rows.Add(dr);

        }


    }
}
