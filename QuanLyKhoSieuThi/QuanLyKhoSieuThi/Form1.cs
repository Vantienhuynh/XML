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

        private void GRNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
