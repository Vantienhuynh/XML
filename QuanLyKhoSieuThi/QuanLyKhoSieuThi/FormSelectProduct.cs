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
    public partial class FormSelectProduct : Form
    {
        public Product SelectedProduct { get; private set; }

        public FormSelectProduct()
        {
            InitializeComponent();
            LoadData();
        }

        private void FormSelectProduct_Load(object sender, EventArgs e)
        {

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

        private void Datasp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin sản phẩm từ dòng đã chọn
                var selectedRow = Datasp.Rows[e.RowIndex];
                SelectedProduct = new Product
                {
                    ID = Convert.ToInt32(selectedRow.Cells["ID"].Value),
                    MaSP = selectedRow.Cells["MaSP"].Value.ToString(),
                    TenSP = selectedRow.Cells["TenSP"].Value.ToString(),
                    SoLuongCon = Convert.ToInt32(selectedRow.Cells["SoLuongCon"].Value),
                    DonGia = Convert.ToDecimal(selectedRow.Cells["DonGia"].Value),
                    NSX = selectedRow.Cells["NSX"].Value.ToString(),
                    NgayHetHan = selectedRow.Cells["NgayHetHan"].Value.ToString(),
                    LoaiHang = selectedRow.Cells["LoaiHang"].Value.ToString(),
                    DonViTinh = selectedRow.Cells["DonViTinh"].Value.ToString()
                };

                // Đóng form và trả về kết quả
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}