using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Net;
using System.Net.Mail;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Employee"] = null;
        Session["EmpId"] = null;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Employee Emp = EmployeeLogic.Validate(txtUname.Text, txtPassword.Text);
        if (Emp.Emp_Id > 0)
        {
            Session["Employee"] = Emp;
            Session["EmpId"] = Emp.Emp_Id;
            Response.Redirect("Home.aspx");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Employee Emp = EmployeeLogic.SelectByUserName(txtUname.Text);
        if (Emp.Emp_Id > 0)
        {

            sendEmail(Emp.Email, "Forgot Password", "Your Password is " + Emp.Password);
            
        }
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