using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoSieuThi
{
    public class Product
    {
        public int ID { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongCon { get; set; }
        public decimal DonGia { get; set; }
        public string NSX { get; set; }
        public string NgayHetHan { get; set; }
        public string LoaiHang { get; set; }
        public string DonViTinh { get; set; }
    }
}
