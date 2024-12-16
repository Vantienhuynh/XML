using System.Data;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.DataFormats;

namespace QuanLyKhoSieuThi
{
    public partial class Form1 : Form
    {
        private ProductManager _productManager;

        public Form1()
        {
            InitializeComponent();
            _productManager = new ProductManager("products.xml", "Hinhanh.xml");
            LoadData();
            LoadNCC();
            LoadPhieuNhap();
            LoadComboBoxMaSP();
            LoadComboBoxMaNCC();
            // Gán dữ liệu cho ComboBox Status
            guna2ComboBox3.Items.Clear();
            guna2ComboBox3.Items.Add("Hoạt động");
            guna2ComboBox3.Items.Add("Không hoạt động");

            // Đặt giá trị mặc định là "Hoạt động"
            guna2ComboBox3.SelectedIndex = 0;
        }
        private void LoadData()
        {
            string xmlFilePath = "products.xml";

            // Tạo một DataSet để chứa dữ liệu từ file XML
            DataSet dataSet = new DataSet();

            // Đọc dữ liệu từ file XML vào DataSet
            dataSet.ReadXml(xmlFilePath);
            Datasp.Rows.Clear();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int rowIndex = Datasp.Rows.Add();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Datasp.Rows[rowIndex].Cells[i].Value = row.ItemArray[i];
                }
            }
        }
        private void Avatar_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void Bt_tim_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu tìm kiếm
            var results = _productManager.SearchProduct(txtSearch.Text);

            // Xóa tất cả các dòng cũ, giữ nguyên header
            Datasp.Rows.Clear();

            // Thêm dữ liệu mới vào DataGridView
            foreach (var row in results)
            {
                Datasp.Rows.Add(row);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ThemSP them = new ThemSP();
            them.FormClosed += (s, args) => LoadData();
            them.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (Datasp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID từ hàng được chọn
            DataGridViewRow selectedRow = Datasp.SelectedRows[0]; // Chỉ lấy hàng đầu tiên
            string idToDelete = selectedRow.Cells["ID"].Value?.ToString();

            if (string.IsNullOrEmpty(idToDelete))
            {
                MessageBox.Show("Không thể tìm thấy ID của hàng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xóa sản phẩm trong file XML
            bool success = _productManager.DeleteProductById(idToDelete);

            if (success)
            {
                // Hiển thị thông báo thành công
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại dữ liệu
                LoadData();
            }
            else
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Xóa sản phẩm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            if (Datasp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ hàng được chọn
            DataGridViewRow selectedRow = Datasp.SelectedRows[0];

            string id = selectedRow.Cells["ID"].Value?.ToString();
            string maSP = selectedRow.Cells["MaSP"].Value?.ToString();
            string tenSP = selectedRow.Cells["TenSP"].Value?.ToString();
            string soLuong = selectedRow.Cells["SLCon"].Value?.ToString();
            string donGia = selectedRow.Cells["DonGia"].Value?.ToString();
            string nsx = selectedRow.Cells["NhaSX"].Value?.ToString();
            string ngayHetHan = selectedRow.Cells["HSD"].Value?.ToString();
            string loaiHang = selectedRow.Cells["LoaiSP"].Value?.ToString();
            string donViTinh = selectedRow.Cells["Donvi"].Value?.ToString();

            // Mở Form sửa và truyền thông tin sang
            Sua suaForm = new Sua(id, maSP, tenSP, soLuong, donGia, nsx, ngayHetHan, loaiHang, donViTinh);
            suaForm.FormClosed += (s, args) => LoadData(); // Cập nhật lại dữ liệu sau khi sửa
            suaForm.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void LoadNCC()
        {

            string xmlFilePath = "Manufacturers.xml";

            // Tạo một DataSet để chứa dữ liệu từ file XML
            DataSet dataSet = new DataSet();

            // Đọc dữ liệu từ file XML vào DataSet
            dataSet.ReadXml(xmlFilePath);
            GRNCC.Rows.Clear();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int rowIndex = GRNCC.Rows.Add();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    GRNCC.Rows[rowIndex].Cells[i].Value = row.ItemArray[i];
                }
            }
        }
        private void LoadPhieuNhap()
        {

            string xmlFilePath = "PhieuNhap.xml";

            // Tạo một DataSet để chứa dữ liệu từ file XML
            DataSet dataSet = new DataSet();

            // Đọc dữ liệu từ file XML vào DataSet
            dataSet.ReadXml(xmlFilePath);
            SPPHIEU.Rows.Clear();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int rowIndex = SPPHIEU.Rows.Add();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    SPPHIEU.Rows[rowIndex].Cells[i].Value = row.ItemArray[i];
                }
            }
        }
        private void AddNewManufacturer()
        {
            string xmlFilePath = "Manufacturers.xml";

            // Tạo DataSet để đọc dữ liệu XML
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFilePath);

            // Tạo một dòng mới
            DataRow newRow = dataSet.Tables[0].NewRow();
            newRow["Code"] = guna2TextBox4.Text; // Mã nhà cung cấp
            newRow["Name"] = guna2TextBox5.Text; // Tên nhà cung cấp
            newRow["Status"] = guna2ComboBox3.SelectedItem.ToString(); // Trạng thái từ ComboBox
            newRow["PhoneNumber"] = guna2TextBox6.Text; // Số điện thoại
            newRow["Email"] = guna2TextBox8.Text; // Email
            newRow["Mua"] = guna2TextBox9.Text; // Tổng mua
            newRow["No"] = guna2TextBox10.Text; // Tổng nợ

            // Thêm dòng vào DataSet
            dataSet.Tables[0].Rows.Add(newRow);

            // Ghi dữ liệu trở lại file XML
            dataSet.WriteXml(xmlFilePath);

            // Load lại bảng dữ liệu
            LoadNCC();

            MessageBox.Show("Thêm nhà cung cấp thành công!");
        }
        private void UpdateManufacturer()
        {
            string xmlFilePath = "Manufacturers.xml";

            // Tạo DataSet để đọc dữ liệu XML
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFilePath);

            // Tìm dòng cần sửa dựa trên Mã nhà cung cấp
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["Code"].ToString() == guna2TextBox4.Text) // So khớp mã nhà cung cấp
                {
                    row["Name"] = guna2TextBox5.Text;
                    row["Status"] = guna2ComboBox3.SelectedItem.ToString(); // Trạng thái từ ComboBox
                    row["PhoneNumber"] = guna2TextBox6.Text;
                    row["Email"] = guna2TextBox8.Text;
                    row["Mua"] = guna2TextBox9.Text;
                    row["No"] = guna2TextBox10.Text;
                    break;
                }
            }

            // Ghi dữ liệu trở lại file XML
            dataSet.WriteXml(xmlFilePath);

            // Load lại bảng dữ liệu
            LoadNCC();

            MessageBox.Show("Cập nhật nhà cung cấp thành công!");
        }
        private void DeleteManufacturer()
        {
            string xmlFilePath = "Manufacturers.xml";

            // Đọc dữ liệu từ file XML
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFilePath);

            // Tìm dòng cần xóa
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["Code"].ToString() == guna2TextBox4.Text) // So khớp Mã nhà cung cấp
                {
                    row.Delete();
                    break;
                }
            }

            // Ghi dữ liệu trở lại file XML
            dataSet.WriteXml(xmlFilePath);

            // Load lại bảng dữ liệu
            LoadNCC();

            MessageBox.Show("Xóa nhà cung cấp thành công!");
        }
        private void LoadComboBoxMaSP()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("products.xml");

            CBNCC.DataSource = dataSet.Tables[0];
            CBNCC.DisplayMember = "MaSP";
            CBNCC.ValueMember = "MaSP";
        }
        private void LoadComboBoxMaNCC()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("Manufacturers.xml");

            guna2ComboBox2.DataSource = dataSet.Tables[0];
            guna2ComboBox2.DisplayMember = "Code";
            guna2ComboBox2.ValueMember = "Code";
        }
        private void AddNewPhieuNhap()
        {
            string xmlPhieuNhapPath = "PhieuNhap.xml";
            string xmlProductPath = "products.xml";

            // Đọc dữ liệu từ PhieuNhap.xml
            DataSet phieuNhapDataSet = new DataSet();
            phieuNhapDataSet.ReadXml(xmlPhieuNhapPath);

            // Thêm hàng mới vào DataSet PhieuNhap
            DataRow newRow = phieuNhapDataSet.Tables[0].NewRow();
            string maSP = CBNCC.SelectedValue.ToString(); // Mã sản phẩm được chọn
            int soLuongNhap = int.Parse(guna2TextBox1.Text);

            // Gán giá trị từ form
            newRow["MaPhieu"] = guna2TextBox2.Text;
            newRow["NguoiGiao"] = guna2TextBox3.Text;
            newRow["SoLuong"] = guna2TextBox1.Text;
            newRow["MaSP"] = maSP;
            newRow["ThoiGian"] = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            newRow["GhiChu"] = txtGhiChu.Text;
            newRow["MaNhaCungCap"] = guna2ComboBox2.SelectedValue.ToString();

            phieuNhapDataSet.Tables[0].Rows.Add(newRow);

            // Ghi lại dữ liệu vào PhieuNhap.xml
            phieuNhapDataSet.WriteXml(xmlPhieuNhapPath);

            // Cập nhật số lượng trong Product.xml
            DataSet productDataSet = new DataSet();
            productDataSet.ReadXml(xmlProductPath);

            foreach (DataRow row in productDataSet.Tables[0].Rows)
            {
                if (row["MaSP"].ToString() == maSP)
                {
                    int currentSoLuongCon = int.Parse(row["SoLuongCon"].ToString());
                    row["SoLuongCon"] = currentSoLuongCon + soLuongNhap; // Tăng số lượng tồn
                    break;
                }
            }

            // Ghi lại dữ liệu vào Product.xml
            productDataSet.WriteXml(xmlProductPath);

            // Cập nhật DataGridView
            LoadPhieuNhap();
            LoadData();
            MessageBox.Show("Thêm phiếu nhập và cập nhật số lượng sản phẩm thành công!");
        }

        private void GRNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GRNCC.Rows[e.RowIndex];

                guna2TextBox4.Text = row.Cells["MaNCC"].Value.ToString();
                guna2TextBox5.Text = row.Cells["Namencc"].Value.ToString();
                guna2ComboBox3.SelectedItem = row.Cells["Trangthai"].Value.ToString(); // Gán giá trị cho ComboBox
                guna2TextBox6.Text = row.Cells["SDT"].Value.ToString();
                guna2TextBox8.Text = row.Cells["Email"].Value.ToString();
                guna2TextBox9.Text = row.Cells["Tongmua"].Value.ToString();
                guna2TextBox10.Text = row.Cells["Tongno"].Value.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            using (FormSelectProduct formSelect = new FormSelectProduct())
            {
                // Mở form select sản phẩm và đợi kết quả
                if (formSelect.ShowDialog() == DialogResult.OK)
                {
                    // Lấy sản phẩm đã chọn từ FormSelectProduct
                    Product selectedProduct = formSelect.SelectedProduct;

                    // Thêm sản phẩm vào DataGridView (trong form chính)
                    SPPHIEU.Rows.Add(selectedProduct.MaSP, selectedProduct.TenSP, selectedProduct.SoLuongCon, selectedProduct.DonGia);
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SPPHIEU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = SPPHIEU.Rows[e.RowIndex];

                guna2TextBox2.Text = row.Cells["MaPhieu"].Value.ToString();
                guna2TextBox3.Text = row.Cells["NguoiGiao"].Value.ToString();
                guna2TextBox1.Text = row.Cells["SoLuong"].Value.ToString();
                CBNCC.SelectedValue = row.Cells["MaSP2"].Value.ToString();
                guna2DateTimePicker1.Value = DateTime.Parse(row.Cells["ThoiGian"].Value.ToString());
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
                guna2ComboBox2.SelectedValue = row.Cells["MaNhaCungCap"].Value.ToString();
            }
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            AddNewPhieuNhap();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string xmlFilePath = "PhieuNhap.xml";
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFilePath);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["MaPhieu"].ToString() == guna2TextBox2.Text) // Tìm phiếu theo Mã Phiếu
                {
                    // Cập nhật thông tin
                    row["NguoiGiao"] = guna2TextBox3.Text;
                    row["SoLuong"] = guna2TextBox1.Text;
                    row["MaSP"] = CBNCC.SelectedValue.ToString();
                    row["ThoiGian"] = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    row["GhiChu"] = txtGhiChu.Text;
                    row["MaNhaCungCap"] = guna2ComboBox2.SelectedValue.ToString();
                    break;
                }
            }

            // Lưu lại file XML
            dataSet.WriteXml(xmlFilePath);

            // Reload lại DataGridView
            LoadPhieuNhap();

            MessageBox.Show("Sửa phiếu nhập thành công!");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            AddNewManufacturer();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            UpdateManufacturer();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn Mã nhà cung cấp chưa
            if (string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?",
                                               "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                DeleteManufacturer();
            }
        }
    }
}
