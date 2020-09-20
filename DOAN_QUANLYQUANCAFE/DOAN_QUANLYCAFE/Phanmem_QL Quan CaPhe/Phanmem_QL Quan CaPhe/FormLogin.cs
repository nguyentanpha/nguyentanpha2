using Phanmem_QL_Quan_CaPhe.DAO;
using Phanmem_QL_Quan_CaPhe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanmem_QL_Quan_CaPhe
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txbDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)// 
        {
            string userName = txbDangNhap.Text;
            string passWord = txbMatKhau.Text;
            if (Login(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                // dùng show dialog gán xử lý để đơi hiển thị xử lý từng thành phần phần 1 trước phần 2 sau
                FormManager f = new FormManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu !","Cảnh Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            }
        }

        //ham dung de dang nhap
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName,passWord);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Bạn Có Muốn Thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (exit == DialogResult.No)
                e.Cancel = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_DangNhap_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txb_MatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
