using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DLCustomer
    {
        SqlTransaction objTrans = null;

        public string Register(string In_Email, string In_Password, string ConnectionString)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("Pro_Cus_Register", objConn);

                //SqlCommand objCmd1 = new SqlCommand("insert into Customer(CusEmail, CusPassword) values('"+ In_Email + "','"+ In_Password + "')", objConn);
                try
                {
                    objCmd1.Transaction = objTrans;
                    objCmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    objCmd1.Parameters.Add(new SqlParameter("@In_Email", In_Email));
                    objCmd1.Parameters.Add(new SqlParameter("@In_Password", In_Password));
                    objCmd1.ExecuteNonQuery();
                    objTrans.Commit();
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }

                return "regno";
            }
        }
    }
}
