﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberLogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MemberBLL.LogOut();
        Response.Redirect("Default.aspx");
    }
}