using Guna.UI2.WinForms;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
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
            LoadPhieuXuat();
            //LoadComboBoxMaSP();
            LoadComboBoxMaNCC();
            LoadComboBoxMaNCC2();
            // Gán dữ liệu cho ComboBox Status
            guna2ComboBox3.Items.Clear();
            guna2ComboBox3.Items.Add("Hoạt động");
            guna2ComboBox3.Items.Add("Không hoạt động");

            // Đặt giá trị mặc định là "Hoạt động"
            guna2ComboBox3.SelectedIndex = 0;


            var data = LoadDataFromXml("PhieuNhap.xml");

            // Hiển thị dữ liệu lên Chart
            DisplayDataOnChart(data);
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
            SPPHIEU2.Rows.Clear();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int rowIndex = SPPHIEU2.Rows.Add();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    SPPHIEU2.Rows[rowIndex].Cells[i].Value = row.ItemArray[i];
                }
            }
        }
        private void LoadPhieuXuat()
        {

            string xmlFilePath = "PhieuXuat.xml";

            // Tạo một DataSet để chứa dữ liệu từ file XML
            DataSet dataSet = new DataSet();

            // Đọc dữ liệu từ file XML vào DataSet
            dataSet.ReadXml(xmlFilePath);
            GRPX.Rows.Clear();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int rowIndex = GRPX.Rows.Add();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    GRPX.Rows[rowIndex].Cells[i].Value = row.ItemArray[i];
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
        //private void LoadComboBoxMaSP()
        //{
        //    DataSet dataSet = new DataSet();
        //    dataSet.ReadXml("products.xml");

        //    CBNCC.DataSource = dataSet.Tables[0];
        //    CBNCC.DisplayMember = "MaSP";
        //    CBNCC.ValueMember = "MaSP";
        //}
        private void LoadComboBoxMaNCC()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("Manufacturers.xml");

            guna2ComboBox2.DataSource = dataSet.Tables[0];
            guna2ComboBox2.DisplayMember = "Code";
            guna2ComboBox2.ValueMember = "Code";
        }
        private void LoadComboBoxMaNCC2()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("Manufacturers.xml");

            guna2ComboBox4.DataSource = dataSet.Tables[0];
            guna2ComboBox4.DisplayMember = "Code";
            guna2ComboBox4.ValueMember = "Code";
        }
        private void AddNewPhieuNhap()
        {
            string xmlPhieuNhapPath = "PhieuNhap.xml";
            string xmlProductPath = "products.xml";

            // Đọc dữ liệu từ PhieuNhap.xml
            DataSet phieuNhapDataSet = new DataSet();
            phieuNhapDataSet.ReadXml(xmlPhieuNhapPath);

            // Danh sách để chứa các mã sản phẩm và số lượng nhập
            List<(string MaSP, int SoLuongNhap)> productList = new List<(string, int)>();

            // Duyệt qua các dòng trong DataGridView để lấy mã sản phẩm và số lượng nhập
            foreach (DataGridViewRow row in SPPHIEU.Rows)
            {
                if (!row.IsNewRow && row.Cells["MaSPP"].Value != null && row.Cells["SoLuongCon"].Value != null)
                {
                    string maSP = row.Cells["MaSPP"].Value.ToString();
                    int soLuongNhap = int.Parse(row.Cells["SoLuongCon"].Value.ToString());
                    productList.Add((maSP, soLuongNhap));
                }
            }

            // Thêm phiếu nhập mới vào DataSet
            DataRow newRow = phieuNhapDataSet.Tables[0].NewRow();

            // Lấy thông tin từ form
            newRow["MaPhieu"] = guna2TextBox2.Text;
            newRow["NguoiGiao"] = guna2TextBox3.Text;
            newRow["ThoiGian"] = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            newRow["GhiChu"] = txtGhiChu.Text;
            newRow["MaNhaCungCap"] = guna2ComboBox2.SelectedValue.ToString();

            // Gán giá trị cho MaSP theo dạng chuỗi, mỗi mã sản phẩm kèm theo số lượng nhập
            string maSPString = string.Join(",", productList.Select(p => $"{p.MaSP}:{p.SoLuongNhap}"));
            newRow["MaSP"] = maSPString;

            // Thêm phiếu nhập vào DataSet
            phieuNhapDataSet.Tables[0].Rows.Add(newRow);

            // Ghi lại dữ liệu vào PhieuNhap.xml
            phieuNhapDataSet.WriteXml(xmlPhieuNhapPath);

            // Cập nhật số lượng trong Product.xml
            DataSet productDataSet = new DataSet();
            productDataSet.ReadXml(xmlProductPath);

            foreach (DataRow productRow in productDataSet.Tables[0].Rows)
            {
                string maSP = productRow["MaSP"].ToString();

                // Duyệt qua tất cả các sản phẩm trong phiếu nhập và cập nhật số lượng
                foreach (var product in productList)
                {
                    if (maSP == product.MaSP)
                    {
                        int currentSoLuongCon = int.Parse(productRow["SoLuongCon"].ToString());
                        productRow["SoLuongCon"] = currentSoLuongCon + product.SoLuongNhap; // Tăng số lượng tồn
                    }
                }
            }

            // Ghi lại dữ liệu vào Product.xml
            productDataSet.WriteXml(xmlProductPath);

            // Cập nhật DataGridView và giao diện
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

                //CBNCC.SelectedValue = row.Cells["MaSP2"].Value.ToString();
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
        private void AddNewPhieuXuat()
        {
            string xmlPhieuNhapPath = "PhieuXuat.xml";
            string xmlProductPath = "products.xml";

            // Đọc dữ liệu từ PhieuNhap.xml
            DataSet phieuNhapDataSet = new DataSet();
            phieuNhapDataSet.ReadXml(xmlPhieuNhapPath);

            // Danh sách để chứa các mã sản phẩm và số lượng nhập
            List<(string MaSP, int SoLuongNhap)> productList = new List<(string, int)>();

            // Duyệt qua các dòng trong DataGridView để lấy mã sản phẩm và số lượng nhập
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["MaSPP2"].Value != null && row.Cells["SLC2"].Value != null)
                {
                    string maSP = row.Cells["MaSPP2"].Value.ToString();
                    int soLuongNhap = int.Parse(row.Cells["SLC2"].Value.ToString());
                    productList.Add((maSP, soLuongNhap));
                }
            }

            // Thêm phiếu nhập mới vào DataSet
            DataRow newRow = phieuNhapDataSet.Tables[0].NewRow();

            // Lấy thông tin từ form
            newRow["MaPhieu"] = guna2TextBox12.Text;
            newRow["NguoiGiao"] = guna2TextBox11.Text;
            newRow["ThoiGian"] = guna2DateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            newRow["GhiChu"] = guna2TextBox1.Text;
            newRow["MaNhaCungCap"] = guna2ComboBox4.SelectedValue.ToString();

            // Gán giá trị cho MaSP theo dạng chuỗi, mỗi mã sản phẩm kèm theo số lượng nhập
            string maSPString = string.Join(",", productList.Select(p => $"{p.MaSP}:{p.SoLuongNhap}"));
            newRow["MaSP"] = maSPString;

            // Thêm phiếu nhập vào DataSet
            phieuNhapDataSet.Tables[0].Rows.Add(newRow);

            // Ghi lại dữ liệu vào PhieuNhap.xml
            phieuNhapDataSet.WriteXml(xmlPhieuNhapPath);

            // Cập nhật số lượng trong Product.xml
            DataSet productDataSet = new DataSet();
            productDataSet.ReadXml(xmlProductPath);

            foreach (DataRow productRow in productDataSet.Tables[0].Rows)
            {
                string maSP = productRow["MaSP"].ToString();

                // Duyệt qua tất cả các sản phẩm trong phiếu nhập và cập nhật số lượng
                foreach (var product in productList)
                {
                    if (maSP == product.MaSP)
                    {
                        int currentSoLuongCon = int.Parse(productRow["SoLuongCon"].ToString());
                        productRow["SoLuongCon"] = currentSoLuongCon - product.SoLuongNhap; // Tăng số lượng tồn
                    }
                }
            }

            // Ghi lại dữ liệu vào Product.xml
            productDataSet.WriteXml(xmlProductPath);

            // Cập nhật DataGridView và giao diện
            LoadPhieuNhap();
            LoadData();

            MessageBox.Show("Thêm phiếu xuất và cập nhật số lượng sản phẩm thành công!");
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            AddNewPhieuXuat();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            using (FormSelectProduct formSelect = new FormSelectProduct())
            {
                // Mở form select sản phẩm và đợi kết quả
                if (formSelect.ShowDialog() == DialogResult.OK)
                {
                    // Lấy sản phẩm đã chọn từ FormSelectProduct
                    Product selectedProduct = formSelect.SelectedProduct;

                    // Thêm sản phẩm vào DataGridView (trong form chính)
                    guna2DataGridView1.Rows.Add(selectedProduct.MaSP, selectedProduct.TenSP, selectedProduct.SoLuongCon, selectedProduct.DonGia);
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void SPPHIEU2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void btnPXX_Click(object sender, EventArgs e)
        {
            var results = SearchPhieuXuat(txtPXX.Text, "PhieuXuat.xml");

            // Xóa tất cả các dòng cũ, giữ nguyên header
            GRPX.Rows.Clear();

            // Thêm dữ liệu mới vào DataGridView
            foreach (var row in results)
            {
                GRPX.Rows.Add(row);
            }
        }

        public List<string[]> SearchPhieuXuat(string keyword, string path)
        {
            var doc = XDocument.Load(path);  // _xmlFilePath là đường dẫn tới file XML

            var phieuNhaps = from p in doc.Descendants("PhieuNhap")
                             where (p.Element("MaPhieu")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                    p.Element("NguoiGiao")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                    p.Element("MaSP")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                    p.Element("ThoiGian")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                    p.Element("GhiChu")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                    p.Element("MaNhaCungCap")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)
                             select new string[]
                             {
                         p.Element("MaPhieu")?.Value ?? "",
                         p.Element("NguoiGiao")?.Value ?? "",
                         p.Element("SoLuong")?.Value ?? "",
                         p.Element("MaSP")?.Value ?? "",
                         p.Element("ThoiGian")?.Value ?? "",
                         p.Element("GhiChu")?.Value ?? "",
                         p.Element("MaNhaCungCap")?.Value ?? ""
                             };

            return phieuNhaps.ToList();
        }

        private void btnPX_Click(object sender, EventArgs e)
        {
            var results = SearchPhieuXuat(txtPN.Text, "PhieuNhap.xml");

            // Xóa tất cả các dòng cũ, giữ nguyên header
            SPPHIEU2.Rows.Clear();

            // Thêm dữ liệu mới vào DataGridView
            foreach (var row in results)
            {
                SPPHIEU2.Rows.Add(row);
            }
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
        private Dictionary<string, int> LoadDataFromXml(string filePath)
        {
            // Tạo từ điển để lưu số lượng phiếu nhập theo ngày
            var result = new Dictionary<string, int>();

            // Đọc file XML
            XDocument doc = XDocument.Load(filePath);

            // Duyệt qua các phần tử <PhieuNhap>
            var phieuNhaps = doc.Descendants("PhieuNhap");
            foreach (var phieu in phieuNhaps)
            {
                // Lấy ngày từ <ThoiGian> và chỉ giữ phần yyyy-MM-dd
                string date = DateTime.Parse(phieu.Element("ThoiGian")?.Value).ToString("yyyy-MM-dd");

                // Cộng dồn số lượng phiếu nhập theo ngày
                if (result.ContainsKey(date))
                {
                    result[date]++;
                }
                else
                {
                    result[date] = 1;
                }
            }

            return result; // Trả về từ điển: ngày - số lượng phiếu
        }

        private void DisplayDataOnChart(Dictionary<string, int> data)
        {
            // Xóa các series cũ (nếu có)
            chart1.Series.Clear();

            // Tạo series mới
            var series = new Series("Tổng số phiếu nhập theo ngày")
            {
                ChartType = SeriesChartType.Column // Biểu đồ cột
            };

            // Thêm dữ liệu vào series
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value); // X: ngày, Y: số lượng
            }

            // Thêm series vào Chart
            chart1.Series.Add(series);

            // Tùy chỉnh Chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Tổng số phiếu nhập theo ngày");
            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Số lượng phiếu nhập";
            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    
}
}
