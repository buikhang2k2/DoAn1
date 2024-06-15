using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class ChucNang : Form
    {
        int w = 0, h = 0 ;
        public int kt; 
        private Form  CurrentFormChild;
        public ChucNang()
        {
            InitializeComponent();
        }

        private void OpenChildFrom( Form childForm )
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = childForm;
            childForm.TopLevel =  false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PannelFill.Controls.Add( childForm );
            PannelFill.Tag = childForm;
            PannelFill.BringToFront();
            childForm.Show();


        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new QuanLySanPham());
            btnDoanhThu.ForeColor = Color.FromArgb(111, 101, 90);
            btnOrderMenu.ForeColor = Color.FromArgb(111, 101, 90);
            btnThanhToan.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLyNhanVien.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLySanPham.ForeColor = Color.FromArgb(96, 60, 24);
        }

        private void btnOrderMenu_Click(object sender, EventArgs e)
        { 
            OpenChildFrom(new Order());
            btnQuanLySanPham.ForeColor = Color.FromArgb(111, 101, 90);
            btnDoanhThu.ForeColor = Color.FromArgb(111, 101, 90);
            btnThanhToan.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLyNhanVien.ForeColor = Color.FromArgb(111, 101, 90);
            btnOrderMenu.ForeColor = Color.FromArgb(96, 60, 24);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new DoanhThu());
            btnQuanLySanPham.ForeColor = Color.FromArgb(111, 101, 90);
            btnOrderMenu.ForeColor = Color.FromArgb(111, 101, 90);
            btnThanhToan.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLyNhanVien.ForeColor = Color.FromArgb(111, 101, 90);
            btnDoanhThu.ForeColor = Color.FromArgb(96, 60, 24);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new ThanhToan());
            btnQuanLySanPham.ForeColor = Color.FromArgb(111, 101, 90);
            btnDoanhThu.ForeColor = Color.FromArgb(111, 101, 90);
            btnOrderMenu.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLyNhanVien.ForeColor = Color.FromArgb(111, 101, 90);
            btnThanhToan.ForeColor = Color.FromArgb(96, 60, 24);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
            
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new QuanLyNhanVien());
            btnQuanLySanPham.ForeColor = Color.FromArgb(111, 101, 90);
            btnDoanhThu.ForeColor = Color.FromArgb(111, 101, 90);
            btnOrderMenu.ForeColor = Color.FromArgb(111, 101, 90);
            btnThanhToan.ForeColor = Color.FromArgb(111, 101, 90);
            btnQuanLyNhanVien.ForeColor = Color.FromArgb(96, 60, 24);
            
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("ban co muon thoat ", "thon bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

               this.Close();
            }
        }

        private void ChucNang_Load(object sender, EventArgs e)
        {
            // kt khởi tạo tại tại class này
            if(kt == 0)
            {
                btnQuanLyNhanVien.Enabled = false;
                btnQuanLySanPham.Enabled = false;

            }
            
        }

        private void PanelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
