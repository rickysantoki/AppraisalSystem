using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    
    public class Emp_Form_ItemLogic
    {
        public static int Insert(Emp_Form_Item efi)
        {
            string query = "insert INTO  Emp_Form_Item Values( @Emp_Form_Id, @App_Form_Item_Id, @Answer)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", efi.Emp_Form_Id));
            par.Add(new SqlParameter("@App_Form_Item_Id", efi.App_Form_Item_Id));
           
            par.Add(new SqlParameter("@Answer", efi.Answer));

            return DBUtility.ModifyData(query, par);
        }

        public static int Update(Emp_Form_Item efi)
        {
            string query = "UPDATE Emp_Form_Item SET  Emp_Form_Id=@Emp_Form_Id, App_Form_Item_Id= @App_Form_Item,Answer= @Answer  WHERE Emp_Form_Item_Id = @Emp_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Item_Id", efi.Emp_Form_Item_Id));
            par.Add(new SqlParameter("@Emp_Form_Id", efi.Emp_Form_Id));
            par.Add(new SqlParameter("@App_Form_Item_Id", efi.App_Form_Item_Id));
            par.Add(new SqlParameter("@Answer", efi.Answer));


            return DBUtility.ModifyData(query, par);
        }

        public static int Delete(int ID)
        {
            string query = "DELETE Emp_Form_Item WHERE Emp_Form_Item_Id = @Emp_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Item_Id", ID));

            return DBUtility.ModifyData(query, par);
        }

        public static Emp_Form_Item SelectByID(int ID)
        {
            string query = "SELECT * FROM Emp_Form_Item WHERE Emp_Form_Item_Id = @Emp_Form_Item_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Item_Id", ID));
            DataTable dt = DBUtility.SelectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Emp_Form_Item efi = new Emp_Form_Item();
                efi.Emp_Form_Item_Id = Convert.ToInt32(dt.Rows[0]["Emp_Form_Item_Id"]);
                efi.Emp_Form_Id = Convert.ToInt32(dt.Rows[0]["Emp_Form_Id"]);
                efi.App_Form_Item_Id = Convert.ToInt32(dt.Rows[0]["App_Form_Item_Id"]);
                efi.Answer = dt.Rows[0]["Answer"].ToString();

                return efi;
            }
            else
            {
                return new Emp_Form_Item();
            }
        }

      

        public static DataTable SelectAll()
        {
            string query = "SELECT * FROM Emp_Form_Item";
            List<SqlParameter> par = new List<SqlParameter>();
            return DBUtility.SelectData(query, par);
        }


        public static DataTable SelectByEmpFormId(int ID)
        {
            string query = "SELECT FormItem.*, appFormItem.Title AS Title, appFormItem.Description AS Description FROM Emp_Form_Item AS FormItem " +
                "INNER JOIN App_Form_Items AS appFormItem ON FormItem.App_Form_Item_Id = appFormItem.App_Form_Item_Id " +
                "WHERE Emp_Form_Id = @Emp_Form_Id";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", ID));
            return DBUtility.SelectData(query, par);

        }


        public static DataTable SelectByEmpFormIdForReview(int Id)
        {
            string query = "SELECT        Emp_Form_Item.Emp_Form_Item_Id, App_Form_Items.App_Form_Item_Id, App_Form_Items.App_Form_Id, App_Form_Items.Title, App_Form_Items.Description, Emp_Form_Item.Answer " +
                            "FROM            App_Form_Items INNER JOIN " +
                            " Emp_Form_Item ON App_Form_Items.App_Form_Item_Id = Emp_Form_Item.App_Form_Item_Id INNER JOIN " +
                           " Emp_Form ON Emp_Form.Emp_Form_Id = Emp_Form_Item.Emp_Form_Id " +
                            " WHERE        (Emp_Form_Item.Emp_Form_Id = @Emp_Form_Id) AND (Emp_Form.Status = @Status) ";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", Id));
            par.Add(new SqlParameter("@Status", "Submitted"));
            return DBUtility.SelectData(query, par);
        }

        public static DataTable SelectByEmpFormIdForFinalReview(int Id)
        {
            string query = "SELECT        Employee.Emp_Id, App_Form_Items.Title, App_Form_Items.Description, Emp_Form_Item.Answer, Emp_Form_Item.Emp_Form_Item_Id ,Emp_Form_Review.Rating, Emp_Form_Review.Remarks " +
                            "FROM            Employee INNER JOIN " +
                         " Emp_Form ON Employee.Emp_Id = Emp_Form.Emp_Id INNER JOIN " +
                          " Emp_Form_Item ON Emp_Form.Emp_Form_Id = Emp_Form_Item.Emp_Form_Id INNER JOIN " +
                         " App_Form_Items ON Emp_Form_Item.App_Form_Item_Id = App_Form_Items.App_Form_Item_Id INNER JOIN  " +
                         " Emp_Form_Review ON Emp_Form_Item.Emp_Form_Item_Id = Emp_Form_Review.Emp_Form_Item_Id " +
                        " WHERE        (Emp_Form.Emp_Form_Id = @Emp_Form_Id)	 ";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Emp_Form_Id", Id));
                        return DBUtility.SelectData(query, par);
        }

    }
}