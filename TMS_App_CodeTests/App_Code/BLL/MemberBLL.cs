using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS_App_CodeTests.Auto.Model;
using TMS_App_CodeTests.Auto.DataAccess;

namespace TMS_App_CodeTests.App_Code.BLL
{
    public static class MemberBLL
    {
        private static readonly SiteMember dal = new SiteMember();
        public static SiteMemberInfo Select(string userName)
        {
            return dal.Select(userName);
        }
    }
}
