using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class FinalReviewForm : System.Web.UI.Page
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
                FormItems = Emp_Form_ItemLogic.SelectByEmpFormIdForFinalReview(Convert.ToInt32(Request.QueryString["RID"]));
                
            }

        if (FormItems == null || FormItems.Rows.Count <= 0)
        {
            btnApply.Visible = false;
            return;
        }
        Table table1 = new Table();
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
            tcel2.ColumnSpan = 2;
            tRow.Cells.Add(tcel2);

            var label1 = new Label();
            label1.ID = "lblRating" + que["Emp_Form_Item_Id"].ToString();
            label1.Text = "Rating";
            TableRow tRow2 = new TableRow();
            table1.Rows.Add(tRow2);
            TableCell tcel3 = new TableCell();
            tcel3.Width = 300;
            tcel3.Controls.Add(label1);
            tRow2.Cells.Add(tcel3);

            var textBox1 = new TextBox();
            textBox1.ID = "txtRating" + que["Emp_Form_Item_Id"].ToString();
            textBox1.AutoPostBack = true;
            textBox1.Text = que["Rating"].ToString();
            textBox1.Enabled = false;
            TableCell tcel4 = new TableCell();
            tcel4.Width = 300;
            //tcel4.HorizontalAlign = HorizontalAlign.Right;
            tcel4.Controls.Add(textBox1);
            tRow2.Cells.Add(tcel4);


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
            textBox2.Text = que["Remarks"].ToString();
            textBox2.Enabled = false;
            TableCell tcel8 = new TableCell();
            tcel8.Width = 300;
            tcel8.Controls.Add(textBox2);
            tRow2.Cells.Add(tcel8);
            DynamicControlsHolder.Controls.Add(table1);
        }

        DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
        DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
        DynamicControlsHolder.Controls.Add(new LiteralControl("<br />"));
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        Employee emp = ((Employee)Session["Employee"]);
        int emp_Id = Convert.ToInt32(FormItems.Rows[0]["Emp_Id"]);
        int incrementPercent = Convert.ToInt32(ddlIncrement.SelectedItem.ToString());
        EmployeeLogic.UpdateIncrement(incrementPercent, emp_Id);
        Emp_FormLogic.UpdateStatus(Convert.ToInt32(Request.QueryString["RID"]), "Completed");
        Response.Redirect("FinalReviewFormList.aspx");

    }
}