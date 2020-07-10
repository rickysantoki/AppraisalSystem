using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class ReviewForm : System.Web.UI.Page
{
    private DataTable FormItems;
    protected void Page_Load(object sender, EventArgs e)
    {
        Employee Emp = (Employee)Session["Employee"];
        
        //if (!IsPostBack)
        //{
        CreateDynamicControls();
        //}
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (IsPostBack)
        //{
        //    DynamicControlsHolder = new PlaceHolder();
        //    CreateDynamicControls();
        //}
    }

    private DataTable GetData()
    {
        var employee = ((Employee)Session["Employee"]);
        if (employee != null)
        {
            DataTable appraisalFormItemTable;

            appraisalFormItemTable = App_Form_ItemLogic.SelectByEmpID(employee.Emp_Id);
            return appraisalFormItemTable;

        }
        return null;
    }


    private void CreateDynamicControls()
    {
        var employee = ((Employee)Session["Employee"]);

            if (Request.QueryString["RID"] == null)
            {
                btnApply.Visible = false;
                return;
            }
            else
            {
                FormItems = Emp_Form_ItemLogic.SelectByEmpFormIdForReview(Convert.ToInt32(Request.QueryString["RID"]));
                
            }

        if (FormItems == null || FormItems.Rows.Count <= 0)
        {
            btnApply.Visible = false;
            return;
        }
        Table table1 = new Table();

        table1.CellPadding = 5;
        foreach (DataRow que in FormItems.Rows)
        {
            TableRow tRow = new TableRow();
            table1.Rows.Add(tRow);
            var label = new Label();
            label.ID = "lbl" + que["Emp_Form_Item_Id"].ToString();
            label.Text = que["Title"].ToString();
             
            TableCell tCell = new TableCell();
            tCell.Width = 300;
            tCell.Controls.Add(label);
            tCell.ColumnSpan = 2;
            tRow.Cells.Add(tCell);

            var textBox = new TextBox();
            textBox.ID = "txt" + que["Emp_Form_Item_Id"].ToString();
            textBox.AutoPostBack = true;
            textBox.Text = que["Answer"].ToString();
            textBox.Enabled = false;
            textBox.TextMode = TextBoxMode.MultiLine;
            textBox.Width = 470;
            TableCell tcel2 = new TableCell();
            tcel2.Width = 300;
            tcel2.Controls.Add(textBox);
            tcel2.HorizontalAlign = HorizontalAlign.Left;
            tcel2.ColumnSpan = 2;
            tRow.Cells.Add(tcel2);

            //var label5 = new Label();
            //label5.ID = "lbltemp" + que["Emp_Form_Item_Id"].ToString();
            //label5.Text = "sdf";
            //TableCell tcel5 = new TableCell();
            //tcel5.Width = 300;
            //tcel5.Controls.Add(label5);
            //tRow.Cells.Add(tcel5);
            //var textBox6 = new TextBox();
            //textBox6.ID = "txttemp" + que["Emp_Form_Item_Id"].ToString();
            
            //TableCell tcel6 = new TableCell();
            //tcel6.Width = 300;
            //tcel6.Controls.Add(textBox6);
            //tRow.Cells.Add(tcel6);
            ////textBox.CssClass = "input-xlarge focused";


            //System.Web.UI.HtmlControls.HtmlGenericControl dynDivAnswer =
            //new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //dynDivAnswer.Attributes.Add("class", "controls");
            //dynDivAnswer.Controls.Add(textBox);

            //System.Web.UI.HtmlControls.HtmlGenericControl dynDiv1 =
            //new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //dynDiv1.Attributes.Add("class", "control-group");
            //dynDiv1.Controls.Add(label);
            //dynDiv1.Controls.Add(dynDivAnswer);

            //DynamicControlsHolder.Controls.Add(dynDiv1);            
            //DynamicControlsHolder.Controls.Add(textBox);

            var label1 = new Label();
            label1.ID = "lblRating" + que["Emp_Form_Item_Id"].ToString();
            label1.Text = "Rating       ";
            //label1.CssClass = "control-label padding-right:10px;";
            TableRow tRow2 = new TableRow();
            table1.Rows.Add(tRow2);
            TableCell tcel3 = new TableCell();
            tcel3.Width = 300;
            tcel3.Controls.Add(label1);
            tRow2.Cells.Add(tcel3);
            DropDownList ddl = new DropDownList();
            ddl.ID = "txtRating" + que["Emp_Form_Item_Id"].ToString();
            ddl.Items.Add(new ListItem("Poor", "1"));
            ddl.Items.Add(new ListItem("Average", "2"));
            ddl.Items.Add(new ListItem("Good", "3"));
            ddl.Items.Add(new ListItem("Very Good", "4"));
            ddl.Items.Add(new ListItem("Outstanding", "5"));
            //ddl.CssClass = "controls";
            ddl.AutoPostBack = true;
            TableCell tcel4 = new TableCell();
            tcel4.Width = 300;
            tcel4.HorizontalAlign = HorizontalAlign.Right;
            tcel4.Controls.Add(ddl);
            tRow2.Cells.Add(tcel4);
            //System.Web.UI.HtmlControls.HtmlGenericControl dynDiv =
            //new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //dynDiv.Attributes.Add("class", "controls");
            //dynDiv.Controls.Add(ddl);


            //System.Web.UI.HtmlControls.HtmlGenericControl dynDiv2 =
            //new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //dynDiv2.Attributes.Add("class", "control-group");
            //dynDiv2.Controls.Add(label1);
            //dynDiv2.Controls.Add(dynDiv);
            
            //var textBox1 = new TextBox();
            //textBox1.ID = "txtRating" + que["Emp_Form_Item_Id"].ToString();
            //textBox1.AutoPostBack = true;
            
           
            //DynamicControlsHolder.Controls.Add(dynDiv);

            var label2 = new Label();
            label2.ID = "lblRemarks" + que["Emp_Form_Item_Id"].ToString();
            label2.Text = "Remarks";            
            TableCell tcel7 = new TableCell();
            tcel7.Width = 300;
            tcel7.Controls.Add(label2);
            tRow2.Cells.Add(tcel7);

            var textBox2 = new TextBox();
            textBox2.ID = "txtRemarks" + que["Emp_Form_Item_Id"].ToString();
            textBox2.AutoPostBack = true;
            //textBox2.CssClass = "input-xlarge focused";
            TableCell tcel8 = new TableCell();
            tcel8.Width = 300;
            tcel8.Controls.Add(textBox2);
            tRow2.Cells.Add(tcel8);
            //DynamicControlsHolder.Controls.Add(label2);
            //DynamicControlsHolder.Controls.Add(textBox2);
            //DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
            //DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
            //DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
            //DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
            DynamicControlsHolder.Controls.Add(table1);
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        Employee emp = ((Employee)Session["Employee"]);
        Emp_FormLogic.UpdateStatus(Convert.ToInt32(Request.QueryString["RID"]),"Reviewed");
        foreach (DataRow que in FormItems.Rows)
        {
            DropDownList ddlList = DynamicControlsHolder.FindControl("txtRating" + que["Emp_Form_Item_Id"].ToString()) as DropDownList;
            string Rating = ddlList.SelectedItem.ToString();
            TextBox txtbox1 = DynamicControlsHolder.FindControl("txtRemarks" + que["Emp_Form_Item_Id"].ToString()) as TextBox;
            Emp_Form_Review empFormItem = new Emp_Form_Review() { Emp_Form_Item_Id = Convert.ToInt32(que["Emp_Form_Item_Id"]), Rating= Rating , Remarks = txtbox1.Text, Reviewer_Id = emp.Emp_Id};
            Emp_Form_ReviewLogic.Insert(empFormItem);

        }
        Response.Redirect("ReviewFormList.aspx");

    }
}