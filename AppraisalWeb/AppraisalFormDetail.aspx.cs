using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using System.Globalization;
using System.Net;
using System.Net.Mail;


public partial class AppraisalFormDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTitle.Visible = false;
        if (!IsPostBack)
        {
            fillDropDowns();
            if (Request.QueryString["FID"] != null)
            {
                int AppForm_Id = Convert.ToInt32(Request.QueryString["FID"]);
                Appraisal_Form aform = Appraisal_FormLogic.SelectByID(AppForm_Id);
                ddlDept1.SelectedValue = aform.Dept_Id.ToString();
                txtStart.Text = Convert.ToString(aform.Start_Date).Split(' ')[0];
                txtEnd.Text = Convert.ToString(aform.End_Date).Split(' ')[0];
                ddlAppCycle.SelectedValue = aform.AppraisalCycle;
                if (Request.QueryString["IsEdit"] == null)
                {
                    ddlDept1.Enabled = false;
                    txtStart.Enabled = false;
                    txtEnd.Enabled = false;
                    ddlAppCycle.Enabled = false;
                    
                }
                else if (Request.QueryString["IsEdit"] == "1")
                {
                    ddlDept1.Enabled = false;
                }

                DataTable dt = App_Form_ItemLogic.SelectByAppraisalFormID(AppForm_Id);
                GridView2.DataSource = dt;
                GridView2.DataBind();

                placeholder1.Visible = true;
            }
            else
            {
                int AppForm_Id = Convert.ToInt32(Request.QueryString["FID"]);
                Appraisal_Form aform = Appraisal_FormLogic.SelectByID(AppForm_Id);
                ddlDept1.SelectedValue = aform.Dept_Id.ToString();
                txtStart.Text = Convert.ToString(aform.Start_Date).Split(' ')[0];
                txtEnd.Text = Convert.ToString(aform.End_Date).Split(' ')[0];
                ddlAppCycle.SelectedValue = aform.AppraisalCycle;
                
                DataTable dt = App_Form_ItemLogic.SelectByAppraisalFormID(AppForm_Id);
                GridView2.DataSource = dt;
                GridView2.DataBind();

                placeholder1.Visible = true;
            }
        }
    }

    private void fillDropDowns()
    {
        DataTable dt = DepartmentLogic.SelectAll();
        ddlDept1.DataTextField = "Dept_Name";
        ddlDept1.DataValueField = "Dept_Id";
        ddlDept1.DataSource = dt;
        ddlDept1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["FID"] == null)
        {
            Appraisal_Form obj = new Appraisal_Form();
            Department Department = DepartmentLogic.SelectByName(ddlDept1.SelectedItem.Text);
            if (Department != null && Department.Dept_Id != 0)
            {
                obj = Appraisal_FormLogic.SelectByDepartmentID(Department.Dept_Id);

                if (obj == null || obj.App_Form_Id == 0)
                {
                    obj.Dept_Id = Department.Dept_Id;
                    obj.Start_Date = DateTime.Parse(txtStart.Text);
                    obj.End_Date = DateTime.Parse(txtEnd.Text);
                    obj.AppraisalCycle = ddlAppCycle.SelectedValue;

                    int x = Appraisal_FormLogic.Insert(obj);

                    DataTable dt = EmployeeLogic.SelectByDepartment(obj.Dept_Id, obj.AppraisalCycle);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sendEmail(dt.Rows[i]["Email"].ToString(), "Your Appraisal Form is Released", "Hello, " + dt.Rows[i]["Name"].ToString() + "<br/> Your Appraisal Form is Released. Last Date for submission is : " + obj.End_Date.ToString("dd-MM-yyyy"));
                    }
                    
                    Response.Redirect("AppraisalFormDetail.aspx?FID=" + x);
                }
                else if (Request.QueryString["IsEdit"] != null && obj != null)
                {
                    int x = Appraisal_FormLogic.Update(obj);
                    Response.Redirect("AppraisalFormList.aspx");
                }
                else
                {
                    lblTitle.Visible = true;
                    lblTitle.Text = string.Format("Appraisal form already exist for [{0}] department", ddlDept1.SelectedItem.Text);
                }
            }
        }
        else
        {
            Appraisal_Form obj = Appraisal_FormLogic.SelectByID(Convert.ToInt32(Request.QueryString["FID"]));

            obj.Dept_Id = Convert.ToInt32(ddlDept1.SelectedItem.Value);

            obj.Start_Date = DateTime.Parse(txtStart.Text);
            obj.End_Date = DateTime.Parse(txtEnd.Text);

            obj.AppraisalCycle = ddlAppCycle.SelectedValue;

            Appraisal_FormLogic.Update(obj);

            Response.Redirect("AppraisalFormList.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AppraisalFormItemDetail.aspx?FID=" + Request.QueryString["FID"]);

    }

    private void sendEmail(string email, String subject, String body)
    {
        using (MailMessage mm = new MailMessage("appraisal121212@gmail.com", email))
        {
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("appraisal121212@gmail.com", "rutva121212");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email Sent Successfully');", true);
        }
    }
}