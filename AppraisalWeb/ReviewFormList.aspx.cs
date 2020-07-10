using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
public partial class ReviewFormList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Employee emp = ((Employee)Session["Employee"]);
        DataTable dt = Emp_FormLogic.SelectByAssignedId(emp.Emp_Id);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}