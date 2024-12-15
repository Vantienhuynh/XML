using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyKhoSieuThi
{
    public class ImageManager
    {
        private string _xmlFilePath;

        public ImageManager(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
        }

        public void AddImages(string productId, string hinh1 = null, string hinh2 = null, string hinh3 = null)
        {
            // Tạo phần tử hình ảnh mới
            XElement newImages = new XElement("ProductImages",
                new XElement("ProductID", productId),
                new XElement("Hinh1", hinh1),
                new XElement("Hinh2", hinh2),
                new XElement("Hinh3", hinh3)
            );

            // Đọc file XML hiện tại
            XDocument doc = XDocument.Load(_xmlFilePath);

            // Thêm thông tin hình ảnh mới vào danh sách
            doc.Root.Add(newImages);

            // Lưu lại file XML
            doc.Save(_xmlFilePath);
        }
    }

}
