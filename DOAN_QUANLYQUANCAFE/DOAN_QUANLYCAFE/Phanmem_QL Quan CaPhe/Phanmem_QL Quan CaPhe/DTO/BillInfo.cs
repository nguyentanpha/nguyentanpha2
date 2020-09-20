using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phanmem_QL_Quan_CaPhe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idBill"];
            this.FoodID = (int)row["idFood"];
            this.Count = (int)row["count"];

        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        private int foodID;// ctrl R E or propull tab tab 

        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }


        private int billiD;

        public int BillID
        {
            get { return billiD; }
            set { billiD = value; }
        }


        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
