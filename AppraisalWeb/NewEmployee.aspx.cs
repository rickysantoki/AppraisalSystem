using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
public partial class NewEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillDropDowns();

            if (Request.QueryString["ID"] != null)
            {
                int EmpID = Convert.ToInt32(Request.QueryString["ID"]);
                Employee emp = EmployeeLogic.SelectByID(EmpID);
                txtName.Text = emp.Name;
                txtPhone.Text = emp.Phone;
                txtUname.Text = emp.U_Name;
                txtUname.Enabled = false;
                txtPassword.Attributes.Add("value", emp.Password);
                txtPassword.Enabled = false;
                txtDate.Text = Convert.ToString(emp.DOB).Split(' ')[0];
                txtDate1.Text = Convert.ToString(emp.DOJ).Split(' ')[0];
                txtSalary.Text = Convert.ToString(emp.Salary);
                ddlAppCycle.SelectedValue = emp.AppraisalCycle;
                txtEmail.Text = emp.Email;
                cbIsAdmin.Checked = emp.IsAdmin;

                if (emp.IsActive == true)
                {
                    RadioButton1.Checked = true;
                }
                else
                {
                    RadioButton2.Checked = true;
                }


                ddlDept.SelectedValue = emp.Dept_Id.ToString();
                ddlSupervisor.SelectedValue = emp.Sup_Id.ToString();


            }
            else
            {
            }

        }
    }

    private void fillDropDowns()
    {
        DataTable dt = DepartmentLogic.SelectAll();
        ddlDept.DataTextField = "Dept_Name";
        ddlDept.DataValueField = "Dept_Id";
        ddlDept.DataSource = dt;
        ddlDept.DataBind();

        DataTable dt2 = EmployeeLogic.SelectAll();
        ddlSupervisor.DataTextField = "Name";
        ddlSupervisor.DataValueField = "Emp_Id";
        ddlSupervisor.DataSource = dt2;
        ddlSupervisor.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {
            Employee obj = new Employee();
            obj.Name = txtName.Text;

            if (RadioButton1.Checked)
            {
                obj.IsActive = true;
            }
            else
            {
                obj.IsActive = false;
            }
            obj.Phone = txtPhone.Text;
            obj.Salary = Convert.ToSingle(txtSalary.Text);
            obj.Password = txtPassword.Text;
            obj.Email = txtEmail.Text;
            obj.Dept_Id = Convert.ToInt32(ddlDept.SelectedItem.Value);
            obj.Sup_Id = Convert.ToInt32(ddlSupervisor.SelectedItem.Value);
            obj.DOB = Convert.ToDateTime(txtDate.Text);
            obj.DOJ = Convert.ToDateTime(txtDate1.Text);
            obj.U_Name = txtUname.Text;
            obj.AppraisalCycle = ddlAppCycle.SelectedValue;
            obj.IsAdmin = cbIsAdmin.Checked;

            if (FileUpload1.HasFile)
            {
                string prefix = DateTime.Now.Ticks.ToString();
                FileUpload1.SaveAs(Server.MapPath("uploads\\" + prefix + FileUpload1.FileName));
                obj.Photo = prefix + FileUpload1.FileName;
            }

            EmployeeLogic.Insert(obj);

            Response.Redirect("SearchEmployee.aspx");
        }
        else
        {
            Employee obj = EmployeeLogic.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));
            obj.Name = txtName.Text;
    
            obj.IsActive = true;
            obj.Phone = txtPhone.Text;
            obj.Salary = Convert.ToSingle(txtSalary.Text);
           
            obj.Email = txtEmail.Text;
            obj.Dept_Id = Convert.ToInt32(ddlDept.SelectedItem.Value);
            obj.Sup_Id = Convert.ToInt32(ddlSupervisor.SelectedItem.Value);
            obj.DOB = Convert.ToDateTime(txtDate.Text);
            obj.DOJ = Convert.ToDateTime(txtDate1.Text);
            obj.U_Name = txtUname.Text;
            obj.IsAdmin = cbIsAdmin.Checked;


            if (FileUpload1.HasFile)
            {
                string prefix = DateTime.Now.Ticks.ToString();
                FileUpload1.SaveAs(Server.MapPath("uploads\\" + prefix + FileUpload1.FileName));
                obj.Photo = prefix + FileUpload1.FileName;
            }

            EmployeeLogic.Update(obj);

            Response.Redirect("SearchEmployee.aspx");
        }
    }
    
}