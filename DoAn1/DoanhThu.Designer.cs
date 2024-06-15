namespace DoAn1
{
    partial class DoanhThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.TextGia = new System.Windows.Forms.TextBox();
            this.dataGridDoanhThu = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNgayBan = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioNam = new System.Windows.Forms.RadioButton();
            this.radioThang = new System.Windows.Forms.RadioButton();
            this.radioNgay = new System.Windows.Forms.RadioButton();
            this.ChartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NameSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(60)))), ((int)(((byte)(24)))));
            this.label2.Location = new System.Drawing.Point(190, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày Bán";
            // 
            // TextGia
            // 
            this.TextGia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextGia.BackColor = System.Drawing.Color.Gainsboro;
            this.TextGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(118)))), ((int)(((byte)(68)))));
            this.TextGia.Location = new System.Drawing.Point(676, 60);
            this.TextGia.Name = "TextGia";
            this.TextGia.Size = new System.Drawing.Size(145, 28);
            this.TextGia.TabIndex = 5;
            // 
            // dataGridDoanhThu
            // 
            this.dataGridDoanhThu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridDoanhThu.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameSp,
            this.SoLuong,
            this.Gia,
            this.Ngay});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(118)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDoanhThu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDoanhThu.Location = new System.Drawing.Point(116, 106);
            this.dataGridDoanhThu.Name = "dataGridDoanhThu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDoanhThu.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDoanhThu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridDoanhThu.RowTemplate.Height = 28;
            this.dataGridDoanhThu.Size = new System.Drawing.Size(785, 267);
            this.dataGridDoanhThu.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(60)))), ((int)(((byte)(24)))));
            this.label3.Location = new System.Drawing.Point(514, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tổng Danh  Thu";
            // 
            // cbxNgayBan
            // 
            this.cbxNgayBan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxNgayBan.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxNgayBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNgayBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(118)))), ((int)(((byte)(68)))));
            this.cbxNgayBan.FormattingEnabled = true;
            this.cbxNgayBan.Location = new System.Drawing.Point(293, 57);
            this.cbxNgayBan.Name = "cbxNgayBan";
            this.cbxNgayBan.Size = new System.Drawing.Size(160, 30);
            this.cbxNgayBan.TabIndex = 4;
            this.cbxNgayBan.SelectedIndexChanged += new System.EventHandler(this.cbxNgayBan_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.radioNam);
            this.panel1.Controls.Add(this.radioThang);
            this.panel1.Controls.Add(this.radioNgay);
            this.panel1.Controls.Add(this.ChartDoanhThu);
            this.panel1.Controls.Add(this.cbxNgayBan);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridDoanhThu);
            this.panel1.Controls.Add(this.TextGia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(118)))), ((int)(((byte)(68)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 752);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // radioNam
            // 
            this.radioNam.AutoSize = true;
            this.radioNam.Location = new System.Drawing.Point(797, 498);
            this.radioNam.Name = "radioNam";
            this.radioNam.Size = new System.Drawing.Size(180, 26);
            this.radioNam.TabIndex = 10;
            this.radioNam.TabStop = true;
            this.radioNam.Text = "Doanh Thu Năm";
            this.radioNam.UseVisualStyleBackColor = true;
            this.radioNam.CheckedChanged += new System.EventHandler(this.radioNam_CheckedChanged);
            // 
            // radioThang
            // 
            this.radioThang.AutoSize = true;
            this.radioThang.Location = new System.Drawing.Point(797, 466);
            this.radioThang.Name = "radioThang";
            this.radioThang.Size = new System.Drawing.Size(203, 26);
            this.radioThang.TabIndex = 9;
            this.radioThang.TabStop = true;
            this.radioThang.Text = "Doanh Thu Tháng ";
            this.radioThang.UseVisualStyleBackColor = true;
            this.radioThang.CheckedChanged += new System.EventHandler(this.radioThang_CheckedChanged);
            // 
            // radioNgay
            // 
            this.radioNgay.AutoSize = true;
            this.radioNgay.Checked = true;
            this.radioNgay.Location = new System.Drawing.Point(797, 434);
            this.radioNgay.Name = "radioNgay";
            this.radioNgay.Size = new System.Drawing.Size(186, 26);
            this.radioNgay.TabIndex = 8;
            this.radioNgay.TabStop = true;
            this.radioNgay.Text = "Doanh Thu Ngày";
            this.radioNgay.UseVisualStyleBackColor = true;
            this.radioNgay.CheckedChanged += new System.EventHandler(this.radioNgay_CheckedChanged);
            // 
            // ChartDoanhThu
            // 
            this.ChartDoanhThu.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.Name = "ChartArea1";
            this.ChartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartDoanhThu.Legends.Add(legend1);
            this.ChartDoanhThu.Location = new System.Drawing.Point(0, 389);
            this.ChartDoanhThu.Name = "ChartDoanhThu";
            this.ChartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "BieuDoDoanhThu";
            this.ChartDoanhThu.Series.Add(series1);
            this.ChartDoanhThu.Size = new System.Drawing.Size(991, 290);
            this.ChartDoanhThu.TabIndex = 7;
            this.ChartDoanhThu.Text = "chart1";
            // 
            // NameSp
            // 
            this.NameSp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameSp.DataPropertyName = "TenSanPham";
            this.NameSp.HeaderText = "Tên Sản Phẩm";
            this.NameSp.MinimumWidth = 8;
            this.NameSp.Name = "NameSp";
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
            // Ngay
            // 
            this.Ngay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ngay.DataPropertyName = "NgayBan";
            this.Ngay.HeaderText = "Ngày Bán";
            this.Ngay.MinimumWidth = 8;
            this.Ngay.Name = "Ngay";
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1015, 752);
            this.Controls.Add(this.panel1);
            this.Name = "DoanhThu";
            this.Text = "DoanhThu";
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextGia;
        private System.Windows.Forms.DataGridView dataGridDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNgayBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartDoanhThu;
        private System.Windows.Forms.RadioButton radioNam;
        private System.Windows.Forms.RadioButton radioThang;
        private System.Windows.Forms.RadioButton radioNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
    }
}