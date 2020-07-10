using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class AppraisalFormItemDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["FIID"] == null)
            {

            }
            else
            {
                App_Form_Items obj = App_Form_ItemLogic.SelectByID(Convert.ToInt32(Request.QueryString["FIID"]));
                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                //App_Form_ItemLogic.Update(obj);

                //Response.Redirect("AppraisalFormDetail.aspx?FID=" + obj.App_Form_Id);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         if (Request.QueryString["FID"] != null)
        {
            App_Form_Items obj = new App_Form_Items();

            obj.App_Form_Id = Convert.ToInt32(Request.QueryString["FID"]);
            obj.Title = txtTitle.Text;
            obj.Description = txtDescription.Text;

            App_Form_ItemLogic.Insert(obj);

            Response.Redirect("AppraisalFormDetail.aspx?FID=" + obj.App_Form_Id);
        }
         if (Request.QueryString["FIID"] != null)
        {
            App_Form_Items obj = App_Form_ItemLogic.SelectByID(Convert.ToInt32(Request.QueryString["FIID"]));
           // obj.App_Form_Id = Convert.ToInt32(Request.QueryString["FIID"]);
            obj.Title = txtTitle.Text;
            obj.Description = txtDescription.Text;
            App_Form_ItemLogic.Update(obj);

            Response.Redirect("AppraisalFormDetail.aspx?FID=" + obj.App_Form_Id);
        }
    }
    
}
   