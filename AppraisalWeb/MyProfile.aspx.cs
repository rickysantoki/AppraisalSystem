using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Employee Emp = (Employee)Session["Employee"];
            txtName.Text = Emp.Name;
            Department dept = DepartmentLogic.SelectByID(Emp.Dept_Id);
            if (dept != null)
            {
                txtDeparment.Text = dept.Dept_Name;
            }
            txtDOJ.Text = Emp.DOJ.ToShortDateString();
            txtCycle.Text = Emp.AppraisalCycle;
            txtEmailID.Text = Emp.Email;
            txtMobileNumber.Text = Emp.Phone;
            UserImage.ImageUrl = "~/uploads/" + Emp.Photo;
            txtDOB.Text = Convert.ToString(Emp.DOB).Split(' ')[0];
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Employee obj = EmployeeLogic.SelectByID(((Employee)Session["Employee"]).Emp_Id);
        obj.Name = txtName.Text;
        obj.Phone = txtMobileNumber.Text;
        obj.Email = txtEmailID.Text;
        obj.DOB = Convert.ToDateTime(txtDOB.Text);

        if (FileUpload2.HasFile)
        {
            string prefix = DateTime.Now.Ticks.ToString();
            FileUpload2.SaveAs(Server.MapPath("uploads\\" + prefix + FileUpload2.FileName));
            obj.Photo = prefix + FileUpload2.FileName;
        }

        EmployeeLogic.Update(obj);
        Session["Employee"] = obj;
        Response.Redirect("MyProfile.aspx");
        

    }

}