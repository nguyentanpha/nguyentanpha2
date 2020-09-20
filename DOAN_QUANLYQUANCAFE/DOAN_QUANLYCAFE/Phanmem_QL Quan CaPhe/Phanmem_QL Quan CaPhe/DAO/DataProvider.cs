using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phanmem_QL_Quan_CaPhe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        //Dong goi dataProvider
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = @"Data Source=DESKTOP-QM9BGT0\SQLEXPRESS;Initial Catalog=doan1;Integrated Security=True";//dung de xac dinh ket noi toi sever nao

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            //ket noi toi server database
            using (SqlConnection connection = new SqlConnection(connectionSTR))//using dung de giai phong du lieu tranh loi phat sinh
            {
                connection.Open();//mo connection de lay data

                //excuse cau truy van query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                        }
                    }
                }

                //lay du lieu ra tu database
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();//dong connection
            }
            return data;
        }

        //dung de kiem tr update 
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            //so dong thanh cong
            int data = 0;
            //ket noi toi server database
            using (SqlConnection connection = new SqlConnection(connectionSTR))//using dung de giai phong du lieu tranh loi phat sinh
            {
                connection.Open();//mo connection de lay data

                //excuse cau truy van query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                        }
                    }
                }

                //lay du lieu ra tu database
                data = command.ExecuteNonQuery();

                connection.Close();//dong connection
            }
            return data;
        }

        //dung de dem so luong 
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            //so dong thanh cong
            object data = 0;
            //ket noi toi server database
            using (SqlConnection connection = new SqlConnection(connectionSTR))//using dung de giai phong du lieu tranh loi phat sinh
            {
                connection.Open();//mo connection de lay data

                //excuse cau truy van query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                        }
                    }
                }

                //lay du lieu ra tu database
                data = command.ExecuteScalar();

                connection.Close();//dong connection
            }
            return data;
        }
    }
}
