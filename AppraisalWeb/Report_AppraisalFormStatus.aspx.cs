using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class Report_AppraisalFormStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Appraisal_Form af = Appraisal_FormLogic.SelectByID(Convert.ToInt32(Request.QueryString["FID"]));
        txtAppForm.Text = af.Start_Date.ToString("dd-MM-yyyy") + " to " + af.End_Date.ToString("dd-MM-yyyy");
        GridView1.DataSource = Appraisal_FormLogic.SelectStatusReportByDepartmntID(af.Dept_Id);
        GridView1.DataBind();
    }



    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        Appraisal_Form af = Appraisal_FormLogic.SelectByID(Convert.ToInt32(Request.QueryString["FID"]));
        txtAppForm.Text = af.Start_Date.ToString("dd-MM-yyyy") + " to " + af.End_Date.ToString("dd-MM-yyyy");
        DataTable dt  = Appraisal_FormLogic.SelectStatusReportByDepartmntID(af.Dept_Id);

        foreach (DataRow dr in dt.Rows)
        {
            String email = dr["Email"].ToString();
            String subject = "Notification for Appraisal Status";
            String body = "Hello " + dr["Name"] + ",\n\n Your Status for Appraisal is: " + dr["Status"] + ". We will keep you updated with further information. \n\n Thanks and Regards, Management Team, Appraisal System. \n\n\n[This is an auto generated email]";

            try
            {
                sendEmail(email, subject, body);
            }
            catch (Exception) { }
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