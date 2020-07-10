using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class SearchForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = Appraisal_FormLogic.SelectAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();    
    }
}