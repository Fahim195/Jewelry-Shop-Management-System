using PJFinal.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class PaymentLedgerBLL
    {
        public DataTable ViewPaymentLadgerOfSpecificDate(string LedgerType, string StartDate, String EndDate)
        {
            DataTable dt = null;
            if (LedgerType == "")
            {
                return dt;
            }
            else if (LedgerType != "Today" && (StartDate == "" || EndDate == ""))
            {
                return dt;
            }
            else
            {
                PaymentLedgerDAL aPaymentLedgerDAL = new PaymentLedgerDAL();
                dt = aPaymentLedgerDAL.ViewPaymentLadgerOfSpecificDate(LedgerType, StartDate, EndDate);
                return dt;
            }

        }
        public DataTable ViewDueStatusOfSpecificDate(string LedgerType, string StartDate, String EndDate)
        {
            DataTable dt = null;
            if (LedgerType == "")
            {
                return dt;
            }
            else if (StartDate == "" || EndDate == "")
            {
                return dt;
            }
            else
            {
                PaymentLedgerDAL aPaymentLedgerDAL = new PaymentLedgerDAL();
                dt = aPaymentLedgerDAL.ViewDueOfSpecificDate(LedgerType, StartDate, EndDate);
                return dt;
            }

        }
        public DataTable[] Information_in_ViewDailyLedgeerBLL()
        {
            PaymentLedgerDAL aPaymentLadgerDAL = new PaymentLedgerDAL();
            DataTable[] dTables = aPaymentLadgerDAL.Information_in_ViewDailyLedgeerDAL();
            return dTables;
        }
    }
}
