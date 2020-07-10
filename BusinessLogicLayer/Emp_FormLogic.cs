using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    
    public class Emp_FormLogic
    {
        public static int Insert(Emp_Form ef)
        {
            string query = "insert INTO Emp_Form Values( @Emp_Id,@App_Form_Id,@Form_Date,@Status,@Assigned_Id)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", ef.Emp_Id));
            par.Add(new SqlParameter("@App_Form_Id", ef.App_Form_Id));
            par.Add(new SqlParameter("@Form_Date", ef.Form_Date));
            par.Add(new SqlParameter("@Status", ef.Status));
            par.Add(new SqlParameter("@Assigned_Id",ef.Assigned_Id));


            return DBUtility.ModifyData(query, par);
        }

        public static int Update(Emp_Form ef)
        {
            string query = "UPDATE Emp_Form SET  Emp_Id= @Emp_Id,App_Form_Id=@App_Form_Id,Form_Date=@Form_Date,Status=@Status ,Assigned_Id=@Assigned_Id WHERE Emp_Form_Id = @Emp_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", ef.Emp_Form_Id));
            par.Add(new SqlParameter("@Emp_Id", ef.Emp_Id));
            par.Add(new SqlParameter("@App_Form_Id", ef.App_Form_Id));
            par.Add(new SqlParameter("@Form_Date", ef.Form_Date));
            par.Add(new SqlParameter("@Status", ef.Status));
            par.Add(new SqlParameter("@Assigned_Id", ef.Assigned_Id));
            
            return DBUtility.ModifyData(query, par);
        }

        public static int UpdateStatus(int id, string status)
        {
            string query = "UPDATE Emp_Form SET  Status=@Status WHERE Emp_Form_Id = @Emp_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", id));
            par.Add(new SqlParameter("@Status", status));
            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE Emp_Form WHERE Emp_Form_Id = @Emp_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Emp_Form SelectByID(int ID)
        {
            string query = "SELECT * FROM Emp_Form WHERE Emp_form_Id = @Emp_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Emp_Form ef = new Emp_Form();

                ef.Emp_Form_Id = Convert.ToInt32(dt.Rows[0]["Emp_Form_Id"]);
                ef.Emp_Id =Convert.ToInt32(dt.Rows[0]["Emp_Id"]);
                ef.App_Form_Id =Convert.ToInt32 (dt.Rows[0]["App_Form_Id"]);
                ef.Form_Date=Convert.ToDateTime (dt.Rows[0]["Form_Date"]);
                ef.Status = dt.Rows[0]["Status"].ToString();
                ef.Assigned_Id = Convert.ToInt32(dt.Rows[0]["Assigned_Id"]);

                return ef;
            }
            else
            {
                return new Emp_Form();
            }
        }

        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM Emp_Form";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }

        public static DataTable SelectByEmpId(int ID)
        {
            string query = "SELECT * FROM Emp_Form WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", ID));
            return DBUtility.SelectData(query, par);

        }

        public static DataTable SelectByAssignedId(int Id)
        {
            string query = " SELECT        Employee.Name, Department.Dept_Name, Appraisal_Form.AppraisalCycle, Emp_Form.Emp_Form_Id " +
                         " FROM            Appraisal_Form INNER JOIN " +
                         " Emp_Form ON Appraisal_Form.App_Form_Id = Emp_Form.App_Form_Id INNER JOIN " +
                         " Employee ON Emp_Form.Emp_Id = Employee.Emp_Id INNER JOIN " +
                         " Department ON Appraisal_Form.Dept_Id = Department.Dept_Id " +
                         " WHERE        (Emp_Form.Assigned_Id = @Assigned_Id) AND (Emp_Form.Status = @Status)";
            
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Assigned_Id", Id));
            par.Add(new SqlParameter("@Status", "Submitted"));
            return DBUtility.SelectData(query, par);           
            
       }


        public static DataTable SelectByAssignedIdForFinalReiview(int Id)
        {
            string query = " SELECT        Employee.Name, Department.Dept_Name, Appraisal_Form.AppraisalCycle, Emp_Form.Emp_Form_Id " +
                         " FROM            Appraisal_Form INNER JOIN " +
                         " Emp_Form ON Appraisal_Form.App_Form_Id = Emp_Form.App_Form_Id INNER JOIN " +
                         " Employee ON Emp_Form.Emp_Id = Employee.Emp_Id INNER JOIN " +
                         " Department ON Appraisal_Form.Dept_Id = Department.Dept_Id " +
                         " WHERE        (Emp_Form.Status = @Status)";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Status", "Reviewed"));
            return DBUtility.SelectData(query, par);

        }

    }
}