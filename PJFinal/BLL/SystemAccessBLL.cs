using PJFinal.DAL;
using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.BLL
{
    class SystemAccessBLL
    {
        public bool SetSystemAccessBLL(SystemAccess aSyatemAccess, string ConfirmPassword)
        {
            if (aSyatemAccess.userName == "" || aSyatemAccess.Password == "" || ConfirmPassword != aSyatemAccess.Password)
            {
                return false;
            }
            else
            {
                SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
                bool res = aSystemAccessDAL.SetSystemAccessDAL(aSyatemAccess);
                return res;
            }
        }
        public DataTable CheckSystemAccessBLL()
        {
            
                SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
                DataTable res = aSystemAccessDAL.CheckSystemAccessDAL();
                return res;
            }
        }
    }

