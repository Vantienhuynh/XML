using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyKhoSieuThi
{
    internal class ProductManager
    {
        private string _xmlFilePath;
        private ImageManager _imageManager;

        public ProductManager(string xmlFilePath, string imageFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _imageManager = new ImageManager(imageFilePath);
        }
        public void AddProduct(string maSP, string tenSP, string soLuongCon, string donGia, string nsx, string ngayHetHan, string loaiHang, string donViTinh, string hinh1 = null, string hinh2 = null, string hinh3 = null)
        {
            var doc = XDocument.Load(_xmlFilePath);
            int maxID = doc.Descendants("Product")
                   .Select(p => int.Parse(p.Element("ID")?.Value ?? "0"))
                   .DefaultIfEmpty(0)
                   .Max();

            // Tăng ID mới
            int newID = maxID + 1;

            var newProduct = new XElement("Product",
                new XElement("ID", newID),
                new XElement("MaSP", maSP),
                new XElement("TenSP", tenSP),
                new XElement("SoLuongCon", soLuongCon),
                new XElement("DonGia", donGia),
                new XElement("NSX", nsx),
                new XElement("NgayHetHan", ngayHetHan),
                new XElement("LoaiHang", loaiHang),
                new XElement("DonViTinh", donViTinh)
            );

            doc.Element("Products")?.Add(newProduct);
            doc.Save(_xmlFilePath);
            _imageManager.AddImages(maSP);
        }

        // Hàm sửa sản phẩm
        public bool UpdateProduct(string id, string maSP, string tenSP, string soLuong, string donGia, string nsx, string ngayHetHan, string loaiHang, string donViTinh)
        {
            try
            {
                // Tải file XML
                var doc = XDocument.Load(_xmlFilePath);

                // Tìm sản phẩm cần cập nhật
                var productToUpdate = doc.Descendants("Product")
                                         .FirstOrDefault(p => p.Element("ID")?.Value == id);

                if (productToUpdate != null)
                {
                    // Cập nhật thông tin
                    productToUpdate.Element("MaSP")?.SetValue(maSP);
                    productToUpdate.Element("TenSP")?.SetValue(tenSP);
                    productToUpdate.Element("SoLuongCon")?.SetValue(soLuong);
                    productToUpdate.Element("DonGia")?.SetValue(donGia);
                    productToUpdate.Element("NSX")?.SetValue(nsx);
                    productToUpdate.Element("NgayHetHan")?.SetValue(ngayHetHan);
                    productToUpdate.Element("LoaiHang")?.SetValue(loaiHang);
                    productToUpdate.Element("DonViTinh")?.SetValue(donViTinh);

                    // Lưu lại file XML
                    doc.Save(_xmlFilePath);

                    return true;
                }

                return false; // Không tìm thấy sản phẩm để cập nhật
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                return false;
            }
        }

        // Hàm xóa sản phẩm
        public bool DeleteProductById(string id)
        {
            try
            {
                // Tải file XML
                var doc = XDocument.Load(_xmlFilePath);

                // Tìm sản phẩm với ID tương ứng
                var productToDelete = doc.Descendants("Product")
                                         .FirstOrDefault(p => p.Element("ID")?.Value == id);

                if (productToDelete != null)
                {
                    // Xóa sản phẩm khỏi file XML
                    productToDelete.Remove();

                    // Lưu lại file XML
                    doc.Save(_xmlFilePath);

                    // Cập nhật lại ID để đảm bảo liên tục
                    UpdateProductIds();

                    return true;
                }
                else
                {
                    // Không tìm thấy sản phẩm
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                Console.WriteLine($"Lỗi khi xóa sản phẩm: {ex.Message}");
                return false;
            }
        }

        private void UpdateProductIds()
        {
            // Tải file XML
            var doc = XDocument.Load(_xmlFilePath);

            // Lấy danh sách tất cả sản phẩm
            var products = doc.Descendants("Product").ToList();

            // Cập nhật lại ID (bắt đầu từ 1)
            int newId = 1;
            foreach (var product in products)
            {
                product.Element("ID")?.SetValue(newId.ToString());
                newId++;
            }

            // Lưu lại file XML
            doc.Save(_xmlFilePath);
        }

        // Hàm tìm kiếm sản phẩm
        public List<string[]> SearchProduct(string keyword)
        {
            var doc = XDocument.Load(_xmlFilePath);

            var products = from p in doc.Descendants("Product")
                           where (p.Element("MaSP")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                  p.Element("TenSP")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                  p.Element("LoaiHang")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                  p.Element("DonViTinh")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                  p.Element("NSX")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                  p.Element("NgayHetHan")?.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)
                           select new string[]
                           {
                       p.Element("ID")?.Value ?? "",
                       p.Element("MaSP")?.Value ?? "",
                       p.Element("TenSP")?.Value ?? "",
                       p.Element("SoLuongCon")?.Value ?? "",
                       p.Element("DonGia")?.Value ?? "",
                       p.Element("NSX")?.Value ?? "",
                       p.Element("NgayHetHan")?.Value ?? "",
                       p.Element("LoaiHang")?.Value ?? "",
                       p.Element("DonViTinh")?.Value ?? ""
                           };

            return products.ToList();
        }
    }
}
