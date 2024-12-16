using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhoSieuThi
{
    public partial class Sua : Form
    {
        private string _id;
        private ProductManager _productManager;
        private string xmlFilePath = "products.xml";
        private string imagePath = "Hinhanh.xml";

        public Sua(string id, string maSP, string tenSP, string soLuong, string donGia, string nsx, string ngayHetHan, string loaiHang, string donViTinh)
        {
            InitializeComponent();
            _id = id;
            txtMaSP.Text = maSP;
            txtTenSP.Text = tenSP;
            txtSL.Text = soLuong;
            txtDongia.Text = donGia;
            txtNSX.Text = nsx;
            txtNgayHH.Text = ngayHetHan;
            txtLoai.Text = loaiHang;
            txtDonVi.Text = donViTinh;

            _productManager = new ProductManager(xmlFilePath, imagePath);
            LoadProductImagesXmlDocument(maSP);
        }
        private void LoadProductImagesXmlDocument(string maSP)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Hinhanh.xml");

                // Tìm tất cả các ProductImages
                XmlNode productImageNode = doc.SelectSingleNode($"/hinhanh/ProductImages[ProductID='{maSP}']");

                if (productImageNode != null)
                {
                    string hinh1 = productImageNode["Hinh1"]?.InnerText.Trim();
                    string hinh2 = productImageNode["Hinh2"]?.InnerText.Trim();
                    string hinh3 = productImageNode["Hinh3"]?.InnerText.Trim();

                    MessageBox.Show($"Hinh1: {hinh1}, Hinh2: {hinh2}, Hinh3: {hinh3}");

                    // Hiển thị hình ảnh
                    if (!string.IsNullOrEmpty(hinh1) && File.Exists(hinh1))
                        guna2ImageButton3.Image = Image.FromFile(hinh1);

                    if (!string.IsNullOrEmpty(hinh2) && File.Exists(hinh2))
                        guna2ImageButton4.Image = Image.FromFile(hinh2);

                    if (!string.IsNullOrEmpty(hinh3) && File.Exists(hinh3))
                        guna2ImageButton2.Image = Image.FromFile(hinh3);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hình ảnh cho sản phẩm này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtSL.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức sửa trong ProductManager
            bool success = _productManager.UpdateProduct(
                _id,
                txtMaSP.Text,
                txtTenSP.Text,
                txtSL.Text,
                txtDongia.Text,
                txtNSX.Text,
                txtNgayHH.Text,
                txtLoai.Text,
                txtDonVi.Text
            );

            if (success)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng Form sửa
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
