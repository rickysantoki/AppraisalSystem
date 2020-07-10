using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{

    public class Appraisal_FormLogic
    {
        public static int Insert(Appraisal_Form af)
        {
            string query = "insert INTO Appraisal_Form Values( @Dept_Id,@Start_Date, @End_Date,@AppraisalCycle); SELECT @@IDENTITY;";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Id", af.Dept_Id));
            par.Add(new SqlParameter("@Start_Date", af.Start_Date));
            par.Add(new SqlParameter("@End_Date", af.End_Date));
            par.Add(new SqlParameter("@AppraisalCycle", af.AppraisalCycle));

            DataTable dt = DBUtility.SelectData(query, par);
            if (dt.Rows.Count == 1 && dt.Rows[0][0] != null)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        public static int Update(Appraisal_Form af)
        {
            string query = "UPDATE Appraisal_Form SET  Dept_Id= @Dept_Id,Start_Date= @Start_Date,End_Date=@End_Date ,AppraisalCycle=@AppraisalCycle WHERE App_Form_Id = @App_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@App_Form_Id", af.App_Form_Id));
            par.Add(new SqlParameter("@Dept_Id", af.Dept_Id));
            par.Add(new SqlParameter("@Start_Date", af.Start_Date));
            par.Add(new SqlParameter("@End_Date", af.End_Date));
            par.Add(new SqlParameter("@AppraisalCycle", af.AppraisalCycle));
            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE App_Form_Items WHERE App_Form_Id = @App_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Appraisal_Form SelectByID(int ID)
        {
            string query = "SELECT * FROM Appraisal_Form WHERE App_Form_Id = @App_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Appraisal_Form af = new Appraisal_Form();

                af.App_Form_Id = Convert.ToInt32(dt.Rows[0]["App_Form_Id"]);
                af.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                af.Start_Date = Convert.ToDateTime(dt.Rows[0]["Start_Date"]);
                af.End_Date = Convert.ToDateTime(dt.Rows[0]["End_Date"]);
                af.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                return af;
            }
            else
            {
                return new Appraisal_Form();
            }
        }


        public static Appraisal_Form SelectByDepartmentID(int ID)
        {
            string query = "SELECT * FROM Appraisal_Form WHERE Dept_Id = @Dept_Id AND @Now BETWEEN Start_Date AND End_Date";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Id", ID));
            par.Add(new SqlParameter("@Now", DateTime.Now));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Appraisal_Form af = new Appraisal_Form();

                af.App_Form_Id = Convert.ToInt32(dt.Rows[0]["App_Form_Id"]);
                af.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                af.Start_Date = Convert.ToDateTime(dt.Rows[0]["Start_Date"]);
                af.End_Date = Convert.ToDateTime(dt.Rows[0]["End_Date"]);
                af.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                return af;
            }
            else
            {
                return new Appraisal_Form();
            }
        }

        public static DataTable SelectAll()
        {
            string query = "SELECT Dept.Dept_Name AS DepartmentName, AppraisalForm.* FROM Appraisal_Form AS AppraisalForm INNER JOIN Department AS Dept ON Dept.Dept_Id = AppraisalForm.Dept_Id ";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }

        public static DataTable SelectStatusReportByDepartmntID(int DepartmntID)
        {
            string query = @"SELECT DISTINCT E.*, D.Dept_Name, S.Name as 'SName', CASE WHEN EF.Emp_Form_ID IS NULL THEN 'NOT SUBMITTED' ELSE ( CASE WHEN EFR.Emp_Form_Review_ID IS NULL THEN 'SUBMITTED' ELSE 'REVIEWED' END) END AS 'STATUS'
                                FROM Employee E
                                    left  join Department as D on D.Dept_Id = E.Dept_Id
                                    left join Employee as S on S.Emp_Id = E.Sup_Id
                                    LEFT JOIN Emp_Form EF ON E.Emp_ID = EF.Emp_ID
                                    LEFT JOIN Emp_Form_Item EFI ON EF.Emp_Form_ID = EFI.Emp_Form_ID
                                    LEFT JOIN Emp_Form_Review EFR ON EFI.Emp_Form_Item_ID = EFR.Emp_Form_Item_ID
                                    LEFT JOIN Appraisal_Form AF ON EF.App_Form_ID = AF.App_Form_ID
                                WHERE E.Dept_ID = @Dept_Id AND @Now BETWEEN Start_Date AND End_Date";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Id", DepartmntID));
            par.Add(new SqlParameter("@Now", DateTime.Now));
            return DBUtility.SelectData(query, par);

        }



    }
}