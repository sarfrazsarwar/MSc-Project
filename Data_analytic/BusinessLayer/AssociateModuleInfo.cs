using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class AssociateModuleInfo
    {
        private DataTable DT = new DataTable("Academic_associated_info");
        
        public DataTable GetProgramingAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=1";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
       
    }
}
