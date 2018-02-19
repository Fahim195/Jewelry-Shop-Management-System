using PJFinal.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class HomeBLL
    {
        public DataTable[] GetInformationInHomeUI_BLL()
        {
            HomeDAL aHomeDAL = new HomeDAL();
            DataTable[] values = aHomeDAL.GetInformationInHomeUI_DAL();
            return values;
        }
    }
}
