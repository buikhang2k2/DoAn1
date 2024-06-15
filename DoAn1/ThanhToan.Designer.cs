namespace DoAn1
{
    partial class ThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.textGia = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.dataGridThanhToan = new System.Windows.Forms.DataGridView();
            this.IDOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPhamOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxBan = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.doAn1DataSet = new DoAn1.DoAn1DataSet();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderTableAdapter = new DoAn1.DoAn1DataSetTableAdapters.OrderTableAdapter();
            this.tableAdapterManager = new DoAn1.DoAn1DataSetTableAdapters.TableAdapterManager();
            this.doAn1DataSet1 = new DoAn1.DoAn1DataSet();
            this.dataGridViewHoaDon = new System.Windows.Forms.DataGridView();
            this.IDHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoluongSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThanhToan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doAn1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doAn1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng Số Tiền";
            // 
            // textGia
            // 
            this.textGia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(60)))), ((int)(((byte)(24)))));
            this.textGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGia.ForeColor = System.Drawing.Color.White;
            this.textGia.Location = new System.Drawing.Point(139, 60);
            this.textGia.Name = "textGia";
            this.textGia.Size = new System.Drawing.Size(169, 30);
            this.textGia.TabIndex = 6;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(60)))), ((int)(((byte)(24)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(139, 114);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(169, 66);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // dataGridThanhToan
            // 
            this.dataGridThanhToan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDOrder,
            this.TenKhachHang,
            this.TenSanPhamOrder,
            this.SoLuong,
            this.Gia,
            this.IDBan});
            this.dataGridThanhToan.Location = new System.Drawing.Point(361, 12);
            this.dataGridThanhToan.Name = "dataGridThanhToan";
            this.dataGridThanhToan.RowHeadersWidth = 62;
            this.dataGridThanhToan.RowTemplate.Height = 28;
            this.dataGridThanhToan.Size = new System.Drawing.Size(504, 374);
            this.dataGridThanhToan.TabIndex = 12;
            // 
            // IDOrder
            // 
            this.IDOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDOrder.DataPropertyName = "IDOrder";
            this.IDOrder.HeaderText = "Mã Số OrDer";
            this.IDOrder.MinimumWidth = 8;
            this.IDOrder.Name = "IDOrder";
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.TenKhachHang.MinimumWidth = 8;
            this.TenKhachHang.Name = "TenKhachHang";
            // 
            // TenSanPhamOrder
            // 
            this.TenSanPhamOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSanPhamOrder.DataPropertyName = "TenSanPham";
            this.TenSanPhamOrder.HeaderText = "Tên Món";
            this.TenSanPhamOrder.MinimumWidth = 8;
            this.TenSanPhamOrder.Name = "TenSanPhamOrder";
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // Gia
            // 
            this.Gia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 8;
            this.Gia.Name = "Gia";
            // 
            // IDBan
            // 
            this.IDBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDBan.DataPropertyName = "IDBan";
            this.IDBan.HeaderText = "Số Bàn";
            this.IDBan.MinimumWidth = 8;
            this.IDBan.Name = "IDBan";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Số Bàn: ";
            // 
            // cbxBan
            // 
            this.cbxBan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(60)))), ((int)(((byte)(24)))));
            this.cbxBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBan.ForeColor = System.Drawing.Color.White;
            this.cbxBan.FormattingEnabled = true;
            this.cbxBan.Location = new System.Drawing.Point(139, 12);
            this.cbxBan.Name = "cbxBan";
            this.cbxBan.Size = new System.Drawing.Size(169, 33);
            this.cbxBan.TabIndex = 13;
            this.cbxBan.SelectedIndexChanged += new System.EventHandler(this.cbxBan_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridViewHoaDon);
            this.panel2.Controls.Add(this.cbxBan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridThanhToan);
            this.panel2.Controls.Add(this.btnThanhToan);
            this.panel2.Controls.Add(this.textGia);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 692);
            this.panel2.TabIndex = 15;
            // 
            // doAn1DataSet
            // 
            this.doAn1DataSet.DataSetName = "DoAn1DataSet";
            this.doAn1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.doAn1DataSet;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BanTableAdapter = null;
            this.tableAdapterManager.HoaDonTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.LoaiSanPhamTableAdapter = null;
            this.tableAdapterManager.LogUPTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.OrderTableAdapter = this.orderTableAdapter;
            this.tableAdapterManager.SanPhamTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DoAn1.DoAn1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // doAn1DataSet1
            // 
            this.doAn1DataSet1.DataSetName = "DoAn1DataSet";
            this.doAn1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewHoaDon
            // 
            this.dataGridViewHoaDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDHoaDon,
            this.TenSP,
            this.SoluongSP,
            this.TongGia,
            this.KhachHang});
            this.dataGridViewHoaDon.Location = new System.Drawing.Point(21, 409);
            this.dataGridViewHoaDon.Name = "dataGridViewHoaDon";
            this.dataGridViewHoaDon.RowHeadersWidth = 62;
            this.dataGridViewHoaDon.RowTemplate.Height = 28;
            this.dataGridViewHoaDon.Size = new System.Drawing.Size(853, 258);
            this.dataGridViewHoaDon.TabIndex = 14;
            // 
            // IDHoaDon
            // 
            this.IDHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDHoaDon.DataPropertyName = "IDOrder";
            this.IDHoaDon.HeaderText = "ID Hóa Đơn ";
            this.IDHoaDon.MinimumWidth = 8;
            this.IDHoaDon.Name = "IDHoaDon";
            // 
            // TenSP
            // 
            this.TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSP.DataPropertyName = "TenSanPham";
            this.TenSP.HeaderText = "TenSanPham";
            this.TenSP.MinimumWidth = 8;
            this.TenSP.Name = "TenSP";
            // 
            // SoluongSP
            // 
            this.SoluongSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoluongSP.DataPropertyName = "SoLuong";
            this.SoluongSP.HeaderText = "Số Lượng ";
            this.SoluongSP.MinimumWidth = 8;
            this.SoluongSP.Name = "SoluongSP";
            // 
            // TongGia
            // 
            this.TongGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TongGia.DataPropertyName = "Gia";
            this.TongGia.HeaderText = "Giá";
            this.TongGia.MinimumWidth = 8;
            this.TongGia.Name = "TongGia";
            // 
            // KhachHang
            // 
            this.KhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KhachHang.DataPropertyName = "TenKhachHang";
            this.KhachHang.HeaderText = "Khách Hàng";
            this.KhachHang.MinimumWidth = 8;
            this.KhachHang.Name = "KhachHang";
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(877, 692);
            this.Controls.Add(this.panel2);
            this.Name = "ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.ThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThanhToan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doAn1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doAn1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DoAn1DataSet doAn1DataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private DoAn1DataSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private DoAn1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DoAn1DataSet doAn1DataSet1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridView dataGridThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxBan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPhamOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDBan;
        private System.Windows.Forms.DataGridView dataGridViewHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoluongSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHang;
    }
}