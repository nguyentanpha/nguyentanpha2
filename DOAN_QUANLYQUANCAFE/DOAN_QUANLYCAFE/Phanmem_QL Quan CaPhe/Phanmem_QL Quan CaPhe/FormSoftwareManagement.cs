using Phanmem_QL_Quan_CaPhe.DAO;
using Phanmem_QL_Quan_CaPhe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanmem_QL_Quan_CaPhe
{
    public partial class FormSoftwareManagement : Form
    {
        BindingSource foodList = new BindingSource();
        public FormSoftwareManagement()
        {
            InitializeComponent();
            LoadTong();
        }
        #region Menthods
        void LoadTong()
        {
            dtgvThucAnUong.DataSource = foodList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkNgayBatDau.Value, dtpkNgayKetThuc.Value);
            LoadListFood();
            AddFoodBinding();
            LoadCategoryIntoCombobox(cbDanhMucMon_ThucAnUong);

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkNgayBatDau.Value = new DateTime(today.Year, today.Month, 1);
            dtpkNgayKetThuc.Value = dtpkNgayBatDau.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvDoanhThu.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadListFood()
        {
            dtgvThucAnUong.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddFoodBinding()
        {
            txbTenMon_ThucAnUong.DataBindings.Add(new Binding("Text", dtgvThucAnUong.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbMaMon_ThucAnUong.DataBindings.Add(new Binding("Text", dtgvThucAnUong.DataSource, "id", true, DataSourceUpdateMode.Never));
            nmGiaMon_ThucAnUong.DataBindings.Add(new Binding("Value", dtgvThucAnUong.DataSource, "price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        #endregion
        #region events
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkNgayBatDau.Value, dtpkNgayKetThuc.Value);
        }
        private void btnXemMon_ThucAnUong_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btnThemMon_ThucAnUong_Click(object sender, EventArgs e)
        {
            string name = txbTenMon_ThucAnUong.Text;
            int categoryID = (cbDanhMucMon_ThucAnUong.SelectedItem as Category).ID;
            float price = (float)nmGiaMon_ThucAnUong.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnSuaMon_ThucAnUong_Click(object sender, EventArgs e)
        {
            string name = txbTenMon_ThucAnUong.Text;
            int categoryID = (cbDanhMucMon_ThucAnUong.SelectedItem as Category).ID;
            float price = (float)nmGiaMon_ThucAnUong.Value;
            int id = Convert.ToInt32(txbMaMon_ThucAnUong.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
               
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }
        private void btnXoaMon_ThucAnUong_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbMaMon_ThucAnUong.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
              
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }





        #endregion

        private void btnTimKiemMon_ThucAnUong_Click(object sender, EventArgs e)
        {

        }
    }
}
