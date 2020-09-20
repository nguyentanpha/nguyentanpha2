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
    public partial class QLNHANVIEN : Form
    {
        public QLNHANVIEN()
        {
            InitializeComponent();
            loadCV();
            loaditemlv();
            loadngaythangnam();
            capquyen();
        }
        void capquyen()
        {
            if (QLBANSACHMAIN.CHUCVU == 1)
            {
                btadd.Enabled = true;
                btfix.Enabled = true;
                btdel.Enabled = true;
            }
            else
            {
                btadd.Enabled = false;
                btfix.Enabled = false;
                btdel.Enabled = false;
            }

        }
        void loadngaythangnam()
        {
            cbbns.Items.Clear();
            DateTime date = DateTime.Now;
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
        void loaditemlv()
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select *,DAY(NGAYSINH) as 'ngay',month(NGAYSINH) as 'thang',year(NGAYSINH) as 'nam' from NHANVIEN";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    ListViewItem item = new ListViewItem();
                    LvNV.Items.Add(item);
                    item.Text=render["MANV"].ToString();
                    item.SubItems.Add(render["TENNV"].ToString());
                    item.SubItems.Add(render["ngay"].ToString() + "/" + render["thang"].ToString() + "/"+render["nam"].ToString());
                    if(Convert.ToInt32(render["GIOITINH"])==1)
                        item.SubItems.Add("Nữ");
                    else if (Convert.ToInt32(render["GIOITINH"]) == 2)
                        item.SubItems.Add("Không xác định");
                    else
                        item.SubItems.Add("Nam");
                    item.SubItems.Add(render["CMT"].ToString());
                    item.SubItems.Add(render["SDT"].ToString());
                    item.SubItems.Add(render["DIACHI"].ToString());
                    if (Convert.ToInt32(render["CHUCVU"])==1)
                        item.SubItems.Add("Quản trị viên");
                    else
                        item.SubItems.Add("Nhân viên");
                }
                connection.Close();
            }
            CauhinhNV();
        }
        void CauhinhNV()
        {
            LvNV.View = View.Details;
            LvNV.GridLines = true;
            LvNV.FullRowSelect = true;
            LvNV.MultiSelect = false;
            LvNV.Columns.Add("Mã nhân viên");
            LvNV.Columns.Add("Tên nhân viên");
            LvNV.Columns.Add("Ngày sinh");
            LvNV.Columns.Add("Giới tính");
            LvNV.Columns.Add("Chứng minh thư");
            LvNV.Columns.Add("Số điện thoại");
            LvNV.Columns.Add("Địa chỉ");
            LvNV.Columns.Add("Chức vụ");
            LvNV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        void loadCV()
        {
            List<string> CV = new List<string>();
            CV.Add("Quản trị viên");
            CV.Add("Nhân Viên");
            foreach (string item in CV)
                cbbchucvu.Items.Add(item);
            cbbchucvu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbchucvu.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbtennv.Text) && tbcmt.Text==string.Empty && cbbchucvu.Text==string.Empty)
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where TENNV=@tennv";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text == string.Empty && tbcmt.Text != string.Empty && cbbchucvu.Text == string.Empty)
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where CMT=@cmt";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text != string.Empty && tbcmt.Text != string.Empty && cbbchucvu.Text == string.Empty)
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where CMT=@cmt and TENNV=@tennv";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                    cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text != string.Empty && tbcmt.Text == string.Empty && cbbchucvu.Text != string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where CHUCVU=@cv and TENNV=@tennv";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                    if (cbbchucvu.Text == "Quản trị viên")
                        cmd.Parameters.AddWithValue("@cv", 1);
                    else
                        cmd.Parameters.AddWithValue("@cv", 0);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text == string.Empty && tbcmt.Text == string.Empty && cbbchucvu.Text != string.Empty)
            {
                 using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where CHUCVU=@cv";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (cbbchucvu.Text == "Quản trị viên")
                        cmd.Parameters.AddWithValue("@cv", 1);
                    else
                        cmd.Parameters.AddWithValue("@cv", 0);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text != string.Empty && tbcmt.Text != string.Empty && cbbchucvu.Text != string.Empty)
            {
                 using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN where CMT=@cmt and TENNV=@tennv and CHUCVU=@cv";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                    cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                    if (cbbchucvu.Text == "Quản trị viên")
                        cmd.Parameters.AddWithValue("@cv", 1);
                    else
                        cmd.Parameters.AddWithValue("@cv", 0);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtennv.Text == string.Empty && tbcmt.Text == string.Empty && cbbchucvu.Text == string.Empty)
            {
                MessageBox.Show("Chỉ có thể tìm khi có giá trị trong tên nhân viên, chứng minh thư, và chức vụ","Thông báo");
            }
            else
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select * from NHANVIEN";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    FindNV(cmd.ExecuteReader());
                    connection.Close();
                }
        }
        void FindNV(SqlDataReader render)
        {
            LvNV.Items.Clear();
            while (render.Read())
            {
                ListViewItem item = new ListViewItem();
                LvNV.Items.Add(item);
                item.Text = render["MANV"].ToString();
                item.SubItems.Add(render["TENNV"].ToString());
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
                if (Convert.ToInt32(render["CHUCVU"]) == 1)
                    item.SubItems.Add("Quản trị viên");
                else
                    item.SubItems.Add("Nhân viên");
            }
        }

        private void bttaolai_Click(object sender, EventArgs e)
        {
            tbtennv.Clear();
            cknu.Checked = false;
            cbkxd.Checked = false;
            tbdiachi.Clear();
            tbcmt.Clear();
            tbsdt.Clear();
            cbbchucvu.Text=string.Empty;
        }
        int checkNV(string a) 
        {
            int kq;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select count(*) from NHANVIEN where CMT=@cmt";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                cmd.ExecuteNonQuery();
                kq = (int)cmd.ExecuteScalar();
                connection.Close();
            }
            return kq;
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbmk.Text) && !string.IsNullOrEmpty(tbtennv.Text) && !string.IsNullOrEmpty(cbbns.Text) && !string.IsNullOrEmpty(cbbts.Text) && !string.IsNullOrEmpty(tbns.Text) && !string.IsNullOrEmpty(tbcmt.Text) && !string.IsNullOrEmpty(tbsdt.Text) && !string.IsNullOrEmpty(tbdiachi.Text) && !string.IsNullOrEmpty(cbbchucvu.Text))
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    if (checkNV(tbcmt.Text) == 0)
                    {
                        string insert = "insert into NHANVIEN values(@manv,@idpass,@tennv,@ngaysinh,@gioitinh,@cmt,@sdt,@diachi,@chucvu)";
                        SqlCommand insertcmd = new SqlCommand(insert, connection);
                        insertcmd.Parameters.AddWithValue("@manv", tbcmt.Text);
                        insertcmd.Parameters.AddWithValue("@idpass", tbmk.Text);
                        insertcmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                        insertcmd.Parameters.AddWithValue("@ngaysinh", tbns.Text+"/"+cbbts.Text+"/"+cbbns.Text);
                        if(cknu.Checked==true)
                            insertcmd.Parameters.AddWithValue("@gioitinh", 1);
                        else if (cbkxd.Checked==true)
                            insertcmd.Parameters.AddWithValue("@gioitinh", 2);
                        else
                            insertcmd.Parameters.AddWithValue("@gioitinh", 0);
                        insertcmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                        insertcmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                        insertcmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                        if(cbbchucvu.Text=="Quản trị viên")
                            insertcmd.Parameters.AddWithValue("@chucvu", 1);
                        else
                            insertcmd.Parameters.AddWithValue("@chucvu", 0);
                        insertcmd.ExecuteNonQuery();
                        if (checkNV(tbcmt.Text)!=0)
                        {
                            ListViewItem item = new ListViewItem();
                            LvNV.Items.Add(item);
                            item.Text = tbcmt.Text;
                            item.SubItems.Add(tbtennv.Text);
                            item.SubItems.Add(cbbns.Text+"/"+cbbts.Text+"/"+tbns.Text);
                            if(cknu.Checked==true)
                                item.SubItems.Add("Nữ");
                            else if(cbkxd.Checked==true)
                                item.SubItems.Add("Không xác định");
                            else
                                item.SubItems.Add("Nam");
                            item.SubItems.Add(tbcmt.Text);
                            item.SubItems.Add(tbsdt.Text);
                            item.SubItems.Add(tbdiachi.Text);
                            item.SubItems.Add(cbbchucvu.Text);
                            MessageBox.Show("Thêm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thêm thất bại", "Thông báo");     
                    }
                    else
                        MessageBox.Show("Nhân viên này đã có trong hệ thống", "Thông báo");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Hãy nhập đầy đủ thông tin nhân viên", "Thông báo");
        }
        private void LvNV_DoubleClick(object sender, EventArgs e)
        {
            tbtennv.Text = LvNV.FocusedItem.SubItems[1].Text;
            tbcmt.Text = LvNV.FocusedItem.SubItems[4].Text;
            tbsdt.Text = LvNV.FocusedItem.SubItems[5].Text;
            tbdiachi.Text = LvNV.FocusedItem.SubItems[6].Text;
            cbbchucvu.Text = LvNV.FocusedItem.SubItems[7].Text;
            if (LvNV.FocusedItem.SubItems[3].ToString() == "Nữ")
                cknu.Checked = true;
            else if (LvNV.FocusedItem.SubItems[3].ToString() == "Không xác định")
                cbkxd.Checked = true;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select day(NGAYSINH) as 'ngay', month(NGAYSINH) as 'thang',year(NGAYSINH) as 'nam' from NHANVIEN where MANV=@manv";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@manv", LvNV.FocusedItem.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    tbns.Text = render["nam"].ToString();
                    cbbts.Text = render["thang"].ToString();
                    cbbns.Text = render["ngay"].ToString();
                }
                render.Close();
                connection.Close();
            }

        }

        private void bttrove_Click(object sender, EventArgs e)
        {
            Close();
        }
        int KTHoadon(string a)
        {
            int resutl;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string chek = "Select count(*) from HOADON where MANV=@manv";
                SqlCommand cmd = new SqlCommand(chek, connection);
                cmd.Parameters.AddWithValue("@manv", a);
                cmd.ExecuteNonQuery();
                resutl = (int)cmd.ExecuteScalar();
                connection.Close();
            }
            if (resutl != 0)
                return 1;
            else
                return 0;
        }
        private void btdel_Click(object sender, EventArgs e)
        {
            if (LvNV.SelectedItems.Count > 0)
            {
                if (KTHoadon(LvNV.FocusedItem.Text) == 0)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string del = "delete from NHANVIEN where MANV=@manv";
                        SqlCommand cmd = new SqlCommand(del, connection);
                        cmd.Parameters.AddWithValue("@manv", LvNV.FocusedItem.Text);
                        cmd.ExecuteNonQuery();
                        LvNV.FocusedItem.Remove();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Không thể xóa vì nhân viên này đã tồn tại trong hóa đơn", "Thông báo");
            }
            else
                MessageBox.Show("Hãy chọn nhân viên cần xóa", "Thông báo");
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

        private void btfix_Click(object sender, EventArgs e)
        {
            if (LvNV.SelectedItems.Count > 0)
            {
                    if (tbmk.Text == string.Empty && !string.IsNullOrEmpty(tbtennv.Text) && !string.IsNullOrEmpty(cbbns.Text) && !string.IsNullOrEmpty(cbbts.Text) && !string.IsNullOrEmpty(tbns.Text) && !string.IsNullOrEmpty(tbcmt.Text) && !string.IsNullOrEmpty(tbsdt.Text) && !string.IsNullOrEmpty(tbdiachi.Text) && !string.IsNullOrEmpty(cbbchucvu.Text))
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                        {
                            connection.Open();
                            string update = "update NHANVIEN set TENNV=@tennv, NGAYSINH=@ngaysinh, GIOITINH=@gt,CMT=@cmt,SDT=@sdt,DIACHI=@diachi,CHUCVU=@cv where MANV=@manv";
                            SqlCommand cmd = new SqlCommand(update, connection);
                            cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                            cmd.Parameters.AddWithValue("@ngaysinh", tbns.Text + "/" + cbbts.Text + "/" + cbbns.Text);
                            if (cknu.Checked == true)
                                cmd.Parameters.AddWithValue("@gt", 1);
                            else if (cbkxd.Checked == true)
                                cmd.Parameters.AddWithValue("@gt", 2);
                            else
                                cmd.Parameters.AddWithValue("@gt", 0);
                            cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                            cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                            cmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                            if (cbbchucvu.Text == "Quản trị viên")
                                cmd.Parameters.AddWithValue("@cv", 1);
                            else
                                cmd.Parameters.AddWithValue("@cv", 0);
                            cmd.Parameters.AddWithValue("@manv", LvNV.FocusedItem.Text);
                            cmd.ExecuteNonQuery();
                            ListViewItem item = new ListViewItem();
                            LvNV.Items.Add(item);
                            item.Text = tbcmt.Text;
                            item.SubItems.Add(tbtennv.Text);
                            item.SubItems.Add(cbbns.Text + "/" + cbbts.Text + "/" + tbns.Text);
                            if (cknu.Checked == true)
                                item.SubItems.Add("Nữ");
                            else if (cbkxd.Checked == true)
                                item.SubItems.Add("Không xác định");
                            else
                                item.SubItems.Add("Nam");
                            item.SubItems.Add(tbcmt.Text);
                            item.SubItems.Add(tbsdt.Text);
                            item.SubItems.Add(tbdiachi.Text);
                            if (cbbchucvu.Text == "Quản trị viên")
                                item.SubItems.Add("Quản trị viên");
                            else
                                item.SubItems.Add("Nhân viên");
                            LvNV.FocusedItem.Remove();
                            connection.Close();
                        }
                        MessageBox.Show("Sửa thành công", "Thông báo");
                    }
                    else if (!string.IsNullOrEmpty(tbmk.Text) && !string.IsNullOrEmpty(tbtennv.Text) && !string.IsNullOrEmpty(cbbns.Text) && !string.IsNullOrEmpty(cbbts.Text) && !string.IsNullOrEmpty(tbns.Text) && !string.IsNullOrEmpty(tbcmt.Text) && !string.IsNullOrEmpty(tbsdt.Text) && !string.IsNullOrEmpty(tbdiachi.Text) && !string.IsNullOrEmpty(cbbchucvu.Text))
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                        {
                            connection.Open();
                            string update = "update NHANVIEN set IDPASS=@mk, TENNV=@tennv, NGAYSINH=@ngaysinh, GIOITINH=@gt,CMT=@cmt,SDT=@sdt,DIACHI=@diachi,CHUCVU=@cv where MANV=@manv1";
                            SqlCommand cmd = new SqlCommand(update, connection);
                            cmd.Parameters.AddWithValue("@tennv", tbtennv.Text);
                            cmd.Parameters.AddWithValue("@mk", tbmk.Text);
                            cmd.Parameters.AddWithValue("@ngaysinh", tbns.Text + "/" + cbbts.Text + "/" + tbns.Text);
                            if (cknu.Checked == true)
                                cmd.Parameters.AddWithValue("@gt", 1);
                            else if (cbkxd.Checked == true)
                                cmd.Parameters.AddWithValue("@gt", 2);
                            else
                                cmd.Parameters.AddWithValue("@gt", 0);
                            cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                            cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                            cmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                            if (cbbchucvu.Text == "Quản trị viên")
                                cmd.Parameters.AddWithValue("@cv", 1);
                            else
                                cmd.Parameters.AddWithValue("@cv", 0);
                            cmd.Parameters.AddWithValue("@manv", LvNV.FocusedItem.Text);
                            cmd.ExecuteNonQuery();
                            ListViewItem item = new ListViewItem();
                            LvNV.Items.Add(item);
                            item.Text = tbcmt.Text;
                            item.SubItems.Add(tbtennv.Text);
                            item.SubItems.Add(cbbns.Text + "/" + cbbts.Text + "/" + tbns.Text);
                            if (cknu.Checked == true)
                                item.SubItems.Add("Nữ");
                            else if (cbkxd.Checked == true)
                                item.SubItems.Add("Không xác định");
                            else
                                item.SubItems.Add("Nam");
                            item.SubItems.Add(tbcmt.Text);
                            item.SubItems.Add(tbsdt.Text);
                            item.SubItems.Add(tbdiachi.Text);
                            if (cbbchucvu.Text == "Quản trị viên")
                                item.SubItems.Add("Quản trị viên");
                            else
                                item.SubItems.Add("Nhân viên");
                            LvNV.FocusedItem.Remove();
                            connection.Close();
                        }
                        MessageBox.Show("Sửa thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo");
            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần sửa", "Thông báo");
        }

    }
}
