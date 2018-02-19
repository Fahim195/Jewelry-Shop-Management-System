using PJFinal.DAL;
using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class PaymentBLL
    {
        public bool SavePaymenInformationtBLL(Payment aPayment)
        {
            if (aPayment.PaymentStatus=="" ||aPayment.Discount<0 || aPayment.LastPayment<0 )
            {
                return false;
            }
            else
            {
                PaymentDAL aPAymentDAL = new PaymentDAL();
                bool res = aPAymentDAL.SavePaymenInformationtDAL(aPayment);
                return res;
            }
            
        }
        public int CancelPaymentBLL(Payment aPayment)
        {
            if ( aPayment.CID==0)
            {
                return 3;
            }
            else
            {
                PaymentDAL aPaymentDAL = new PaymentDAL(); 
               int res = aPaymentDAL.CancelPaymentDAL(aPayment);
                return res;
            }
        }
    }
}
