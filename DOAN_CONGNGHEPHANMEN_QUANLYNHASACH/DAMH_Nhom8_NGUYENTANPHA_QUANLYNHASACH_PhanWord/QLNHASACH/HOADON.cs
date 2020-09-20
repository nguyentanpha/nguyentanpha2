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
    public partial class HOADON : Form
    {
        public static string TENNV = QLBANSACHMAIN.TENNV;
        public static string TENKH = string.Empty;
        public static string MAHD = string.Empty;
        public HOADON()
        {
            InitializeComponent();
            loadinfoHD();
            
        }
        public DateTime date = DateTime.Now;
        void loadinfoHD()
        {
            lbmahd.Text = MAHD;
            lbngaylap.Text = date.Day + "/" + date.Month + "/" + date.Year;
            lbtenkh.Text = TENKH;
            lbtennv.Text = TENNV;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "select * from HOADON,CTHOADON where HOADON.MAHD=CTHOADON.MAHD and HOADON.MAHD=@mahd";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mahd", MAHD);
                cmd.ExecuteNonQuery();
                SqlDataReader render = cmd.ExecuteReader();
                while (render.Read())
                {
                    ListViewItem item = new ListViewItem();
                    LvHD.Items.Add(item);
                    item.Text = Tensach(render["MASACH"].ToString());
                    item.SubItems.Add((Convert.ToInt32(render["TONGTIEN"])/Convert.ToInt32(render["SOLUONG"])).ToString());
                    item.SubItems.Add(render["SOLUONG"].ToString());
                    item.SubItems.Add(render["TONGTIEN"].ToString());
                    tongtien.Text = render["TONGTIEN"].ToString();
                }
                render.Close();
                connection.Close();
            }
            Cauhinh();
        }
        string Tensach(string masach)
        {
            string a;
            using (SqlConnection connection=new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string select = "select TENSACH from SACH where MASACH=@masach";
                SqlCommand cmd = new SqlCommand(select, connection);
                cmd.Parameters.AddWithValue("@masach", masach);
                cmd.ExecuteNonQuery();
                a = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            return a;
        }
        void Cauhinh()
        {
            LvHD.View = View.Details;
            LvHD.FullRowSelect = true;
            LvHD.GridLines = true;
            LvHD.Columns.Add("Tên sách");
            LvHD.Columns.Add("Đơn giá");
            LvHD.Columns.Add("Số lượng");
            LvHD.Columns.Add("Tổng tiền");
            LvHD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
