using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBANSACH
{
    public partial class QLKHACHHANG : Form
    {
        public QLKHACHHANG()
        {
            InitializeComponent();
            Loadlistview();
            loadngaythangnam();
        }
        void Cauhinh()
        {
            LvKH.View = View.Details;
            LvKH.GridLines = true;
            LvKH.FullRowSelect = true;
            LvKH.MultiSelect = false;
            if (LvKH.Columns.Count==0)
            {
                LvKH.Columns.Add("Mã khách hàng");
                LvKH.Columns.Add("Tên khách hàng");
                LvKH.Columns.Add("Ngày sinh");
                LvKH.Columns.Add("Giới tính");
                LvKH.Columns.Add("Chứng minh thư");
                LvKH.Columns.Add("Số điện thoại");
                LvKH.Columns.Add("Địa chỉ");
            }
            LvKH.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        void loadngaythangnam()
        {
            DateTime date = DateTime.Now;
            cbbns.Items.Clear();
            if (tbns.Text == string.Empty)
                tbns.Text = date.Year.ToString();
            if (Convert.ToInt32(cbbts.Items.Count) < 12)
                for (int i = 1; i <= 12; i++)
                    cbbts.Items.Add(i);
            if (cbbts.Text == "1" || cbbts.Text == "3" || cbbts.Text == "5" || cbbts.Text == "7" || cbbts.Text == "8" || cbbts.Text == "11")
                for (int i = 1; i <= 31; i++)
                    cbbns.Items.Add(i);
            else if (cbbts.Text == "2")
            {
                if (Convert.ToInt32(tbns.Text) % 400 == 0 || Convert.ToInt32(tbns.Text) % 4 == 0 && Convert.ToInt32(tbns.Text) % 100 != 0)
                    for (int i = 1; i <= 29; i++)
                        cbbns.Items.Add(i);
                else
                    for (int i = 1; i <= 28; i++)
                        cbbns.Items.Add(i);
            }
            else
                for (int i = 1; i <= 30; i++)
                    cbbns.Items.Add(i);
        }
        void Loadlistview()
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select * from KHACHHANG";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    ListViewItem item = new ListViewItem();
                    LvKH.Items.Add(item);
                    item.Text = render["MAKH"].ToString();
                    item.SubItems.Add(render["TENKH"].ToString());
                    item.SubItems.Add(render["NGAYSINH"].ToString());
                    item.SubItems.Add(render["GIOITINH"].ToString());
                    item.SubItems.Add(render["CMT"].ToString());
                    item.SubItems.Add(render["SDT"].ToString());
                    item.SubItems.Add(render["DIACHI"].ToString());
                }
                render.Close();
                connection.Close();
            }
            Cauhinh();
        }
        int CheckKH(string makh)
        {
            int result;
            using (SqlConnection connetion=new SqlConnection(ConnectionString.connectionString))
            {
                connetion.Open();
                string query = "select count(*) from KHACHHANG where MAKH=@makh";
                SqlCommand cmd = new SqlCommand(query, connetion);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
                connetion.Close();
            }
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbtenkh.Text) && !string.IsNullOrEmpty(cbbns.Text) && !string.IsNullOrEmpty(cbbts.Text) && !string.IsNullOrEmpty(tbns.Text) && !string.IsNullOrEmpty(tbcmt.Text) && !string.IsNullOrEmpty(tbsdt.Text) && !string.IsNullOrEmpty(tbdiachi.Text))
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    if (CheckKH(tbcmt.Text) == 1)
                    {
                        MessageBox.Show("Khách hàng đã có trong hệ thống", "Thông báo");
                    }
                    else
                    {
                        connection.Open();
                        string insert = "insert into KHACHHANG values(@makh,@tenkh,@ngaysinh,@gioitinh,@cmt,@sdt,@diachi)";
                        SqlCommand cmd = new SqlCommand(insert, connection);
                        cmd.Parameters.AddWithValue("@makh", tbcmt.Text);
                        cmd.Parameters.AddWithValue("@tenkh", tbtenkh.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", tbns.Text + "/" + cbbts.Text + "/" + cbbns.Text);
                        if (cbsexnu.Checked == true)
                            cmd.Parameters.AddWithValue("@gioitinh", 1);
                        else if (cbsexkxd.Checked == true)
                            cmd.Parameters.AddWithValue("@gioitinh", 2);
                        else
                            cmd.Parameters.AddWithValue("@gioitinh", 0);
                        cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                        cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                        cmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                        cmd.ExecuteNonQuery();
                        if (CheckKH(tbcmt.Text) == 1)
                        {
                            ListViewItem item = new ListViewItem();
                            LvKH.Items.Add(item);
                            item.Text = tbcmt.Text;
                            item.SubItems.Add(tbtenkh.Text);
                            item.SubItems.Add(cbbns.Text + "/" + cbbts.Text + "/" + tbns.Text);
                            if (cbsexnu.Checked == true)
                                item.SubItems.Add("Nữ");
                            else if (cbsexkxd.Checked == true)
                                item.SubItems.Add("Không xác định");
                            else
                                item.SubItems.Add("Nam");
                            item.SubItems.Add(tbcmt.Text);
                            item.SubItems.Add(tbsdt.Text);
                            item.SubItems.Add(tbdiachi.Text);
                            MessageBox.Show("Thêm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thêm thất bại", "Thông báo");
                    }
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin khách hàng", "Thông báo");
        }

        private void tbns_Leave(object sender, EventArgs e)
        {
            loadngaythangnam();
        }

        private void cbbts_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbns.Text = "1";
            loadngaythangnam();
        }

        private void cbsexnu_Click(object sender, EventArgs e)
        {
            if (cbsexnu.Checked == true)
                cbsexkxd.Enabled = false;
            else
                cbsexkxd.Enabled = true;
        }

        private void cbsexkxd_Click(object sender, EventArgs e)
        {
            if (cbsexkxd.Checked == true)
                cbsexnu.Enabled = false;
            else
                cbsexnu.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbtenkh.Text))
                FindKH(tbcmt.Text);
            else
                MessageBox.Show("Hãy nhập tên khách hàng cần tìm", "Thông báo");
        }
        void FindKH(string makh)
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                LvKH.Items.Clear();
                connection.Open();
                string query = "select * from KHACHHANG where MAKH=@makh";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.ExecuteNonQuery();
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    ListViewItem item = new ListViewItem();
                    LvKH.Items.Add(item);
                    item.Text = render["MAKH"].ToString();
                    item.SubItems.Add(render["TENKH"].ToString());
                    item.SubItems.Add(render["NGAYSINH"].ToString());
                    item.SubItems.Add(render["GIOITINH"].ToString());
                    item.SubItems.Add(render["CMT"].ToString());
                    item.SubItems.Add(render["SDT"].ToString());
                    item.SubItems.Add(render["DIACHI"].ToString());
                }
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LvKH.SelectedItems.Count > 0)
            {
                if (KTHoadon(LvKH.FocusedItem.Text) == 0)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "delete from KHACHHANG where MAKH=@makh";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@makh", LvKH.FocusedItem.Text);
                        cmd.ExecuteNonQuery();
                        if (CheckKH(LvKH.FocusedItem.Text) == 0)
                        {
                            LvKH.FocusedItem.Remove();
                            MessageBox.Show("Xóa thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Xóa thất bại", "Thông báo");
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Không thể xóa do khách hàng đã tồn tại trong hóa đơn", "Thông báo");
            }
            else
                MessageBox.Show("Hãy chọn khách hàng cần xóa", "Thông báo");
        }
        int KTHoadon(string a)
        {
            int resutl;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string chek = "Select count(*) from HOADON where MAKH=@makh";
                SqlCommand cmd = new SqlCommand(chek, connection);
                cmd.Parameters.AddWithValue("@makh", a);
                cmd.ExecuteNonQuery();
                resutl = (int)cmd.ExecuteScalar();
                connection.Close();
            }
            if (resutl != 0)
                return 1;
            else
                return 0;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (LvKH.SelectedItems.Count > 0)
            {
                if (tbtenkh.Text == string.Empty && cbbns.Text == string.Empty && cbbts.Text == string.Empty && tbns.Text == string.Empty)
                {
                    MessageBox.Show("Hãy nhập thông tin cần sửa", "Thông báo");
                }
                else if (tbtenkh.Text != string.Empty && cbbns.Text != string.Empty && cbbts.Text != string.Empty && tbns.Text != string.Empty)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "update KHACHHANG set TENKH=@tenkh,NGAYSINH=@ngaysinh,GIOITINH=@gt,CMT=@cmt,SDT=@sdt,DIACHI=@diachi where MAKH=@makh";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@makh", LvKH.FocusedItem.Text);
                        cmd.Parameters.AddWithValue("@tenkh", tbtenkh.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", tbns.Text + "/" + cbbts.Text + "/" + cbbns.Text);
                        if (cbsexnu.Checked == true)
                            cmd.Parameters.AddWithValue("@gt", 1);
                        else if (cbsexkxd.Checked == true)
                            cmd.Parameters.AddWithValue("@gt", 2);
                        else
                            cmd.Parameters.AddWithValue("@gt", 0);
                        cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                        cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                        cmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                        cmd.ExecuteNonQuery();

                        string chekckh = "select * from KHACHHANG where MAKH=@makh";
                        SqlCommand cmdcheckkh = new SqlCommand(chekckh, connection);
                        cmdcheckkh.Parameters.AddWithValue("@makh", LvKH.FocusedItem.Text);
                        cmdcheckkh.ExecuteNonQuery();
                        SqlDataReader render = cmdcheckkh.ExecuteReader();
                        while (render.Read())
                        {
                            ListViewItem item = new ListViewItem();
                            LvKH.Items.Add(item);
                            item.Text = LvKH.FocusedItem.Text;
                            item.SubItems.Add(render["TENKH"].ToString());
                            item.SubItems.Add(render["NGAYSINH"].ToString());
                            if (Convert.ToInt32(render["GIOITINH"]) == 1)
                                item.SubItems.Add("Nữ");
                            else if (Convert.ToInt32(render["GIOITINH"]) == 2)
                                item.SubItems.Add("Không xác định");
                            else
                                item.SubItems.Add("Nam");
                            item.SubItems.Add(render["CMT"].ToString());
                            item.SubItems.Add(render["SDT"].ToString());
                            item.SubItems.Add(render["DIACHI"].ToString());
                        }
                        LvKH.FocusedItem.Remove();
                        connection.Close();
                        MessageBox.Show("Sửa thành công", "Thông báo");
                    }
                }
                else
                    MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo");
            }
            else
                MessageBox.Show("Hãy chọn khách hàng cần sửa", "Thông báo");
        }
           //LvKH.Columns.Add("Mã khách hàng");
           //     LvKH.Columns.Add("Tên khách hàng");
           //     LvKH.Columns.Add("Ngày sinh");
           //     LvKH.Columns.Add("Giới tính");
           //     LvKH.Columns.Add("Chứng minh thư");
           //     LvKH.Columns.Add("Số điện thoại");
           //     LvKH.Columns.Add("Địa chỉ");
        private void LvKH_DoubleClick(object sender, EventArgs e)
        {
            tbtenkh.Text = LvKH.FocusedItem.SubItems[1].Text;
            tbcmt.Text = LvKH.FocusedItem.SubItems[4].Text;
            tbsdt.Text = LvKH.FocusedItem.SubItems[5].Text;
            tbdiachi.Text = LvKH.FocusedItem.SubItems[6].Text;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select *, DAY(NGAYSINH) as 'ngay',month(NGAYSINH) as 'thang', year(NGAYSINH) as 'nam' from KHACHHANG where MAKH=@makh";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@makh", LvKH.FocusedItem.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    tbns.Text = render["nam"].ToString();
                    cbbts.Text = render["thang"].ToString();
                    cbbns.Text = render["ngay"].ToString();
                    if (Convert.ToInt32(render["GIOITINH"]) == 1)
                        cbsexnu.Checked = true;
                    else if (Convert.ToInt32(render["GIOITINH"]) == 2)
                        cbsexkxd.Checked = true;
                }
                render.Close();
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbtenkh.Clear();
            cbsexnu.Checked = false;
            cbsexkxd.Checked = false;
            tbcmt.Clear();
            tbdiachi.Clear();
            tbsdt.Clear();
            tbtenkh.Focus();
        }
    }
}
