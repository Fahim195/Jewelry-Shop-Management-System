using PJFinal.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class DeliveryScheduleBLL
    {
        public DataTable[] ViewDeliveryScheduleBLL(string scheduleTimeLimit, string sDate, string eDate)
        {
            DataTable[] aDataTable = null;
            aDataTable = null;
            if (scheduleTimeLimit=="")
            {
                return aDataTable;
            }
            else
            {
                DeliveryScheduleDAL aDeliveryScheduleDAL = new DeliveryScheduleDAL();
                aDataTable = aDeliveryScheduleDAL.ViewDeliverySchedule(scheduleTimeLimit,sDate,eDate);
                return aDataTable;
            }
        }
    }
}
