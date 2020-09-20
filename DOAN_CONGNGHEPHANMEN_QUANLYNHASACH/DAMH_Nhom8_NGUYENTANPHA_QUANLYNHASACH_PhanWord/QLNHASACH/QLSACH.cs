using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QLSACH : Form
    {
        public QLSACH()
        {
            InitializeComponent();
            loaddata();
            loadngaythangnam();
            loaditemlv();
            loadquyen();
        }
        void loadquyen()
        {
            if (QLBANSACHMAIN.CHUCVU == 1)
            {
                btthem.Enabled = true;
                btxoa.Enabled = true;
                btsua.Enabled = true;
            }
            else
            {
                btthem.Enabled = false;
                btxoa.Enabled = false;
                btsua.Enabled = false;
            }
        }
        void loadngaythangnam()
        {
            DateTime date = DateTime.Now;
            if (tbnamph.Text == string.Empty)
                tbnamph.Text = date.Year.ToString();
            if (Convert.ToInt32(cbbthangph.Items.Count) < 12)
                for (int i = 1; i <= 12; i++)
                    cbbthangph.Items.Add(i);
            if (cbbthangph.Text == "1" || cbbthangph.Text == "3" || cbbthangph.Text == "5" || cbbthangph.Text == "7" || cbbthangph.Text == "8" || cbbthangph.Text == "11")
                for (int i = 1; i <= 31; i++)
                    cbbnph.Items.Add(i);
            else if (cbbthangph.Text == "2")
            {
                if (Convert.ToInt32(tbnamph.Text) % 400 == 0 || Convert.ToInt32(tbnamph.Text) % 4 == 0 && Convert.ToInt32(tbnamph.Text) % 100 != 0)
                    for (int i = 1; i <= 29; i++)
                        cbbnph.Items.Add(i);
                else
                    for (int i = 1; i <= 28; i++)
                        cbbnph.Items.Add(i);
            }
            else
                for (int i = 1; i <= 30; i++)
                    cbbnph.Items.Add(i);
        }
        void loaddata()
        {
            cbbtheloai.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbtheloai.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbtacgia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbtacgia.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbnhaxb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbnhaxb.AutoCompleteSource = AutoCompleteSource.ListItems;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                //lấy thông tin thể loại
                string querytl = "select * from THELOAI";
                SqlCommand tlcmd = new SqlCommand(querytl, connection);
                SqlDataReader rendertl = tlcmd.ExecuteReader();
                while (rendertl.Read())
                    cbbtheloai.Items.Add(rendertl["TENTHELOAI"].ToString());
                rendertl.Close();
                //lấy thông tin tác giả
                string querytg = "select * from TACGIA";
                SqlCommand tgcmd = new SqlCommand(querytg, connection);
                SqlDataReader rendertg = tgcmd.ExecuteReader();
                while (rendertg.Read())
                    cbbtacgia.Items.Add(rendertg["TENTG"].ToString());
                rendertg.Close();
                //lấy thông tin nhà xuất bản
                string queryNXB = "select * from NHAXUATBAN";
                SqlCommand nxbcmd = new SqlCommand(queryNXB, connection);
                SqlDataReader rendernxb = nxbcmd.ExecuteReader();
                while (rendernxb.Read())
                    cbbnhaxb.Items.Add(rendernxb["TENNXB"].ToString());
                rendernxb.Close();
                connection.Close();
            }
        }
        void Cauhinhlv()
        {
            LvBook.View = View.Details;
            LvBook.FullRowSelect = true;
            LvBook.GridLines = true;
            if (LvBook.Columns.Count==0)
	        {
	        	LvBook.Columns.Add("Mã sách");
                LvBook.Columns.Add("Tên sách");
                LvBook.Columns.Add("Thể loại");
                LvBook.Columns.Add("Tác giả");
                LvBook.Columns.Add("Nhà xuất bản");
                LvBook.Columns.Add("Ngày phát hành");
                LvBook.Columns.Add("Giá tiền");
	        }
            LvBook.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LvBook.Sorting = System.Windows.Forms.SortOrder.Ascending;
            LvBook.MultiSelect = false;
        }
        void loaditemlv()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    ListViewItem item = new ListViewItem();
                    LvBook.Items.Add(item);
                    item.Text = render["MASACH"].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENSACH"].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENTHELOAI"].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENTG"].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENNXB"].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["day"].ToString() + "/" + render["thang"].ToString() + "/" + render["nam"].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["DONGIA"].ToString() });
                }
                render.Close();
                connection.Close();
                Cauhinhlv();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select * from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    if (render["TENTHELOAI"].ToString() == cbbtheloai.Text && render["TENTG"].ToString() == cbbtacgia.Text && render["TENNXB"].ToString()==cbbnhaxb.Text  && render["TENSACH"].ToString() == tbtensach.Text)
                    {
                        MessageBox.Show("Sách này đã tồn tại trong dữ liệu hệ thống", "Thông báo");
                        return;
                    }
                }
                connection.Close();
            }
            string inserttg = "insert into TACGIA values (@matg,@tentg)";
            string inserttheloai = "insert into THELOAI values (@matl,@tentl)";
            string insertNXB = "insert into NHAXUATBAN values (@manxb,@tennxb)";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string checktg = "select count(*) from TACGIA where TENTG=@tentg";
                SqlCommand checktgcmd = new SqlCommand(checktg, connection);
                checktgcmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                checktgcmd.ExecuteNonQuery();
                int resultchecktg = (int)checktgcmd.ExecuteScalar();
                if (resultchecktg == 0)
                {
                    string tongsltg = "select count(*) from TACGIA";
                    SqlCommand tongsltgcmd = new SqlCommand(tongsltg, connection);
                    int resultsltg = (int)tongsltgcmd.ExecuteScalar();
                    SqlCommand addtgcmd = new SqlCommand(inserttg, connection);
                    addtgcmd.Parameters.AddWithValue("@matg", resultsltg + 1);
                    addtgcmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                    addtgcmd.ExecuteNonQuery();
                }
                string checktl = "select count(*) from THELOAI where TENTHELOAI=@tentl";
                SqlCommand checktlcmd = new SqlCommand(checktl, connection);
                checktlcmd.Parameters.AddWithValue("@tentl", cbbtheloai.Text);
                checktlcmd.ExecuteNonQuery();
                int resultchecktl = (int)checktlcmd.ExecuteScalar();
                if (resultchecktl == 0)
                {
                    string tongsl = "select count(*) from THELOAI";
                    SqlCommand tongslcmd = new SqlCommand(tongsl, connection);
                    int resultsl = (int)tongslcmd.ExecuteScalar();
                    SqlCommand addtgcmd = new SqlCommand(inserttheloai, connection);
                    addtgcmd.Parameters.AddWithValue("@matl", resultsl + 1);
                    addtgcmd.Parameters.AddWithValue("@tentl", cbbtheloai.Text);
                    addtgcmd.ExecuteNonQuery();
                }
                string checkNXB = "select count(*) from NHAXUATBAN where TENNXB=@tennxb";
                SqlCommand checkNXBcmd = new SqlCommand(checkNXB, connection);
                checkNXBcmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                checkNXBcmd.ExecuteNonQuery();
                int resultcheckNXB = (int)checkNXBcmd.ExecuteScalar();
                if (resultcheckNXB == 0)
                {
                    string tongsl = "select count(*) from NHAXUATBAN";
                    SqlCommand tongslcmd = new SqlCommand(tongsl, connection);
                    int resultsl = (int)tongslcmd.ExecuteScalar();
                    SqlCommand addtgcmd = new SqlCommand(insertNXB, connection);
                    addtgcmd.Parameters.AddWithValue("@manxb", resultsl + 1);
                    addtgcmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                    addtgcmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                if (!string.IsNullOrEmpty(tbtensach.Text) && !string.IsNullOrEmpty(cbbtheloai.Text) && !string.IsNullOrEmpty(cbbtacgia.Text) && !string.IsNullOrEmpty(cbbnhaxb.Text) && !string.IsNullOrEmpty(tbdongia.Text))
                {
                    string tongslsach = "select count(*) from SACH";
                    connection.Open();
                    SqlCommand tongslsachcmd = new SqlCommand(tongslsach, connection);
                    int resultsl = (int)tongslsachcmd.ExecuteScalar();
                    //
                    int masach = checkmasach(resultsl);
                    //
                    string insert = "insert into SACH values(@masach,@matl,@matg,@manxb,@tensach,@ngayph,@dongia)";
                    SqlCommand cmd = new SqlCommand(insert, connection);
                    cmd.Parameters.AddWithValue("@masach", masach);
                    //tim mã thể loại
                    string findtheloai = "select MATL from THELOAI where TENTHELOAI=@tentl";
                    SqlCommand findtheloaicmd = new SqlCommand(findtheloai, connection);
                    findtheloaicmd.Parameters.AddWithValue("@tentl", cbbtheloai.Text);
                    findtheloaicmd.ExecuteNonQuery();
                    string matl = findtheloaicmd.ExecuteScalar().ToString();
                    //add dl
                    cmd.Parameters.AddWithValue("@matl", matl);
                    string findnxb = "select MANXB from NHAXUATBAN where TENNXB=@tennxb";
                    SqlCommand findnxbcmd = new SqlCommand(findnxb, connection);
                    findnxbcmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                    findnxbcmd.ExecuteNonQuery();
                    string manxb = findnxbcmd.ExecuteScalar().ToString();
                    //
                    string findtg = "select MATG from TACGIA where TENTG=@tentg";
                    SqlCommand findtgcmd = new SqlCommand(findtg, connection);
                    findtgcmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                    findtgcmd.ExecuteNonQuery();
                    string matg = findtgcmd.ExecuteScalar().ToString();
                    //add dl
                    cmd.Parameters.AddWithValue("@matg", matg);
                    cmd.Parameters.AddWithValue("@manxb", manxb);
                    cmd.Parameters.AddWithValue("@tensach", tbtensach.Text);
                    cmd.Parameters.AddWithValue("@ngayph", tbnamph.Text + "/" + cbbthangph.Text + "/" + cbbnph.Text);
                    cmd.Parameters.AddWithValue("@dongia", tbdongia.Text);
                    cmd.ExecuteNonQuery();
                    SqlCommand checkadd = new SqlCommand(tongslsach, connection);
                    int resultadd = (int)checkadd.ExecuteScalar();
                    if (resultadd > resultsl)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        ListViewItem item = new ListViewItem();
                        LvBook.Items.Add(item);
                        item.Text = Convert.ToString(masach);
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = tbtensach.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = cbbtheloai.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = cbbtacgia.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = cbbnhaxb.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = cbbnph.Text + "/" + cbbthangph.Text + "/" + tbnamph.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = tbdongia.Text });
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                    connection.Close();
                }
                else
                    MessageBox.Show("Điền đầy đủ thông tin sách", "Thông báo");
            }
            loaddata();
        }
        int checkmasach(int a)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string ckmasach = "select count(*) from SACH where MASACH=@masach";
                SqlCommand ckmasachcmd = new SqlCommand(ckmasach, connection);
                ckmasachcmd.Parameters.AddWithValue("@masach", a);
                ckmasachcmd.ExecuteNonQuery();
                int result = (int)ckmasachcmd.ExecuteScalar();
                int whileresult;
                int k = a;
                while (result != 0)
                {
                    a = a + 1;
                    SqlCommand whilecheck = new SqlCommand(ckmasach, connection);
                    whilecheck.Parameters.AddWithValue("@masach", a);
                    whilecheck.ExecuteNonQuery();
                    whileresult = (int)whilecheck.ExecuteScalar();
                    result = whileresult;
                }
                if (result == 0)
                {
                    for (int i = 1; i <= k; i++)
                    {
                        string checkdsdautoiduoi = "select count(*) from SACH where MASACH=@masach";
                        SqlCommand checkdsdautoiduoicmd = new SqlCommand(checkdsdautoiduoi, connection);
                        checkdsdautoiduoicmd.Parameters.AddWithValue("@masach", i);
                        checkdsdautoiduoicmd.ExecuteNonQuery();
                        int l = (int)checkdsdautoiduoicmd.ExecuteScalar();
                        if (l == 0)
                            return i;
                    }
                }
                if (a == 0)
                    return 1;
                else
                    return a;
            }
        }
        private void cbbthangph_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbnph.Text = "1";
            cbbnph.Items.Clear();
            loadngaythangnam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and TENSACH=@tensach and TENTHELOAI=@tentheloai and TENTG=@tentg and TENNXB=@tennxb";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tensach", tbtensach.Text);
                    cmd.Parameters.AddWithValue("@tentheloai", cbbtheloai.Text);
                    cmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                    cmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            if (!string.IsNullOrEmpty(tbtensach.Text) && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and TENSACH=@tensach";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tensach", tbtensach.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text != string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and TENTHELOAI=@tentl";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tentl", cbbtheloai.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text != string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and TENTG=@tentg";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text != string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and TENNXB=@tennxb";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text != string.Empty && cbbthangph.Text == string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and day(NGAYPH)=@ngayph";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ngayph", cbbnph.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text != string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and month(NGAYPH)=@thangph";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@thangph", cbbthangph.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            else if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty && !string.IsNullOrEmpty(tbdongia.Text))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and DONGIA=@dongia";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@dongia", tbdongia.Text);
                    cmd.ExecuteNonQuery();
                    Findload(cmd.ExecuteReader());
                    connection.Close();
                }
            }
        }
        void Findload(SqlDataReader render)
        {
            LvBook.Items.Clear();
            while (render.Read())
            {
                ListViewItem item = new ListViewItem();
                LvBook.Items.Add(item);
                item.Text = render["MASACH"].ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENSACH"].ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENTHELOAI"].ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENTG"].ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["TENNXB"].ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["day"].ToString() + "/" + render["thang"].ToString() + "/" + render["nam"].ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = render["DONGIA"].ToString() });
            }
        }
        private void tbnamph_Leave(object sender, EventArgs e)
        {
            loadngaythangnam();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LvBook.SelectedItems.Count > 0)
            {
                DialogResult r;
                r = MessageBox.Show("Bạn thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "delete from SACH where MASACH=@masach";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@masach", LvBook.FocusedItem.Text);
                        cmd.ExecuteNonQuery();
                        string CheckSachSauXoa = "select count(*) from SACH where MASACH=@masach";
                        SqlCommand CheckSachSauXoacmd = new SqlCommand(CheckSachSauXoa, connection);
                        CheckSachSauXoacmd.Parameters.AddWithValue("@masach", LvBook.FocusedItem.Text);
                        CheckSachSauXoacmd.ExecuteNonQuery();
                        int result = (int)CheckSachSauXoacmd.ExecuteScalar();
                        if (result == 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                            LvBook.FocusedItem.Remove();
                        }
                        else
                            MessageBox.Show("Xóa thất bại", "Thông báo");
                        connection.Close();
                    }
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn sách cần xóa", "Thông báo");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LvBook.SelectedItems.Count > 0)
            {
                if (tbtensach.Text == string.Empty && cbbtheloai.Text == string.Empty && cbbtacgia.Text == string.Empty && cbbnhaxb.Text == string.Empty && cbbnph.Text == string.Empty && cbbthangph.Text == string.Empty && tbdongia.Text == string.Empty)
                {
                    MessageBox.Show("Hãy nhập thông tin cần sửa", "Thông báo");
                }
                else if (tbtensach.Text != string.Empty && cbbtheloai.Text != string.Empty && cbbtacgia.Text != string.Empty && cbbnhaxb.Text != string.Empty && cbbnph.Text != string.Empty && cbbthangph.Text != string.Empty && tbdongia.Text != string.Empty)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "update SACH set TENSACH=@tensach,MATL=@matl,MATG=@matg,MANXB=@manxb,NGAYPH=@ngayph,DONGIA=@dongia where MASACH=@masach";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@tensach", tbtensach.Text);
                        //
                        string findtheloai = "select MATL from THELOAI where TENTHELOAI=@tentl";
                        SqlCommand findtheloaicmd = new SqlCommand(findtheloai, connection);
                        findtheloaicmd.Parameters.AddWithValue("@tentl", cbbtheloai.Text);
                        findtheloaicmd.ExecuteNonQuery();
                        string matl = findtheloaicmd.ExecuteScalar().ToString();
                        cmd.Parameters.AddWithValue("@matl", matl);
                        //
                        string findnxb = "select MANXB from NHAXUATBAN where TENNXB=@tennxb";
                        SqlCommand findnxbcmd = new SqlCommand(findnxb, connection);
                        findnxbcmd.Parameters.AddWithValue("@tennxb", cbbnhaxb.Text);
                        findnxbcmd.ExecuteNonQuery();
                        string manxb = findnxbcmd.ExecuteScalar().ToString();
                        cmd.Parameters.AddWithValue("@manxb", manxb);
                        //
                        string findtg = "select MATG from TACGIA where TENTG=@tentg";
                        SqlCommand findtgcmd = new SqlCommand(findtg, connection);
                        findtgcmd.Parameters.AddWithValue("@tentg", cbbtacgia.Text);
                        findtgcmd.ExecuteNonQuery();
                        string matg = findtgcmd.ExecuteScalar().ToString();
                        cmd.Parameters.AddWithValue("@matg", matg);
                        cmd.Parameters.AddWithValue("@ngayph", tbnamph.Text + "/" + cbbthangph.Text + "/" + cbbnph.Text);
                        cmd.Parameters.AddWithValue("@dongia", tbdongia.Text);
                        cmd.Parameters.AddWithValue("@masach", LvBook.FocusedItem.Text);
                        cmd.ExecuteNonQuery();
               
                        string loadsach = "select * ,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG and MASACH=@masach";
                        SqlCommand loadsachcmd = new SqlCommand(loadsach, connection);
                        loadsachcmd.Parameters.AddWithValue("@masach", LvBook.FocusedItem.Text);
                        loadsachcmd.ExecuteNonQuery();
                        SqlDataReader render = loadsachcmd.ExecuteReader();
                        while (render.Read())
                        {
                            ListViewItem item = new ListViewItem();
                            LvBook.Items.Add(item);
                            item.Text = LvBook.FocusedItem.Text;
                            item.SubItems.Add(render["TENSACH"].ToString());
                            item.SubItems.Add(render["TENTHELOAI"].ToString());
                            item.SubItems.Add(render["TENTG"].ToString());
                            item.SubItems.Add(render["TENNXB"].ToString());
                            item.SubItems.Add(cbbnph.Text+"/"+cbbthangph.Text+"/"+tbnamph.Text);
                            item.SubItems.Add(render["DONGIA"].ToString()); 
                        }
                        render.Close();
                        LvBook.FocusedItem.Remove();
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo");
            }
            else
                MessageBox.Show("Hãy chọn sách cần sửa", "Thông báo");
        }

        private void LvBook_DoubleClick(object sender, EventArgs e)
        {
            tbtensach.Text=LvBook.FocusedItem.SubItems[1].Text;
            cbbtheloai.Text=LvBook.FocusedItem.SubItems[2].Text;
            cbbtacgia.Text=LvBook.FocusedItem.SubItems[3].Text;
            cbbnhaxb.Text=LvBook.FocusedItem.SubItems[4].Text;
            tbdongia.Text=LvBook.FocusedItem.SubItems[6].Text;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select day(NGAYPH) as 'ngay', month(NGAYPH) as 'thang',year(NGAYPH) as 'nam' from SACH where MASACH=@masach";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@masach", LvBook.FocusedItem.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    tbnamph.Text = render["nam"].ToString();
                    cbbthangph.Text = render["thang"].ToString();
                    cbbnph.Text = render["ngay"].ToString();
                }
                render.Close();
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbtensach.Clear();
            cbbtacgia.Text = "";
            cbbtheloai.Text = "";
            cbbnhaxb.Text = "";
            cbbthangph.Text = "1";
            cbbnph.Text = "1";
            loadngaythangnam();
            tbdongia.Clear();
            LvBook.Items.Clear();
            loaditemlv();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select count(*) from SACH";
                SqlCommand cmd = new SqlCommand(query, connection);
                int result = (int)cmd.ExecuteScalar();
                if (result == 0)
                {
                    DialogResult r;
                    r = MessageBox.Show("Hiện chưa có sách để bán, bạn thật sự muốn truy cập vào quản lí ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (r==DialogResult.Yes)
                        Close();
                }
                else
                    Close();
                connection.Close();
            }
        }

    }
}
