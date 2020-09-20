namespace Phanmem_QL_Quan_CaPhe
{
    partial class FormManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbChuyenBan_Manager = new System.Windows.Forms.ComboBox();
            this.btnThanhToan__Manager = new System.Windows.Forms.Button();
            this.btnChuyenBan__Manager = new System.Windows.Forms.Button();
            this.nudGiamGia__Manager = new System.Windows.Forms.NumericUpDown();
            this.btnGiamGiaManager = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbTongTien = new System.Windows.Forms.TextBox();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudSoLuongMon__Manager = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon_Manager = new System.Windows.Forms.Button();
            this.cbTenMon_Manager = new System.Windows.Forms.ComboBox();
            this.cbDanhMucMon_Manager = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia__Manager)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongMon__Manager)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.adminToolStripMenuItem.Text = "Quản Lý Phần Mềm";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpTable);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 531);
            this.panel1.TabIndex = 2;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(2, 2);
            this.flpTable.Margin = new System.Windows.Forms.Padding(2);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(562, 526);
            this.flpTable.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(567, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(391, 529);
            this.panel5.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbChuyenBan_Manager);
            this.panel4.Controls.Add(this.btnThanhToan__Manager);
            this.panel4.Controls.Add(this.btnChuyenBan__Manager);
            this.panel4.Controls.Add(this.nudGiamGia__Manager);
            this.panel4.Controls.Add(this.btnGiamGiaManager);
            this.panel4.Location = new System.Drawing.Point(2, 452);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 76);
            this.panel4.TabIndex = 7;
            // 
            // cbChuyenBan_Manager
            // 
            this.cbChuyenBan_Manager.FormattingEnabled = true;
            this.cbChuyenBan_Manager.Location = new System.Drawing.Point(11, 45);
            this.cbChuyenBan_Manager.Name = "cbChuyenBan_Manager";
            this.cbChuyenBan_Manager.Size = new System.Drawing.Size(111, 21);
            this.cbChuyenBan_Manager.TabIndex = 4;
            // 
            // btnThanhToan__Manager
            // 
            this.btnThanhToan__Manager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan__Manager.Image = global::Phanmem_QL_Quan_CaPhe.Properties.Resources.icons8_bill_24;
            this.btnThanhToan__Manager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan__Manager.Location = new System.Drawing.Point(148, 21);
            this.btnThanhToan__Manager.Name = "btnThanhToan__Manager";
            this.btnThanhToan__Manager.Size = new System.Drawing.Size(103, 42);
            this.btnThanhToan__Manager.TabIndex = 3;
            this.btnThanhToan__Manager.Text = "Thanh toán";
            this.btnThanhToan__Manager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan__Manager.UseVisualStyleBackColor = true;
            this.btnThanhToan__Manager.Click += new System.EventHandler(this.btnThanhToan__Manager_Click);
            // 
            // btnChuyenBan__Manager
            // 
            this.btnChuyenBan__Manager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan__Manager.Image = global::Phanmem_QL_Quan_CaPhe.Properties.Resources.icons8_arrow_left_and_right_24;
            this.btnChuyenBan__Manager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChuyenBan__Manager.Location = new System.Drawing.Point(10, 10);
            this.btnChuyenBan__Manager.Name = "btnChuyenBan__Manager";
            this.btnChuyenBan__Manager.Size = new System.Drawing.Size(112, 29);
            this.btnChuyenBan__Manager.TabIndex = 5;
            this.btnChuyenBan__Manager.Text = "Chuyển bàn";
            this.btnChuyenBan__Manager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChuyenBan__Manager.UseVisualStyleBackColor = true;
            this.btnChuyenBan__Manager.Click += new System.EventHandler(this.btnChuyenBan__Manager_Click);
            // 
            // nudGiamGia__Manager
            // 
            this.nudGiamGia__Manager.Location = new System.Drawing.Point(280, 46);
            this.nudGiamGia__Manager.Name = "nudGiamGia__Manager";
            this.nudGiamGia__Manager.Size = new System.Drawing.Size(100, 20);
            this.nudGiamGia__Manager.TabIndex = 5;
            this.nudGiamGia__Manager.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGiamGiaManager
            // 
            this.btnGiamGiaManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiamGiaManager.Image = global::Phanmem_QL_Quan_CaPhe.Properties.Resources.icons8_discount_24;
            this.btnGiamGiaManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiamGiaManager.Location = new System.Drawing.Point(280, 10);
            this.btnGiamGiaManager.Name = "btnGiamGiaManager";
            this.btnGiamGiaManager.Size = new System.Drawing.Size(100, 29);
            this.btnGiamGiaManager.TabIndex = 4;
            this.btnGiamGiaManager.Text = "Giảm giá";
            this.btnGiamGiaManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGiamGiaManager.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtbTongTien);
            this.panel3.Controls.Add(this.lsvBill);
            this.panel3.Location = new System.Drawing.Point(2, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 386);
            this.panel3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Phanmem_QL_Quan_CaPhe.Properties.Resources.icons8_money_24;
            this.pictureBox1.Location = new System.Drawing.Point(159, 362);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(194, 364);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng tiền";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbTongTien
            // 
            this.txtbTongTien.BackColor = System.Drawing.Color.White;
            this.txtbTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtbTongTien.Location = new System.Drawing.Point(268, 361);
            this.txtbTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtbTongTien.Name = "txtbTongTien";
            this.txtbTongTien.ReadOnly = true;
            this.txtbTongTien.Size = new System.Drawing.Size(116, 26);
            this.txtbTongTien.TabIndex = 5;
            this.txtbTongTien.Text = "0";
            this.txtbTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbTongTien.TextChanged += new System.EventHandler(this.txbTongTien_TextChanged);
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(11, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(373, 356);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 72;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 220;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudSoLuongMon__Manager);
            this.panel2.Controls.Add(this.btnThemMon_Manager);
            this.panel2.Controls.Add(this.cbTenMon_Manager);
            this.panel2.Controls.Add(this.cbDanhMucMon_Manager);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 58);
            this.panel2.TabIndex = 5;
            // 
            // nudSoLuongMon__Manager
            // 
            this.nudSoLuongMon__Manager.Location = new System.Drawing.Point(227, 32);
            this.nudSoLuongMon__Manager.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSoLuongMon__Manager.Name = "nudSoLuongMon__Manager";
            this.nudSoLuongMon__Manager.Size = new System.Drawing.Size(47, 20);
            this.nudSoLuongMon__Manager.TabIndex = 3;
            this.nudSoLuongMon__Manager.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemMon_Manager
            // 
            this.btnThemMon_Manager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon_Manager.Image = global::Phanmem_QL_Quan_CaPhe.Properties.Resources.icons8_plus_24;
            this.btnThemMon_Manager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMon_Manager.Location = new System.Drawing.Point(280, 3);
            this.btnThemMon_Manager.Name = "btnThemMon_Manager";
            this.btnThemMon_Manager.Size = new System.Drawing.Size(103, 51);
            this.btnThemMon_Manager.TabIndex = 2;
            this.btnThemMon_Manager.TabStop = false;
            this.btnThemMon_Manager.Text = "Thêm món";
            this.btnThemMon_Manager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMon_Manager.UseVisualStyleBackColor = true;
            this.btnThemMon_Manager.Click += new System.EventHandler(this.btnThemMon_Manager_Click);
            // 
            // cbTenMon_Manager
            // 
            this.cbTenMon_Manager.FormattingEnabled = true;
            this.cbTenMon_Manager.Location = new System.Drawing.Point(11, 31);
            this.cbTenMon_Manager.Name = "cbTenMon_Manager";
            this.cbTenMon_Manager.Size = new System.Drawing.Size(210, 21);
            this.cbTenMon_Manager.TabIndex = 1;
            // 
            // cbDanhMucMon_Manager
            // 
            this.cbDanhMucMon_Manager.FormattingEnabled = true;
            this.cbDanhMucMon_Manager.Location = new System.Drawing.Point(11, 4);
            this.cbDanhMucMon_Manager.Name = "cbDanhMucMon_Manager";
            this.cbDanhMucMon_Manager.Size = new System.Drawing.Size(210, 21);
            this.cbDanhMucMon_Manager.TabIndex = 0;
            this.cbDanhMucMon_Manager.SelectedIndexChanged += new System.EventHandler(this.cbDanhMucMon_Manager_SelectedIndexChanged);
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Quán Cà Phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia__Manager)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongMon__Manager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbChuyenBan_Manager;
        private System.Windows.Forms.Button btnThanhToan__Manager;
        private System.Windows.Forms.Button btnChuyenBan__Manager;
        private System.Windows.Forms.NumericUpDown nudGiamGia__Manager;
        private System.Windows.Forms.Button btnGiamGiaManager;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudSoLuongMon__Manager;
        private System.Windows.Forms.Button btnThemMon_Manager;
        private System.Windows.Forms.ComboBox cbTenMon_Manager;
        private System.Windows.Forms.ComboBox cbDanhMucMon_Manager;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbTongTien;
    }
}

