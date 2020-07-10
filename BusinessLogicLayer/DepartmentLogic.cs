using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Summary description for UserDetailLogic
    /// </summary>
    public class DepartmentLogic
    {
        public static int Insert(Department d)
        {
            string query = "INSERT INTO Department Values(@Dept_Name,@Dept_Head_Id)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Name", d.Dept_Name));
            par.Add(new SqlParameter("@Dept_Head_Id", d.Dept_Head_Id));

            return DBUtility.ModifyData(query, par);
        }

        public static int Update(Department d)
        {
            string query = "UPDATE Department SET  Dept_Name= @Dept_Name,Dept_Head_Id=@Dept_Head_Id  WHERE Dept_Id = @Dept_Id";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Dept_Id", d.Dept_Id));
            par.Add(new SqlParameter("@Dept_Name", d.Dept_Name));
            par.Add(new SqlParameter("@Dept_Head_Id", d.Dept_Head_Id));

            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE Department WHERE Dept_Id = @Dept_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Department SelectByID(int ID)
        {
            string query = "SELECT * FROM Department WHERE Dept_Id = @Dept_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Department d = new Department();
                d.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                d.Dept_Name = dt.Rows[0]["Dept_Name"].ToString();
                d.Dept_Head_Id = Convert.ToInt32(dt.Rows[0]["Dept_Head_Id"]);
                return d;
            }
            else
            {
                return new Department();
            }
        }

        public static Department SelectByName(string name)
        {
            string query = "SELECT * FROM Department WHERE Dept_Name = @Dept_Name";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Dept_Name", name));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Department d = new Department();
                d.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                d.Dept_Name = dt.Rows[0]["Dept_Name"].ToString();
                d.Dept_Head_Id = Convert.ToInt32(dt.Rows[0]["Dept_Head_Id"]);
                return d;
            }
            else
            {
                return new Department();
            }
        }

        
        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM Department";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }

        public static DataTable GetDetail()
        {
            String query = @"SELECT Department.Dept_Id,Department.Dept_Name, Employee.Name FROM Department LEFT OUTER JOIN Employee ON Department.Dept_Head_Id = Employee.Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }

    }
}