using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class Emp_Form_ReviewLogic
    {
        public static int Insert(Emp_Form_Review efr)
        {
            string query = "insert INTO  Emp_Form_Review Values( @Emp_Form_Item_Id, @Reviewer_Id, @Rating, @Remarks)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Item_Id", efr.Emp_Form_Item_Id));
            par.Add(new SqlParameter("@Reviewer_Id", efr.Reviewer_Id));

            par.Add(new SqlParameter("@Rating", efr.Rating));
            par.Add(new SqlParameter("@Remarks", efr.Remarks));

            return DBUtility.ModifyData(query, par);
        }

        public static int Update(Emp_Form_Review efr)
        {
            string query = "UPDATE Emp_Form_Review SET  Emp_Form_Item_Id=@Emp_Form_Item_Id, Reviewer_Id= @Reviewer_Id,Rating= @Rating,Remarks=@Remarks  WHERE Emp_Form_Review_Id = @Emp_Form_Review_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Item_Id", efr.Emp_Form_Item_Id));
            par.Add(new SqlParameter("@Reviewer_Id", efr.Reviewer_Id));
            par.Add(new SqlParameter("@Rating", efr.Rating));
            par.Add(new SqlParameter("@Remarks", efr.Remarks));


            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE Emp_Form_Review WHERE Emp_Form_Review_Id = @Emp_Form_Review_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Review_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Emp_Form_Review SelectByID(int ID)
        {
            string query = "SELECT * FROM Emp_Form_Review WHERE Emp_Form_Review_Id = @Emp_Form_Review_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Review_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Emp_Form_Review efr = new Emp_Form_Review();
                efr.Emp_Form_Review_Id = Convert.ToInt32(dt.Rows[0]["Emp_Form_Review_Id"]);
                efr.Emp_Form_Item_Id = Convert.ToInt32(dt.Rows[0]["Emp_Form_Item_Id"]);
                efr.Reviewer_Id = Convert.ToInt32(dt.Rows[0]["Reviewer_Id"]);
                efr.Rating = dt.Rows[0]["Rating"].ToString();
                efr.Remarks = dt.Rows[0]["Remarks"].ToString();

                return efr;
            }
            else
            {
                return new Emp_Form_Review();
            }
        }

        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM Emp_Form_Review";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }



    }
}