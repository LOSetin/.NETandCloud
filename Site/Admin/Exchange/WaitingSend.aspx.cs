﻿using Arrow.Framework.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arrow.Framework.Extensions;
using Arrow.Framework;
using TMS;
using System.Data;
using System.Collections.Generic;

public partial class WaitingSend : AdminBase
{
    protected List<LineCatInfo> allCats = LineBLL.SelectCatList("1=1");

    protected void Page_Load(object sender, EventArgs e)
    {
        SetNav("等待发货");
        if(!Page.IsPostBack)
        {
            BindData();
        }
    }


    protected void BindData()
    {
        string condition = "ExchangeStatus='" + ExchangeStatus.WaitingSend + "'";
        DateTime dtBegin = GetUrlDateTime("bdate");
        DateTime dtEnd = GetUrlDateTime("edate");


       if(dtBegin!=DateTime.MinValue && dtEnd!=DateTime.MinValue && dtBegin<=dtEnd)
        {
            condition = condition + " And AddTime>='" + dtBegin.ToStartString() + "' And AddTime<='" + dtEnd.ToEndString() + "'";
        }

        AdminSetting.CreateWebPagerForGridView(gvData, ArrowControlPageIndex);

        WebQuery query = new WebQuery();
        query.Fields = "*";
        query.OrderBy = "ID desc";
        query.PrimaryKey = "ID";
        query.SqlCreateType = ControlSqlCreateType.RowNum;
        query.TableName = "V_ExchangeHistory";
        query.Condition = condition;

        gvData.Db = TMS.Db.Helper;
        gvData.Query = query;
        gvData.CreateDataSource();
        gvData.DataBind();

        tbBegin.Text = dtBegin == DateTime.MinValue ? "" : dtBegin.ToDateOnlyString();
        tbEnd.Text = dtEnd == DateTime.MinValue ? "" : dtEnd.ToDateOnlyString();
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.FindControl("lbtnConfirm")).Attributes.Add("onclick", "return confirm('确定发货？');");
        }
    }

    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName;
        int id = e.CommandArgument.ToArrowInt();
        if (e.CommandName == "ConfirmData")
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string memberUserName = (gvData.Rows[drv.RowIndex].FindControl("hfMemberUserName") as HiddenField).Value;
            string expressName = (gvData.Rows[drv.RowIndex].FindControl("tbExpressName") as TextBox).Text.Trim();
            string expressNum = (gvData.Rows[drv.RowIndex].FindControl("tbExpressNum") as TextBox).Text.Trim();
            if (expressName.IsNullOrEmpty() || expressNum.IsNullOrEmpty())
            {
                MessageBox.Show("请输入快递公司名称和单号！");
            }
            else
            {
                var model = new CostHistory().Select(id);
                if(model==null)
                {
                    MessageBox.Show("该记录不存在！");
                }
                else
                {
                    model.ExpressName = expressName;
                    model.ExpressNum = expressNum;
                    model.SendTime = DateTime.Now;
                    model.ExchangeStatus = ExchangeStatus.WaitingReceive;
                    new CostHistory().Update(model);
                    BindData();
                    MessageBox.Show("发货成功！");
                }

              
            }
           
        }
       
        
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("WaitingSend.aspx?bdate=" + tbBegin.Text.Trim()+"&edate="+tbEnd.Text.Trim());
    }

    
}