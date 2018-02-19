using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL.DAO
{
    class Payment
    {
        public int CID;
        public string DateTime;
        public float ProductCharge;
        public float DesigningCharge; 
        public float TotalBill;
        public float Advance;
        public float Due;
        public float Discount;
        public float LastPayment;
        public string PaymentStatus;
    }
}
