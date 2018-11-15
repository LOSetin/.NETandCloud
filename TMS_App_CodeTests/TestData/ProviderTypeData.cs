using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_App_CodeTests.Auto.Model;
using TMS_App_CodeTests.Common;

namespace TMS_App_CodeTests.TestData
{
    public class ProviderTypeData
    {
        public SiteMemberInfo MemberData(string UserName)
        {
            SiteMemberInfo sm = new SiteMemberInfo();
            var path = @"..\..\..\TMS_App_CodeTests\TestData\ProviderTypeData_AddProviderType.csv";
            var dt = CSVFileHelper.OpenCSV(path);
            foreach (DataRow dr in dt.Rows)
            {
                string username=dr[0].ToString();
                if (UserName == username)
                {
                    sm.UserName= dr[0].ToString();
                    sm.UserPwd = dr[1].ToString();
                    sm.RealName = dr[2].ToString();
                    sm.HeadPicPath = dr[3].ToString();
                    sm.Sex = dr[4].ToString();
                    sm.MobileNum = dr[5].ToString();
                    sm.IDNum = dr[6].ToString();
                    sm.Email = dr[7].ToString();
                    sm.QQ = dr[8].ToString();
                    sm.WeChat = dr[9].ToString();
                    sm.TotalCost = Convert.ToDecimal(dr[10].ToString());
                    sm.TotalPoints = Convert.ToInt32(dr[11].ToString());
                    sm.UsedPoints = Convert.ToInt32(dr[12].ToString());
                    sm.AddTime = Convert.ToDateTime(dr[13].ToString());
                    sm.Remarks = dr[14].ToString();
                    sm.InviteNum = dr[15].ToString();
                    sm.InviterUserName = dr[16].ToString();
                    sm.InviterRealName = dr[17].ToString();
                }
                else
                {
                    sm = null;
                }
            }
            return sm;
        }

        public string[] MemberName(string fileName)
        {
            var path = @"..\..\..\TMS_App_CodeTests\TestData\" + fileName;
            var dt = CSVFileHelper.OpenCSV(path);
            string[] username=new string[100000];
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString()!=null)
                {
                    username[count] = dr[0].ToString();
                    count++;
                }
            }
            return username;
        }
    }
    
}
