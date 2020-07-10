using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class SearchEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = EmployeeLogic.Search("");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // logic 
        string name = txtSearchName.Text;
        DataTable dt = EmployeeLogic.Search(name);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}