namespace QuanLyKhoSieuThi
{
    partial class FormSelectProduct
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Datasp = new Guna.UI2.WinForms.Guna2DataGridView();
            ID = new DataGridViewTextBoxColumn();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            SLCon = new DataGridViewTextBoxColumn();
            Dongia = new DataGridViewTextBoxColumn();
            NhaSX = new DataGridViewTextBoxColumn();
            HSD = new DataGridViewTextBoxColumn();
            LoaiSP = new DataGridViewTextBoxColumn();
            Donvi = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            Bt_tim = new Guna.UI2.WinForms.Guna2CircleButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)Datasp).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Datasp
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            Datasp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Datasp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Datasp.ColumnHeadersHeight = 50;
            Datasp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            Datasp.Columns.AddRange(new DataGridViewColumn[] { ID, MaSP, TenSP, SLCon, Dongia, NhaSX, HSD, LoaiSP, Donvi });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            Datasp.DefaultCellStyle = dataGridViewCellStyle3;
            Datasp.GridColor = Color.FromArgb(231, 229, 255);
            Datasp.Location = new Point(12, 121);
            Datasp.Name = "Datasp";
            Datasp.RowHeadersVisible = false;
            Datasp.RowHeadersWidth = 62;
            Datasp.Size = new Size(1479, 581);
            Datasp.TabIndex = 7;
            Datasp.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            Datasp.ThemeStyle.AlternatingRowsStyle.Font = null;
            Datasp.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            Datasp.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            Datasp.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            Datasp.ThemeStyle.BackColor = Color.White;
            Datasp.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            Datasp.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            Datasp.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            Datasp.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            Datasp.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            Datasp.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            Datasp.ThemeStyle.HeaderStyle.Height = 50;
            Datasp.ThemeStyle.ReadOnly = false;
            Datasp.ThemeStyle.RowsStyle.BackColor = Color.White;
            Datasp.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Datasp.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            Datasp.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            Datasp.ThemeStyle.RowsStyle.Height = 33;
            Datasp.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            Datasp.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            Datasp.CellContentClick += Datasp_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            // 
            // MaSP
            // 
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.MinimumWidth = 8;
            MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            TenSP.HeaderText = "Tên Sản Phẩm";
            TenSP.MinimumWidth = 8;
            TenSP.Name = "TenSP";
            // 
            // SLCon
            // 
            SLCon.HeaderText = "Số lượng còn";
            SLCon.MinimumWidth = 8;
            SLCon.Name = "SLCon";
            // 
            // Dongia
            // 
            Dongia.HeaderText = "Đơn giá";
            Dongia.MinimumWidth = 8;
            Dongia.Name = "Dongia";
            // 
            // NhaSX
            // 
            NhaSX.HeaderText = "NSX";
            NhaSX.MinimumWidth = 8;
            NhaSX.Name = "NhaSX";
            // 
            // HSD
            // 
            HSD.HeaderText = "Ngày hết hạn";
            HSD.MinimumWidth = 8;
            HSD.Name = "HSD";
            // 
            // LoaiSP
            // 
            LoaiSP.HeaderText = "Loại";
            LoaiSP.MinimumWidth = 8;
            LoaiSP.Name = "LoaiSP";
            // 
            // Donvi
            // 
            Donvi.HeaderText = "Đơn vị";
            Donvi.MinimumWidth = 8;
            Donvi.Name = "Donvi";
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2GradientButton1);
            panel2.Controls.Add(Bt_tim);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1484, 100);
            panel2.TabIndex = 8;
            // 
            // guna2GradientButton1
            // 
            guna2GradientButton1.BorderRadius = 25;
            guna2GradientButton1.CustomizableEdges = customizableEdges1;
            guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2GradientButton1.Font = new Font("Segoe UI", 9F);
            guna2GradientButton1.ForeColor = Color.White;
            guna2GradientButton1.Location = new Point(1293, 25);
            guna2GradientButton1.Name = "guna2GradientButton1";
            guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientButton1.Size = new Size(186, 53);
            guna2GradientButton1.TabIndex = 3;
            // 
            // Bt_tim
            // 
            Bt_tim.DisabledState.BorderColor = Color.DarkGray;
            Bt_tim.DisabledState.CustomBorderColor = Color.DarkGray;
            Bt_tim.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Bt_tim.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Bt_tim.Font = new Font("Segoe UI", 9F);
            Bt_tim.ForeColor = Color.White;
            Bt_tim.Location = new Point(610, 25);
            Bt_tim.Name = "Bt_tim";
            Bt_tim.ShadowDecoration.CustomizableEdges = customizableEdges3;
            Bt_tim.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Bt_tim.Size = new Size(50, 50);
            Bt_tim.TabIndex = 2;
            Bt_tim.Text = "O";
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 25;
            txtSearch.CustomizableEdges = customizableEdges4;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(160, 22);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtSearch.Size = new Size(429, 53);
            txtSearch.TabIndex = 1;
            // 
            // FormSelectProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1507, 687);
            Controls.Add(panel2);
            Controls.Add(Datasp);
            Name = "FormSelectProduct";
            Text = "FormSelectProduct";
            Load += FormSelectProduct_Load;
            ((System.ComponentModel.ISupportInitialize)Datasp).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView Datasp;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn SLCon;
        private DataGridViewTextBoxColumn Dongia;
        private DataGridViewTextBoxColumn NhaSX;
        private DataGridViewTextBoxColumn HSD;
        private DataGridViewTextBoxColumn LoaiSP;
        private DataGridViewTextBoxColumn Donvi;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2CircleButton Bt_tim;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}