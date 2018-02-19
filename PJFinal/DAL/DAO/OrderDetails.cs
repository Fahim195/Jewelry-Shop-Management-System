using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL.DAO
{
    class OrderDetails
    {
        public int CID;
        public string IssueDate;
        public string DeliveryDate;
        public float RateOfProduct;

        public float Total_Vori;
        public float Total_Ana;
        public float Total_Roti;
        public float Total_Point;
        public float TotalWeight;

        public float FinalWeight;
        public float Final_Vori;
        public float Final_Ana;
        public float Final_Roti;
        public float Final_Point; 

        public float Depo_Vori;
        public float Depo_Ana;
        public float Depo_Roti;
        public float Depo_Point;
        public float DepositedProductAmount;
        public string OrderStatus;

    }
}
