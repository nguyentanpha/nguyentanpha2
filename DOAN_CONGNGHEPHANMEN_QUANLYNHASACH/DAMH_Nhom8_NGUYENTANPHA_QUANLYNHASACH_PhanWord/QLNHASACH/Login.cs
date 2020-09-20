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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbidnv.Text) && !string.IsNullOrEmpty(tbmknv.Text))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "select count(*) from NHANVIEN where MANV=@manv and IDPASS=@idpass";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@manv", tbidnv.Text);
                    cmd.Parameters.AddWithValue("@idpass", tbmknv.Text);
                    cmd.ExecuteNonQuery();
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        string querynamenv = "select TENNV,CHUCVU from NHANVIEN where MANV=@manv";
                        SqlCommand cmdmanv = new SqlCommand(querynamenv, connection);
                        cmdmanv.Parameters.AddWithValue("@manv", tbidnv.Text);
                        SqlDataReader render = cmdmanv.ExecuteReader();
                        while (render.Read())
                        {
                            QLBANSACHMAIN.MANV = tbidnv.Text;
                            QLBANSACHMAIN.TENNV = render["TENNV"].ToString();
                            if (Convert.ToInt32(render["CHUCVU"]) == 1)
                                QLBANSACHMAIN.CHUCVU = 1;
                            else
                                QLBANSACHMAIN.CHUCVU = 0;
                        }
                        render.Close();
                        QLBANSACHMAIN qlbansachmain = new QLBANSACHMAIN();
                        qlbansachmain.Show();
                        Visible = false;
                    }
                    else
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu nha!", "Thông báo");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Xin nhập đầy đủ tên tài khoản và mật khẩu", "Thông báo");
        }

    }
}
