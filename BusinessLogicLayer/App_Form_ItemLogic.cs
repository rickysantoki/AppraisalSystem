using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    
    public class App_Form_ItemLogic
    {
        public static int Insert(App_Form_Items afi)
        {
            string query = "insert INTO App_Form_Items Values( @App_Form_Id, @Title, @Description)";
            List<SqlParameter> par = new List<SqlParameter>();
           
            par.Add(new SqlParameter("@App_Form_Id", afi.App_Form_Id));
            par.Add(new SqlParameter("@Title", afi.Title));
            par.Add(new SqlParameter("@Description", afi.Description));

            return DBUtility.ModifyData(query, par);
        }

        public static int Update(App_Form_Items afi)
        {
            string query = "UPDATE App_Form_Items SET  Title= @Title,Description= @Description  WHERE App_Form_Item_Id = @App_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Item_Id", afi.App_Form_Item_Id));
            par.Add(new SqlParameter("@App_Form_Id", afi.App_Form_Id));
            par.Add(new SqlParameter("@Title", afi.Title));
            par.Add(new SqlParameter("@Description", afi.Description));
            
            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE App_Form_Items WHERE App_Form_Item_Id = @App_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Item_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static App_Form_Items SelectByID(int ID)
        {
            string query = "SELECT * FROM App_Form_Items WHERE App_Form_Item_Id = @App_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Item_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                App_Form_Items afi = new App_Form_Items();
                afi.App_Form_Item_Id = Convert.ToInt32(dt.Rows[0]["App_Form_Item_Id"]);
                afi.App_Form_Id = Convert.ToInt32(dt.Rows[0]["App_Form_Id"]);
                afi.Title = dt.Rows[0]["Title"].ToString();
                afi.Description = dt.Rows[0]["Description"].ToString();
                
                return afi;
            }
            else
            {
                return new App_Form_Items();
            }
        }

        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM App_Form_Item";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }

        public static DataTable SelectByAppraisalFormID(int App_Form_Id)
        {
            string query = "SELECT * FROM App_Form_Items WHERE App_Form_Id = @App_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@App_Form_Id", App_Form_Id));
            return DBUtility.SelectData(query, par);

        }

        public static DataTable SelectByEmpID(int Emp_Id)
        {
            string query = "SELECT        questions.App_Form_Item_Id, questions.App_Form_Id, questions.Title, questions.Description " + 
                            "FROM            App_Form_Items AS questions INNER JOIN " +
                                            "Appraisal_Form AS Form ON Form.App_Form_Id = questions.App_Form_Id INNER JOIN " +
                                            "Employee AS emp ON emp.Dept_Id = Form.Dept_Id " +
                            "WHERE        (emp.Emp_Id = @Emp_Id)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Id", Emp_Id));
            return DBUtility.SelectData(query, par);

        }

        
        
    }
}