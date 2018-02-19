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
    class DesignBLL
    {
        public DataTable SaveDesignBLL(Design aDesign)
        {
            DataTable dTable = null;
            if (aDesign.DID == 0 || aDesign.DesignCost == 0 || aDesign.Details == "" || aDesign.images == null)
            {
                return dTable;
            }
            else
            {
                DesignDAL aDesignDAL = new DesignDAL();
                dTable = aDesignDAL.SaveDesignDAL(aDesign);
                return dTable;
            }
        }
        public DataTable GetDesignInformationInGridView()
        {
            DesignDAL aDesignDAL = new DesignDAL();
            DataTable dTable = aDesignDAL.GetDesignInformationInGridView();
            return dTable;
        }
        public DataTable UpdateDesignBLL(Design aDesign,int DesignID_BeforeUpdate)
        {
            DataTable dTable = null;
            if (aDesign.DID == 0 || aDesign.DesignCost == 0 || aDesign.Details == "" || DesignID_BeforeUpdate==0)
            {
                return dTable;
            }
            else
            {
                DesignDAL aDesignDAL = new DesignDAL();
                dTable = aDesignDAL.UpdateDesignDAL(aDesign, DesignID_BeforeUpdate);
                return dTable;
            }
        }
        public DataTable DeleteDesign_BLL(Design aDesign)
        {
            DataTable dTable = null;
            if (aDesign.DID == 0 || aDesign.DesignCost == 0 || aDesign.Details == "" )
            {
                return dTable;
            }
            else
            {
                DesignDAL aDesignDAL = new DesignDAL();
                dTable = aDesignDAL.DeleteDesign_DAL(aDesign);
                return dTable;
            }
        }
        public DataTable GetDesignIn_GalleryBLLL()
        {
            DesignDAL aDesignDAL = new DesignDAL();
            DataTable dTable = aDesignDAL.GetDesignIn_GalleryDAL();
            return dTable;
        }
    }
}
