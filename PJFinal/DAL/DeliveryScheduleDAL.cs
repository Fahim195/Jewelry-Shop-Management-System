using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL
{
    class DeliveryScheduleDAL
    {
        public DataTable[] ViewDeliverySchedule(string scheduleTimeLimit,string sDate,string eDate)
        {
            string StartDate="";
            string EndDate="";
            int Month =int.Parse( DateTime.Now.ToString("MM"));
            int year = int.Parse(System.DateTime.Now.Year.ToString());
            int Totaldays = DateTime.DaysInMonth(year, Month);
            string CurrentDate = DateTime.Now.ToString();          
            string day = DateTime.Today.DayOfWeek.ToString();
            int TodayDate =int.Parse( DateTime.Today.Day.ToString());
            if (scheduleTimeLimit == "Today")
            {
                StartDate= "(select DATEADD(DAY, -1,'" + CurrentDate + "'))";
                EndDate = "(select DATEADD(DAY,1,'" + CurrentDate + "'))";
            }
            else if (scheduleTimeLimit == "Current Week")
            {
                if (day== "Saturday")
                {
                    StartDate = "(select DATEADD(DAY, -1,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,7,'" + CurrentDate + "'))";
                }
                else if (day== "Sunday")
                {
                    StartDate = "(select DATEADD(DAY, -2,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,6,'" + CurrentDate + "'))";
                }
                else if (day == "Monday")
                {
                    StartDate = "(select DATEADD(DAY, -3,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,5,'" + CurrentDate + "'))";
                }
                else if (day == "Tuesday")
                {
                    StartDate = "(select DATEADD(DAY, -4,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,4,'" + CurrentDate + "'))";
                }
                else if (day == "Wednesday")
                {
                    StartDate = "(select DATEADD(DAY, -5,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,3,'" + CurrentDate + "'))";
                }
                else if (day == "Thursday")
                {
                    StartDate = "(select DATEADD(DAY, -6,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,2,'" + CurrentDate + "'))";
                }
                else
                {
                    StartDate = "(select DATEADD(DAY, -7,'" + CurrentDate + "'))";
                    EndDate = "(select DATEADD(DAY,1,'" + CurrentDate + "'))";
                }
            }
            else if (scheduleTimeLimit == "Next Two Week")
            {
                StartDate = "(select DATEADD(DAY, -1,'" + CurrentDate + "'))";
                EndDate = "(select DATEADD(DAY,15,'" + CurrentDate + "'))";
            }
            else if (scheduleTimeLimit == "Current Month")
            {
                int dayAdd = 1;
                if (Totaldays==31)
                {
                    dayAdd = 2;
                }
                int startDate = TodayDate + 1;
                StartDate = "(select DATEADD(DAY,-"+ startDate + ",'" + CurrentDate + "'))";
                int endDate =(Totaldays - TodayDate+ dayAdd);
                EndDate = "(select DATEADD(DAY," + endDate + ",'" + CurrentDate + "'))";
            }
            else if (scheduleTimeLimit == "Specifi‪c Time Period")
            {
                StartDate = "(select DATEADD(DAY, 0,'" + sDate + "'))";
                EndDate = "(select DATEADD(DAY, 0,'" + eDate + "'))";
            }
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "SELECT ORDERS.Item, ORDERS.ProductType, ORDERS.ProductUnit, ORDERS.DID, OrderDetails.DeliveryDate, Customer.ContactNo, Customer.ID FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN ORDERS ON Customer.ID = ORDERS.CID  where OrderDetails.DeliveryDate between "+StartDate+" AND "+EndDate+" ";
            SqlCommand ACtion = new SqlCommand(query,connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = ACtion;
            DataTable dtt = new DataTable();
            sda.Fill(dtt);

            string query2 = "" + StartDate + "";
            SqlCommand ACtion2 = new SqlCommand(query2, connection);
            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = ACtion2;
            DataTable DT = new DataTable();
            sda2.Fill(DT);

            string Querys = "" + EndDate + "";
            SqlCommand ACTIONS = new SqlCommand(Querys, connection);
            SqlDataAdapter SDAS = new SqlDataAdapter();
            SDAS.SelectCommand = ACTIONS;
            DataTable DATATABLE = new DataTable();
            SDAS.Fill(DATATABLE);
            return new DataTable[] { dtt, DT, DATATABLE };
        }
    }
}
