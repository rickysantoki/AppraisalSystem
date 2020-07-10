using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
public partial class NewDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillDropDowns();

            if (Request.QueryString["ID"] != null)
            {
                int did = Convert.ToInt32(Request.QueryString["ID"]);
                Department d = DepartmentLogic.SelectByID(did);
                txtDeptName.Text = d.Dept_Name;

                ddlHead.SelectedValue = d.Dept_Id.ToString();
            }
            else
            {
            }



        }
    }

    private void fillDropDowns()
    {
        DataTable dt = EmployeeLogic.SelectAll();
        ddlHead.DataTextField = "Name";
        ddlHead.DataValueField = "Emp_Id";
        ddlHead.DataSource = dt;
        ddlHead.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {
            Department obj = new Department();
            obj.Dept_Name = txtDeptName.Text;
            obj.Dept_Head_Id = Convert.ToInt32(ddlHead.SelectedItem.Value);

            DepartmentLogic.Insert(obj);

            Response.Redirect("AllDepartment.aspx");
        }
        else
        {
            Department obj = DepartmentLogic.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));
            obj.Dept_Name = txtDeptName.Text;
            obj.Dept_Head_Id = Convert.ToInt32(ddlHead.SelectedItem.Value);

            DepartmentLogic.Update(obj);

            Response.Redirect("AllDepartment.aspx");
        }
    }

}
