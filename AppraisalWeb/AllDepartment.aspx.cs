using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class AllDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int did = Convert.ToInt32(Request.QueryString["ID"]);
        //Department d = DepartmentLogic.SelectByID(did);
        DataTable dt = DepartmentLogic.GetDetail();
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}