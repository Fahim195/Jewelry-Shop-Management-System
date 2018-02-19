using PJFinal.DAL;
using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class SearchBLL
    {
        public DataTable Search_CustomerInformationBLL(Customer aCustomer,OrderDetails aOrderDetails)
        { DataTable dt =null;
            if (aCustomer.ID==0 && aCustomer.ContactNo=="" && aCustomer.Address=="" && aCustomer.name=="" && aOrderDetails.IssueDate=="" && aOrderDetails.DeliveryDate=="" )
            {
                return dt;
            }
            else
            {
                SearchDAL aSearchDAL = new SearchDAL();
                dt = aSearchDAL.Search_CustomerInformationDALL(aCustomer, aOrderDetails);
                return dt;
            }
        }
    }
}
