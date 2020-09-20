using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phanmem_QL_Quan_CaPhe.DTO
{
    public class Food
    {
        public Food(int id, string name, int iDcategory, float price)
        {
            this.ID = id;
            this.Name = name;
            this.IDCategory = iDcategory;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["ten"].ToString();
            this.IDCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());

        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int iDcategory;

        public int IDCategory
        {
            get { return iDcategory; }
            set { iDcategory = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
