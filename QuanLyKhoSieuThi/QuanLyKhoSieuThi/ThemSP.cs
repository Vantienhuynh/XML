using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Guna.UI2.WinForms;

namespace QuanLyKhoSieuThi
{

    public partial class ThemSP : Form
    {
        private ProductManager _productManager;
        private ImageManager _imageManager;
        string hinh1 = null, hinh2 = null, hinh3 = null;
        public ThemSP()
        {

            _productManager = new ProductManager("products.xml", "Hinhanh.xml");
            _imageManager = new ImageManager("Hinhanh.xml");

            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThemSP_Load(object sender, EventArgs e)
        {
            LoadProductCategories();
            LoadManufacturer();
        }
        private void LoadProductCategories()
        {
            // Đọc file XML
            string xmlFilePath = "ProductCategories.xml";
            var doc = XDocument.Load(xmlFilePath);

            // Trích xuất các loại sản phẩm từ file XML
            var categories = from category in doc.Descendants("Category")
                             select new
                             {
                                 ID = category.Element("ID")?.Value,
                                 Name = category.Element("Name")?.Value
                             };

            // Thêm các loại sản phẩm vào ComboBox
            foreach (var category in categories)
            {
                txtLoai.Items.Add(new { category.ID, category.Name });
            }

            // Hiển thị tên loại sản phẩm trong ComboBox, nhưng lưu ID thực tế
            txtLoai.DisplayMember = "Name";  // Hiển thị tên loại sản phẩm
            txtLoai.ValueMember = "ID";     // Lưu ID loại sản phẩm
        }
        private void LoadManufacturer()
        {
            // Đọc file XML
            string xmlFilePath = "Manufacturers.xml";
            var doc = XDocument.Load(xmlFilePath);

            // Trích xuất các nhà sản xuất từ file XML
            var manufacturers = from manufacturer in doc.Descendants("Manufacturer")
                                select new
                                {
                                    Code = manufacturer.Element("Code")?.Value,
                                    Name = manufacturer.Element("Name")?.Value
                                };

            // Thêm các nhà sản xuất vào ComboBox
            foreach (var manufacturer in manufacturers)
            {
                txtNSX.Items.Add(new { manufacturer.Code, manufacturer.Name });
            }

            // Hiển thị tên nhà sản xuất trong ComboBox, nhưng lưu Code thực tế
            txtNSX.DisplayMember = "Name";  // Hiển thị tên nhà sản xuất
            txtNSX.ValueMember = "Code";    // Lưu Code nhà sản xuất
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu có bị bỏ trống hay không
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtSL.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text) ||
                string.IsNullOrWhiteSpace(txtNSX.Text) ||
                string.IsNullOrWhiteSpace(txtNgayHH.Text) ||
                string.IsNullOrWhiteSpace(txtLoai.Text) ||
                string.IsNullOrWhiteSpace(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu có trường bị trống
            }

            // Kiểm tra số lượng và đơn giá có phải số hợp lệ không
            if (!int.TryParse(txtSL.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDongia.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        

            

            // Nếu dữ liệu hợp lệ, thêm sản phẩm
            _productManager.AddProduct(
                txtMaSP.Text,
                txtTenSP.Text,
                txtSL.Text,
                txtDongia.Text,
                txtNSX.Text,
                txtNgayHH.Text,
                txtLoai.Text,
                txtDonVi.Text
            );
            _imageManager.AddImages(txtMaSP.Text, hinh1, hinh2, hinh3);

            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // Đóng form sau khi thêm thành công
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn ảnh đã chọn
                    hinh1 = openFileDialog.FileName;

                    // Cập nhật hình ảnh vào Guna2ImageButton1
                    guna2ImageButton1.Image = Image.FromFile(hinh1);
                    guna2ImageButton3.Image = Image.FromFile(hinh1);
                }
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn ảnh đã chọn
                    hinh2 = openFileDialog.FileName;

                    // Cập nhật hình ảnh vào Guna2ImageButton2
                    guna2ImageButton4.Image = Image.FromFile(hinh2);
                }
            }
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn ảnh đã chọn
                    hinh3 = openFileDialog.FileName;

                    // Cập nhật hình ảnh vào Guna2ImageButton3
                    guna2ImageButton2.Image = Image.FromFile(hinh3);
                }
            }
        }
       
    }
}
