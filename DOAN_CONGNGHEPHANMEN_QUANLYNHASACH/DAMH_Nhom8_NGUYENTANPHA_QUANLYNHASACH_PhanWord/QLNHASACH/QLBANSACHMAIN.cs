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
    public partial class QLBANSACHMAIN : Form
    {
        public static string MANV = string.Empty;
        public static string TENNV = string.Empty;
        public static int CHUCVU;
        public QLBANSACHMAIN()
        {
            InitializeComponent();
            checkdssach();
            loadNVlogin();
            loadsach();
            loadngaythangnam();
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
        void loadsach()
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string select = "select * from SACH";
                SqlCommand cmd = new SqlCommand(select, connection);
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                    cbbsach.Items.Add(render["TENSACH"].ToString());
                render.Close();
                connection.Close();
            }
            cbbsach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbsach.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        void loadNVlogin()
        {
            if (CHUCVU == 1)
                lbcvnv.Text = "QTV";
            else
                lbcvnv.Text = "NV";
            lbmanv.Text = MANV;
            lbnamenv.Text = TENNV;
        }
        private void btqlsellbook_Click(object sender, EventArgs e)
        {
            QLSACH qlsach = new QLSACH();
            qlsach.Show();
        }

        private void btqlstaff_Click(object sender, EventArgs e)
        {
            QLNHANVIEN qlnv = new QLNHANVIEN();
            qlnv.Show();
        }

        private void btqlcustomer_Click(object sender, EventArgs e)
        {
            QLKHACHHANG qlkh = new QLKHACHHANG();
            qlkh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANV = string.Empty;
            TENNV = string.Empty;
            CHUCVU = 2;
            Login login = new Login();
            login.ShowDialog();
            Visible = false;
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
        int CheckKH(string cmt)
        {
            int result;
            using (SqlConnection connetion = new SqlConnection(ConnectionString.connectionString))
            {
                connetion.Open();
                string query = "select count(*) from KHACHHANG where CMT=@cmt";
                SqlCommand cmd = new SqlCommand(query, connetion);
                cmd.Parameters.AddWithValue("@cmt", cmt);
                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
                connetion.Close();
            }
            return result;
        }
        private void btcreatehd_Click(object sender, EventArgs e)
        {
            string mahd = string.Empty;
            mahd = createmaHD().ToString();
            if (!string.IsNullOrEmpty(cbbsach.Text) && !string.IsNullOrEmpty(tbtenkh.Text) && !string.IsNullOrEmpty(tbcmt.Text) && !string.IsNullOrEmpty(tbsdt.Text) && !string.IsNullOrEmpty(cbbns.Text) && !string.IsNullOrEmpty(cbbts.Text) && !string.IsNullOrEmpty(tbns.Text) && !string.IsNullOrEmpty(tbdiachi.Text))
            {
                if (tbsoluong.Text == string.Empty)
                    MessageBox.Show("Hãy nhập số lượng", "Thông báo");
                else
                {

                    if (Convert.ToInt32(tbsoluong.Text) > 0)
                    {
                        if (CheckKH(tbcmt.Text) == 0)
                        {

                            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                            {
                                connection.Open();
                                string themkh = "insert into KHACHHANG values(@makh,@tenkh,@ngaysinh,@gioitinh,@cmt,@sdt,@diachi)";
                                SqlCommand cmd = new SqlCommand(themkh, connection);
                                cmd.Parameters.AddWithValue("@makh", tbcmt.Text);
                                cmd.Parameters.AddWithValue("@tenkh", tbtenkh.Text);
                                cmd.Parameters.AddWithValue("@ngaysinh", tbns.Text + "/" + cbbts.Text + "/" + cbbns.Text);
                                if (ckbnu.Checked == true)
                                    cmd.Parameters.AddWithValue("@gioitinh", 1);
                                else if (ckbkxd.Checked == true)
                                    cmd.Parameters.AddWithValue("@gioitinh", 2);
                                else
                                    cmd.Parameters.AddWithValue("@gioitinh", 0);
                                cmd.Parameters.AddWithValue("@cmt", tbcmt.Text);
                                cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                                cmd.Parameters.AddWithValue("@diachi", tbdiachi.Text);
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }
                            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                            {
                                connection.Open();
                                string insertHD = "insert into HOADON values(@mahd,@manv,@makh,@ngaylap)";
                                SqlCommand cmd = new SqlCommand(insertHD, connection);
                                cmd.Parameters.AddWithValue("@mahd", mahd);
                                cmd.Parameters.AddWithValue("@manv", MANV);
                                cmd.Parameters.AddWithValue("@makh", tbcmt.Text);
                                cmd.Parameters.AddWithValue("@ngaylap", (date.Year + "/" + date.Month + "/" + date.Day).ToString());
                                cmd.ExecuteNonQuery();
                                string insertCTHD = "insert into CTHOADON values(@mahd,@masach,@soluong,@tongtien)";
                                SqlCommand cmdinsertCTHD = new SqlCommand(insertCTHD, connection);
                                cmdinsertCTHD.Parameters.AddWithValue("@mahd", mahd);
                                cmdinsertCTHD.Parameters.AddWithValue("@masach", Findmasach(cbbsach.Text));
                                cmdinsertCTHD.Parameters.AddWithValue("@soluong", tbsoluong.Text);
                                cmdinsertCTHD.Parameters.AddWithValue("@tongtien", Convert.ToInt32(tbsoluong.Text) * FindDGsach(Findmasach(cbbsach.Text)));
                                cmdinsertCTHD.ExecuteNonQuery();
                                MessageBox.Show("Tạo thành công", "Thông báo");
                                connection.Close();
                            }
                            HOADON.TENKH = tbtenkh.Text;
                            HOADON.MAHD = mahd;
                            HOADON hoadon = new HOADON();
                            hoadon.Show();
                        }
                        else
                        {
                            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                            {
                                connection.Open();
                                string insertHD = "insert into HOADON values(@mahd,@manv,@makh,@ngaylap)";
                                SqlCommand cmd = new SqlCommand(insertHD, connection);
                                cmd.Parameters.AddWithValue("@mahd", mahd);
                                cmd.Parameters.AddWithValue("@manv", MANV);
                                cmd.Parameters.AddWithValue("@makh", tbcmt.Text);
                                cmd.Parameters.AddWithValue("@ngaylap", (date.Year + "/" + date.Month + "/" + date.Day).ToString());
                                cmd.ExecuteNonQuery();
                                string insertCTHD = "insert into CTHOADON values(@mahd,@masach,@soluong,@tongtien)";
                                SqlCommand cmdinsertCTHD = new SqlCommand(insertCTHD, connection);
                                cmdinsertCTHD.Parameters.AddWithValue("@mahd", mahd);
                                cmdinsertCTHD.Parameters.AddWithValue("@masach", Findmasach(cbbsach.Text));
                                cmdinsertCTHD.Parameters.AddWithValue("@soluong", tbsoluong.Text);
                                cmdinsertCTHD.Parameters.AddWithValue("@tongtien", Convert.ToInt32(tbsoluong.Text) * FindDGsach(Findmasach(cbbsach.Text)));
                                cmdinsertCTHD.ExecuteNonQuery();
                                MessageBox.Show("Tạo thành công", "Thông báo");
                                connection.Close();
                            }
                            HOADON.TENKH = tbtenkh.Text;
                            HOADON.MAHD = mahd;
                            HOADON hoadon = new HOADON();
                            hoadon.Show();
                        }
                    }
                    else
                        MessageBox.Show("Số lượng sách phải lớn hơn 0", "Thông báo");
                }
            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin mua sách", "Thông báo");
        }
        string createmaHD()
        {
            return (tbcmt.Text + date.Day + date.Month + date.Year + date.Hour + date.Minute + date.Second).ToString();
        }
        int FindDGsach(string masach)
        {
            int a;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select DONGIA from SACH where MASACH=@masach";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@masach", masach);
                cmd.ExecuteNonQuery();
                a = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return a;
        }
        string Findmasach(string tensach)
        {
            string a;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select MASACH from SACH where TENSACH=@tensach";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@tensach", tensach);
                cmd.ExecuteNonQuery();
                a = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            return a;
        }
        
        void checkdssach()
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select count(*) from SACH";
                SqlCommand cmd = new SqlCommand(query, connection);
                int result = (int)cmd.ExecuteScalar();
                if (result==0)
                {
                    MessageBox.Show("Hiện chưa có sách để bán hãy thêm sách vào", "Thông báo");
                    QLSACH qlsach = new QLSACH();
                    qlsach.ShowDialog();
                }
                connection.Close();
            }
        }
        public static DateTime date = DateTime.Now;
        //int MaHoaDon()
        //{
        //    int result;
        //    using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
        //    {
        //        connection.Open();
        //        string query = "select MAKH+DAY(NGAYLAP)+MONTH(NGAYLAP)+YEAR(NGAYLAP) from HOADON";
        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        result = (int)cmd.ExecuteScalar();
        //        connection.Close();
        //    }
        //    return result;
        //}
        private void ckbnu_Click(object sender, EventArgs e)
        {
            if (ckbnu.Checked == true)
                ckbkxd.Enabled = false;
            else
                ckbkxd.Enabled = true;
        }

        private void ckbkxd_Click(object sender, EventArgs e)
        {
            if (ckbkxd.Checked == true)
                ckbnu.Enabled = false;
            else
                ckbnu.Enabled = true;
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            cbbsach.Items.Clear();
            cbbsach.Text = string.Empty;
            tbtenkh.Clear();
            tbcmt.Clear();
            tbsdt.Clear();
            tbsoluong.Clear();
            tbdiachi.Clear();
            ckbkxd.Checked = false;
            ckbnu.Checked = false;
            loadsach();
            loadngaythangnam();
        }
    }
}
