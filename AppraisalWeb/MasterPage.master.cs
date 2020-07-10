using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["Employee"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = ((Employee)Session["Employee"]).Name;

        if(((Employee)Session["Employee"]).IsAdmin)
        {
            DeptConfig.Visible = true;
            EmployeeConfig.Visible = true;
            AppraisalFormDetail.Visible = true;
            AppraisalFormList.Visible = true;
            FinalAppraisalList.Visible = true;
        }
    }
}
