using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
