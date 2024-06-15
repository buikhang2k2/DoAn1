using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class DoanhThu : Form
    {
        SqlConnection Connection;
        SqlDataAdapter Adapter;
        SqlDataAdapter adapterDoanhThu;
        DataSet dsDoanhThu;
        DataTable tbCBX;
        DataTable tbDTG;
        string kn = global::DoAn1.Properties.Settings.Default.DoAn1ConnectionString;
        int total = 0;
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            LoadCBX();
            TotalDoanhThu();
            if (radioNam.Checked)
            {
                TotalDoanhThu("Nam");
            }
            if (radioThang.Checked)
            {
                TotalDoanhThu("Thang");
            }
            if (radioNgay.Checked)
            {
                TotalDoanhThu("Ngay");
            }
        }

        private void LoadCBX()
        {
            Connection = new SqlConnection(kn);
            string select = "select DISTINCT NgayBan from HoaDon";
            Adapter = new SqlDataAdapter(select , Connection);
            tbCBX = new DataTable();
            Adapter.Fill(tbCBX);
            cbxNgayBan.DataSource = tbCBX;
            cbxNgayBan.DisplayMember = "NgayBan";
            cbxNgayBan.ValueMember = "NgayBan";
            cbxNgayBan.SelectedIndexChanged += cbxNgayBan_SelectedIndexChanged;
        }
        private void LoadDataGrid(string NgayBan = "")
        {
            

            string select;
            Connection = new SqlConnection(kn);
            DateTime dateTimeNgayBan = DateTime.Parse(NgayBan);
            if (NgayBan != "")
            {
                dateTimeNgayBan = DateTime.Parse(NgayBan);
                select = string.Format("SELECT  SanPham.TenSanPham, [Order].SoLuong, [Order].Gia, HoaDon.NgayBan from HoaDon inner join [Order] On HoaDon.IDOrder = [Order].IDOrder inner join SanPham on SanPham.IDSanPham= [Order].IDSanPham where NgayBan Like '%{0}%'  ", dateTimeNgayBan.ToString("yyyy-MM-dd"));
            }
            else
            {
                dateTimeNgayBan = DateTime.Parse(cbxNgayBan.SelectedValue.ToString());
                select = string.Format("SELECT SanPham.TenSanPham, [Order].SoLuong, [Order].Gia, HoaDon.NgayBan from HoaDon inner join [Order] On HoaDon.IDOrder = [Order].IDOrder inner join SanPham on SanPham.IDSanPham= [Order].IDSanPham where NgayBan Like '%{0}%' ", dateTimeNgayBan.ToString("yyyy-MM-dd"));
            }

            SqlDataAdapter adapterDTG = new SqlDataAdapter(select, Connection);
            tbDTG = new DataTable();
            adapterDTG.Fill(tbDTG);
            dataGridDoanhThu.DataSource = tbDTG;

            TextGia.Text = TongTien().ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN"));


        }

        private int TongTien()
        {
            int total = 0;
            foreach(DataRow dr in tbDTG.Rows)
            {
                total += int.Parse(dr["Gia"].ToString());
            }


            return total ;
        }
        private void TotalDoanhThu(string type = "")
        {
            bool kt = false;
            ChartDoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "tiền";

            ChartDoanhThu.Series["BieuDoDoanhThu"].Points.Clear();


            string selectDoanhThu = string.Format("select DISTINCT  NgayBan from HoaDon ; SELECT SanPham.TenSanPham, [Order].SoLuong, [Order].Gia, HoaDon.NgayBan from HoaDon inner join [Order] On HoaDon.IDOrder = [Order].IDOrder inner join SanPham on SanPham.IDSanPham= [Order].IDSanPham");
            adapterDoanhThu = new SqlDataAdapter(selectDoanhThu, Connection);
            dsDoanhThu = new DataSet();
            adapterDoanhThu.Fill(dsDoanhThu);
            DateTime TimeNgayBan = DateTime.Now;
            if (type == "Ngay")
            {
                ChartDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
                foreach (DataRow drNgayBan in dsDoanhThu.Tables[0].Rows)
                {
                    int total = 0;
                    TimeNgayBan = DateTime.Parse(drNgayBan["NgayBan"].ToString());

                    foreach (DataRow drDTG in dsDoanhThu.Tables[1].Rows)
                    {
                        DateTime TimedrDTG = DateTime.Parse(drDTG["NgayBan"].ToString());
                        if (TimeNgayBan.ToString("yyyy-MM-dd") == TimedrDTG.ToString("yyyy-MM-dd"))
                        {
                            total += Int32.Parse(drDTG["Gia"].ToString());
                        }
                    }
                    ChartDoanhThu.Series["BieuDoDoanhThu"].Points.AddXY(TimeNgayBan.ToString("MM-dd"), total.ToString());

                }
            }



            if (type == "Thang")
            {
                ChartDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Tháng ";
                int total = 0;

                for (int i = 0; i < dsDoanhThu.Tables[0].Rows.Count; i++)
                {
                    TimeNgayBan = DateTime.Parse(dsDoanhThu.Tables[0].Rows[i]["NgayBan"].ToString());
                    if (i == 0)
                    {
                        foreach (DataRow drDTG in dsDoanhThu.Tables[1].Rows)
                        {
                            DateTime TimedrDTG = DateTime.Parse(drDTG["NgayBan"].ToString());
                            if (TimedrDTG.ToString("yyyy-MM") == TimeNgayBan.ToString("yyyy-MM"))
                            {
                                total += Int32.Parse(drDTG["Gia"].ToString());                      
                            } 
                        }
                        ChartDoanhThu.Series["BieuDoDoanhThu"].Points.AddXY(TimeNgayBan.ToString("yyyy-MM"), total.ToString());
                        total = 0;
                    }
                    if (i > 0)
                    {
                        DateTime TimeNgayBan2 = DateTime.Parse(dsDoanhThu.Tables[0].Rows[i - 1]["NgayBan"].ToString());
                        if (TimeNgayBan2.ToString("yyyy-MM") != TimeNgayBan.ToString("yyyy-MM"))
                        {
                            foreach (DataRow drDTG in dsDoanhThu.Tables[1].Rows)
                            {
                                DateTime TimedrDTG = DateTime.Parse(drDTG["NgayBan"].ToString());
                                if (TimedrDTG.ToString("yyyy-MM") == TimeNgayBan.ToString("yyyy-MM"))
                                {
                                    total += Int32.Parse(drDTG["Gia"].ToString());     
                                }
                                
                            }
                            ChartDoanhThu.Series["BieuDoDoanhThu"].Points.AddXY(TimeNgayBan.ToString("yyyy-MM"), total.ToString());
                            total = 0;
                        }
                    }

                }
               
            }

            if(type == "Nam")
            {
                ChartDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Năm ";
                int total = 0;

                for (int i = 0; i < dsDoanhThu.Tables[0].Rows.Count; i++)
                {
                    TimeNgayBan = DateTime.Parse(dsDoanhThu.Tables[0].Rows[i]["NgayBan"].ToString());
                    if (i == 0)
                    {
                        foreach (DataRow drDTG in dsDoanhThu.Tables[1].Rows)
                        {
                            DateTime TimedrDTG = DateTime.Parse(drDTG["NgayBan"].ToString());
                            if (TimedrDTG.ToString("yyyy") == TimeNgayBan.ToString("yyyy"))
                            {
                                total += Int32.Parse(drDTG["Gia"].ToString());
                            }
                        }
                        ChartDoanhThu.Series["BieuDoDoanhThu"].Points.AddXY(TimeNgayBan.ToString("yyyy-MM"), total.ToString());
                        total = 0;
                    }
                    if (i > 0)
                    {
                        DateTime TimeNgayBan2 = DateTime.Parse(dsDoanhThu.Tables[0].Rows[i - 1]["NgayBan"].ToString());
                        if (TimeNgayBan2.ToString("yyyy") != TimeNgayBan.ToString("yyyy"))
                        {
                            foreach (DataRow drDTG in dsDoanhThu.Tables[1].Rows)
                            {
                                DateTime TimedrDTG = DateTime.Parse(drDTG["NgayBan"].ToString());
                                if (TimedrDTG.ToString("yyyy-MM") == TimeNgayBan.ToString("yyyy"))
                                {
                                    total += Int32.Parse(drDTG["Gia"].ToString());
                                }

                            }
                            ChartDoanhThu.Series["BieuDoDoanhThu"].Points.AddXY(TimeNgayBan.ToString("yyyy"), total.ToString());
                            total = 0;
                        }
                    }

                }
            }
        }
            private void cbxNgayBan_SelectedIndexChanged(object sender, EventArgs e)
        {


            DataRowView selectedRow = (DataRowView)cbxNgayBan.SelectedItem;
            string NgayBan = selectedRow["NgayBan"].ToString();
            LoadDataGrid(NgayBan);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void radioNgay_CheckedChanged(object sender, EventArgs e)
        {
                DoanhThu_Load(sender, e);

        }

        private void radioThang_CheckedChanged(object sender, EventArgs e)
        {
                DoanhThu_Load(sender, e);
        }

        private void radioNam_CheckedChanged(object sender, EventArgs e)
        {
            
                
                DoanhThu_Load(sender, e);
            
        }
    }
}
