using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS_App_CodeTests.Auto.Model;
using TMS_App_CodeTests.TestData;

namespace TMS_App_CodeTests.Auto.DataAccess
{
    public partial class SiteMember
    {
        //private const string TABLE_NAME = "SiteMember";
        //private const string ALL_FIELDS = "UserName,UserPwd,RealName,HeadPicPath,Sex,MobileNum,IDNum,Email,QQ,WeChat,TotalCost,TotalPoints,UsedPoints,AddTime,Remarks,InviteNum,InviterUserName,InviterRealName,ExtraFields";
        //private const string SQL_ADD = "Insert Into SiteMember (UserName,UserPwd,RealName,HeadPicPath,Sex,MobileNum,IDNum,Email,QQ,WeChat,TotalCost,TotalPoints,UsedPoints,AddTime,Remarks,InviteNum,InviterUserName,InviterRealName,ExtraFields)Values(@UserName,@UserPwd,@RealName,@HeadPicPath,@Sex,@MobileNum,@IDNum,@Email,@QQ,@WeChat,@TotalCost,@TotalPoints,@UsedPoints,@AddTime,@Remarks,@InviteNum,@InviterUserName,@InviterRealName,@ExtraFields)";
        //private const string SQL_UPDATE = "Update SiteMember Set UserPwd=@UserPwd,RealName=@RealName,HeadPicPath=@HeadPicPath,Sex=@Sex,MobileNum=@MobileNum,IDNum=@IDNum,Email=@Email,QQ=@QQ,WeChat=@WeChat,TotalCost=@TotalCost,TotalPoints=@TotalPoints,UsedPoints=@UsedPoints,AddTime=@AddTime,Remarks=@Remarks,InviteNum=@InviteNum,InviterUserName=@InviterUserName,InviterRealName=@InviterRealName,ExtraFields=@ExtraFields Where ";
        //private const string SQL_SELECT = "Select UserName,UserPwd,RealName,HeadPicPath,Sex,MobileNum,IDNum,Email,QQ,WeChat,TotalCost,TotalPoints,UsedPoints,AddTime,Remarks,InviteNum,InviterUserName,InviterRealName,ExtraFields From SiteMember Where ";
        //private const string SQL_DELETE = "Delete From SiteMember Where ";
        //private const string SQL_TOP = "Select Top {0} UserName,UserPwd,RealName,HeadPicPath,Sex,MobileNum,IDNum,Email,QQ,WeChat,TotalCost,TotalPoints,UsedPoints,AddTime,Remarks,InviteNum,InviterUserName,InviterRealName,ExtraFields From SiteMember Where {1} Order By {2}";
        //private const string SQL_COUNT = "Select Count(*) From SiteMember Where ";
        //private const string SQL_PAGE = "Select {0} From(Select {0},Row_Number() Over(Order By {3}) as RowNum From {1} Where {2}) t Where RowNum>{4} and RowNum<={5} ";
        //private const string PK_PARA_SET = "UserName = @UserName";
        //private const string PK_PARA = "@UserName";

        public SiteMemberInfo Select(string userName)
        {
            //string strSql = SQL_SELECT + PK_PARA_SET;
            ProviderTypeData pd = new ProviderTypeData();
            return pd.MemberData(userName); 
        }
    }
}
