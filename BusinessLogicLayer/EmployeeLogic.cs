using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{

    public class EmployeeLogic
    {
        public static int Insert(Employee e)
        {
            string query = "insert INTO Employee Values(@Name,@Email, @Phone, @U_name, @Password, @Dept_Id, @Sup_Id, @DOB, @DOJ, @Salary,@IsActive,@Photo,@AppraisalCycle,@IsAdmin)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Name", e.Name));
            par.Add(new SqlParameter("@Email", e.Email));
            par.Add(new SqlParameter("@Phone", e.Phone));
            par.Add(new SqlParameter("@U_Name", e.U_Name));
            par.Add(new SqlParameter("@Password", e.Password));
            par.Add(new SqlParameter("@Dept_Id", e.Dept_Id));
            par.Add(new SqlParameter("@Sup_Id", e.Sup_Id));
            par.Add(new SqlParameter("@DOB", e.DOB));
            par.Add(new SqlParameter("@DOJ", e.DOJ));
            par.Add(new SqlParameter("@Salary", e.Salary));
            par.Add(new SqlParameter("@Photo", e.Photo));
            par.Add(new SqlParameter("@IsActive", e.IsActive));
            par.Add(new SqlParameter("@AppraisalCycle", e.AppraisalCycle));
            par.Add(new SqlParameter("@IsAdmin", e.IsAdmin));



            return DBUtility.ModifyData(query, par);
        }

        public static int Update(Employee e)
        {
            string query = "UPDATE Employee SET Name= @Name,Email= @Email,Phone= @Phone,U_Name= @U_Name,Password= @Password,Dept_Id= @Dept_Id,Sup_Id= @Sup_Id,DOB= @DOB,DOJ= @DOJ,Salary= @Salary,Photo= @Photo,IsActive= @IsActive,AppraisalCycle=@AppraisalCycle ,IsAdmin=@IsAdmin WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", e.Emp_Id));
            par.Add(new SqlParameter("@Name", e.Name));
            par.Add(new SqlParameter("@Email", e.Email));
            par.Add(new SqlParameter("@Phone", e.Phone));
            par.Add(new SqlParameter("@U_Name", e.U_Name));
            par.Add(new SqlParameter("@Password", e.Password));
            par.Add(new SqlParameter("@Dept_Id", e.Dept_Id));
            par.Add(new SqlParameter("@Sup_Id", e.Sup_Id));
            par.Add(new SqlParameter("@DOB", e.DOB));
            par.Add(new SqlParameter("@DOJ", e.DOJ));
            par.Add(new SqlParameter("@Salary", e.Salary));
            par.Add(new SqlParameter("@Photo", e.Photo));
            par.Add(new SqlParameter("@IsActive", e.IsActive));
            par.Add(new SqlParameter("@AppraisalCycle", e.AppraisalCycle));
            par.Add(new SqlParameter("@IsAdmin", e.IsAdmin));

            return DBUtility.ModifyData(query, par);
        }

        public static int UpdateIncrement(int incrementPercent, int empId)
        {
            var employee = Select(empId);

            float salary = employee.Salary + (employee.Salary * incrementPercent) / 100;
            string query = "UPDATE Employee SET Salary= @Salary WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Salary", salary));
            par.Add(new SqlParameter("@Emp_Id", empId));

            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE Employee WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Employee SelectByID(int ID)
        {
            string query = "SELECT * FROM Employee WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Employee e = new Employee();
                e.Emp_Id = Convert.ToInt32(dt.Rows[0]["Emp_Id"]);
                e.Name = dt.Rows[0]["Name"].ToString();
                e.Email = dt.Rows[0]["Email"].ToString();
                e.Phone = dt.Rows[0]["Phone"].ToString();
                e.U_Name = dt.Rows[0]["U_Name"].ToString();
                e.Password = dt.Rows[0]["Password"].ToString();
                e.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                e.Sup_Id = Convert.ToInt32(dt.Rows[0]["Sup_Id"]);
                e.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                e.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                e.Salary = Convert.ToSingle(dt.Rows[0]["Salary"]);
                e.Photo = dt.Rows[0]["Photo"].ToString();
                e.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                e.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                e.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);

                return e;
            }
            else
            {
                return new Employee();
            }
        }

        public static Employee Select(int ID)
        {
            string query = "SELECT * FROM Employee WHERE Emp_Id = @Emp_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Employee e = new Employee();
                e.Emp_Id = Convert.ToInt32(dt.Rows[0]["Emp_Id"]);
                e.Name = dt.Rows[0]["Name"].ToString();
                e.Email = dt.Rows[0]["Email"].ToString();
                e.Phone = dt.Rows[0]["Phone"].ToString();
                e.U_Name = dt.Rows[0]["U_Name"].ToString();
                e.Password = dt.Rows[0]["Password"].ToString();
                e.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                e.Sup_Id = Convert.ToInt32(dt.Rows[0]["Sup_Id"]);
                e.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                e.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                e.Salary = Convert.ToSingle(dt.Rows[0]["Salary"]);
                e.Photo = dt.Rows[0]["Photo"].ToString();
                e.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                e.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                e.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);

                return e;
            }
            else
            {
                return new Employee();
            }
        }

        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM Employee";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }
        public static DataTable Search(string name)
        {
            string query = @"SELECT E.*, D.Dept_Name, S.Name as 'SName'
                                FROM Employee AS E
                                left  join Department as D on D.Dept_Id = E.Dept_Id
                                left join Employee as S on S.Emp_Id = E.Sup_Id

                                where E.Name like @Name+'%'";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Name", name));
            return DBUtility.SelectData(query, par);
        }
        public static Employee Validate(string U_Name, string Password)
        {
            string query = @"SELECT * FROM Employee WHERE U_Name = @U_Name AND Password = @Password";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@U_Name", U_Name));
            par.Add(new SqlParameter("@Password", Password));

            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Employee e = new Employee();
                e.Emp_Id = Convert.ToInt32(dt.Rows[0]["Emp_Id"]);
                e.Name = dt.Rows[0]["Name"].ToString();
                e.Email = dt.Rows[0]["Email"].ToString();
                e.Phone = dt.Rows[0]["Phone"].ToString();
                e.U_Name = dt.Rows[0]["U_Name"].ToString();
                e.Password = dt.Rows[0]["Password"].ToString();
                e.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                e.Sup_Id = Convert.ToInt32(dt.Rows[0]["Sup_Id"]);
                e.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                e.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                e.Salary = Convert.ToSingle(dt.Rows[0]["Salary"]);
                e.Photo = dt.Rows[0]["Photo"].ToString();
                e.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                e.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                e.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                return e;
            }
            else
            {
                return new Employee();
            }
        }

        public static Employee SelectByUserName(string U_Name)
        {
            string query = @"SELECT * FROM Employee WHERE U_Name = @U_Name";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@U_Name", U_Name));


            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Employee e = new Employee();
                e.Emp_Id = Convert.ToInt32(dt.Rows[0]["Emp_Id"]);
                e.Name = dt.Rows[0]["Name"].ToString();
                e.Email = dt.Rows[0]["Email"].ToString();
                e.Phone = dt.Rows[0]["Phone"].ToString();
                e.U_Name = dt.Rows[0]["U_Name"].ToString();
                e.Password = dt.Rows[0]["Password"].ToString();
                e.Dept_Id = Convert.ToInt32(dt.Rows[0]["Dept_Id"]);
                e.Sup_Id = Convert.ToInt32(dt.Rows[0]["Sup_Id"]);
                e.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                e.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                e.Salary = Convert.ToSingle(dt.Rows[0]["Salary"]);
                e.Photo = dt.Rows[0]["Photo"].ToString();
                e.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                e.AppraisalCycle = dt.Rows[0]["AppraisalCycle"].ToString();
                e.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                return e;
            }
            else
            {
                return new Employee();
            }
        }
        public static DataTable SelectByDepartment(int Dept_Id, string AppraisalCycle)
        {
            string query = @"SELECT E.* 
                                FROM Employee AS E
                              WHERE Dept_Id=@Dept_Id AND AppraisalCycle=@AppraisalCycle";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@AppraisalCycle", AppraisalCycle));
            par.Add(new SqlParameter("@Dept_Id", Dept_Id));
            return DBUtility.SelectData(query, par);
        }
    }
}