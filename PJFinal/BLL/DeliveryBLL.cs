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
    class DeliveryBLL
    {
        public DataTable[] SearchOrderInformationforDELIVERY_UIto_UpdateBLL(Customer aCustomer)
        {
            if (aCustomer.ID <= 0)
            {
                return new DataTable[] { null };
            }
            else
            {
                DeliveryDAL aDeliveryDAL = new DeliveryDAL();
                DataTable[] dTables = aDeliveryDAL.SearchOrderInformationforDELIVERY_UIto_UpdateDAL(aCustomer);
                return dTables;
            }
        }
        public bool SaveDeliveryInformationBLL(OrderDetails aOrderDetails, Payment aPayment)
        {
            if (aOrderDetails.FinalWeight<=0 ||aOrderDetails.OrderStatus=="" ||aPayment.ProductCharge <= 0 || aPayment.TotalBill <= 0 ||  aPayment.Due <= 0 || aPayment.LastPayment < 0 ||aPayment.PaymentStatus=="")
            {
                return false;
            }
            else
            {
                DeliveryDAL aDeliveryDAL = new DeliveryDAL();

                bool res = aDeliveryDAL.SaveDeliveryInformationDAL(aOrderDetails, aPayment);
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
        public bool CancelDeliveryBLL(Payment aPayment, OrderDetails aOrderDetails)
        {
            if ( aOrderDetails.OrderStatus == "" || aPayment.TotalBill <=0 || aPayment.Due < 0 || aPayment.LastPayment < 0 || aPayment.PaymentStatus == ""||aPayment.Discount<0 ||aPayment.PaymentStatus==""||aPayment.ProductCharge<=0)
            {
                return false;
            }
            else
            {
                DeliveryDAL aDeliveryDAL = new DeliveryDAL();

                bool res = aDeliveryDAL.CancelDeliveryDAL( aPayment,aOrderDetails);
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
