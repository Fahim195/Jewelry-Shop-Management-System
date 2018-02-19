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
    class OrderBLL
    {
        public int GetMaxIDforCustomerBLL()
        {
            OrderDAL aOrderDAL = new OrderDAL();
            int MAxID = aOrderDAL.GetMaxIDforCustomerDAL();
            if (MAxID > 0)
            {
                MAxID = MAxID + 1;
                return MAxID;
            }
            else
            {
                MAxID = MAxID + 1;
                return MAxID;
            }
        }
        public DataTable GetDesigningCharge_BLL(Design aDesign)
        {
            if (aDesign.DID <= 0)
            {
                return null;
            }
            else
            {
                OrderDAL aOrderDal = new OrderDAL();
                DataTable dTable = aOrderDal.GetDesigningCharge_DAL(aDesign);
                return dTable;
            }
        }
        public bool SaveOrderUIInformationBLL(Customer aCustomer, OrderDetails aOrderDetails, Payment aPayment, string[,] arr, int TotalNumberOfOrder)
        {
            if (aCustomer.ID<=0 || aCustomer.name == "" || aCustomer.ContactNo =="" || aCustomer.Address == "" || aOrderDetails.IssueDate==""|| aOrderDetails.DeliveryDate == ""|| aOrderDetails.RateOfProduct <= 0 || aOrderDetails.DeliveryDate == "" || aOrderDetails.TotalWeight <= 0 || aOrderDetails.DepositedProductAmount < 0 || arr==null || aPayment.ProductCharge <= 0 || aPayment.DesigningCharge <= 0 || aPayment.TotalBill <=0 || aPayment.Advance <=0 || aPayment.Due <= 0 || aPayment.LastPayment <=0 )
            {
                return false;
            }
            else
            {
                OrderDAL aOrderDAL = new OrderDAL();
                 bool res=aOrderDAL.SaveOrderUIInformationDAL( aCustomer, aOrderDetails, aPayment, arr,  TotalNumberOfOrder);
                 if (res)
                {
                    return res;

                }
                else
                {
                    return false;
                }
            }
        }
        public DataTable[] SearchOrderInformationTo_UpdateBLL(Customer aCustomer)
        {
            if (aCustomer.ID<=0)
            {
                return new DataTable[] { null };
            }
            else
            {
                OrderDAL aOrderDAL = new OrderDAL();
                DataTable[] dTables = aOrderDAL.SearchOrderInformationTo_UpdateDAL(aCustomer);
                return dTables;
            }
        }
        public bool UpdateOrderInformationBLL(Customer aCustomer, OrderDetails aOrderDetails, Payment aPayment, string[,] arr, int TotalNumberOfOrder)
        {
            if (aCustomer.ID <= 0 || aCustomer.name == "" || aCustomer.ContactNo == "" || aCustomer.Address == "" || aOrderDetails.IssueDate == "" || aOrderDetails.DeliveryDate == "" || aOrderDetails.RateOfProduct <= 0 || aOrderDetails.DeliveryDate == "" || aOrderDetails.TotalWeight <= 0 || aOrderDetails.DepositedProductAmount < 0 || arr == null ||  aPayment.ProductCharge <= 0 || aPayment.DesigningCharge <= 0 || aPayment.TotalBill <= 0 || aPayment.Advance <= 0 || aPayment.Due <= 0|| aPayment.LastPayment <= 0)
            {
                return false;
            }
            else
            {
                OrderDAL aOrderDAL = new OrderDAL();
                bool res = aOrderDAL.UpdateOrderUIInformationDAL(aCustomer, aOrderDetails, aPayment, arr, TotalNumberOfOrder);
                if (res)
                {
                    return res;

                }
                else
                {
                    return false;
                }
            }
        }
        public bool CancelOrderBLL(Customer aCustomer, OrderDetails aOrderDetails, Payment aPayment, string[,] arr, int TotalNumberOfOrder)
        {
            if (aCustomer.ID <= 0 || aCustomer.name == "" || aCustomer.ContactNo == "" || aCustomer.Address == "" || aOrderDetails.IssueDate == "" || aOrderDetails.DeliveryDate == "" || aOrderDetails.RateOfProduct <= 0 || aOrderDetails.DeliveryDate == "" || aOrderDetails.TotalWeight <= 0 || aOrderDetails.DepositedProductAmount < 0 || arr == null || aPayment.ProductCharge <= 0 || aPayment.DesigningCharge <= 0 || aPayment.TotalBill <= 0 || aPayment.Advance <= 0 || aPayment.Due <= 0 || aPayment.LastPayment <= 0)
            {
                return false;
            }
            else
            {
                OrderDAL aOrderDAL = new OrderDAL();
                bool res = aOrderDAL.CancelOrderDAL(aCustomer);
                if (res)
                {
                    return res;

                }
                else
                {
                    return false;
                }
            }
        }

    }
}
