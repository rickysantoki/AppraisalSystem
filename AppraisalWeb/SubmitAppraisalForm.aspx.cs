using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class SubmitAppraisalForm : System.Web.UI.Page
{
    private DataTable FormItems;
    protected void Page_Load(object sender, EventArgs e)
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

        DataTable appraisalFormItemTable;
        appraisalFormItemTable = Emp_FormLogic.SelectByEmpId(employee.Emp_Id);
        bool isFormSubmitted = false;
        if (appraisalFormItemTable == null || appraisalFormItemTable.Rows.Count <= 0)
        {
            FormItems = GetData();
        }
        else
        {
            var empFormId = Convert.ToInt32(appraisalFormItemTable.Rows[0]["Emp_Form_Id"]);
            FormItems = Emp_Form_ItemLogic.SelectByEmpFormId(empFormId);
            isFormSubmitted = true;
            btnApply.Visible = false;
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
            label.ID = "lbl" + que["App_Form_Item_Id"].ToString();
            label.Text = que["Title"].ToString();
            TableCell tCell = new TableCell();
            tCell.Width = 200;
            tCell.Controls.Add(label);
            tCell.ColumnSpan = 1;
            tRow.Cells.Add(tCell);


            var textBox1 = new TextBox();
            textBox1.ID = "txtDesc" + que["App_Form_Item_Id"].ToString();
            textBox1.AutoPostBack = true;
            textBox1.TextMode = TextBoxMode.MultiLine;
            textBox1.Width = 450;
            textBox1.Text = que["Description"].ToString();
            textBox1.Enabled = false;
            TableCell tcel3 = new TableCell();
            tcel3.Width = 300;
            tcel3.Controls.Add(textBox1);
            tcel3.ColumnSpan = 1;
            tRow.Cells.Add(tcel3);

            TableRow tRow2 = new TableRow();
            table1.Rows.Add(tRow2);

            var label1 = new Label();
            label1.ID = "lblAnswer" + que["App_Form_Item_Id"].ToString();
            label1.Text = "Answer";
            TableCell tCel5 = new TableCell();
            tCel5.Width = 200;
            tCel5.Controls.Add(label1);
            tCel5.ColumnSpan = 1;
            tRow2.Cells.Add(tCel5);

            var textBox = new TextBox();
            textBox.ID = "txt" + que["App_Form_Item_Id"].ToString();
            textBox.AutoPostBack = true;
            textBox.TextMode = TextBoxMode.MultiLine;
            textBox.Width = 450;
            if (isFormSubmitted)
            {
                textBox.Text = que["Answer"].ToString();
            }
            textBox.Enabled = isFormSubmitted ? false : true;
            TableCell tcel2 = new TableCell();
            tcel2.Width = 300;
            tcel2.Controls.Add(textBox);
            tcel2.ColumnSpan = 1;
            tRow2.Cells.Add(tcel2);


            DynamicControlsHolder.Controls.Add(table1);

        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        Employee emp = ((Employee)Session["Employee"]);
        Emp_Form empForm = new Emp_Form() { App_Form_Id = Convert.ToInt32(FormItems.Rows[0]["App_Form_Id"]), Assigned_Id = emp.Sup_Id, Emp_Id = emp.Emp_Id, Status = "Submitted", Form_Date = DateTime.Now };
        var x = Emp_FormLogic.Insert(empForm);
        var empFormTable = Emp_FormLogic.SelectByEmpId(emp.Emp_Id);
        int empFormId = 0;
        if (empFormTable != null || empFormTable.Rows.Count > 0)
        {
            empFormId = Convert.ToInt32(empFormTable.Rows[0]["Emp_Form_Id"]);
        }

        foreach (DataRow que in FormItems.Rows)
        {
            TextBox txtbox = DynamicControlsHolder.FindControl("txt" + que["App_Form_Item_Id"].ToString()) as TextBox;
            Emp_Form_Item empFormItem = new Emp_Form_Item() { App_Form_Item_Id = Convert.ToInt32(que["App_Form_Item_Id"]), Emp_Form_Id = empFormId, Answer = txtbox.Text };
            Emp_Form_ItemLogic.Insert(empFormItem);

        }
        Response.Redirect("SubmitAppraisalForm.aspx");

    }

}