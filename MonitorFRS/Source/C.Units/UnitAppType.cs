using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MonitorFRS.Source.C.Units
{
    #region Class
    class UnitAppType
    {
    }

    public static class frmLogin_LoginInfo
    {
        public static string sloginId { get; set; }
        public static string sAccountNo { get; set; }
        public static string sUserId { get; set; }
        public static string sUserName { get; set; }
        public static string sAppId { get; set; }
        public static string sGroupName { get; set; }
        public static string sEmpNo { get; set; }
        public static bool bChkLogin { get; set; }
    }

    public static class frmLogin_FRS_Info
    {
        public static int iIDX { get; set; }

        public static string sSTATUS { get; set; }
        //public static DataTable dtTest { get; set; }
    }    
    #endregion

}
