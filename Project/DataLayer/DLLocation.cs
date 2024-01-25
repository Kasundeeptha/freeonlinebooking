using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class DLLocation
    {
        SqlTransaction objTrans = null;
        public DataSet GetLocation(string ConnectionString)
        {

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                //objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("Pro_Get_Location", objConn);
                var _dataSet = new DataSet();


                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(objCmd1))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(_dataSet);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    //objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }

                return _dataSet;
            }
        }

        public DataSet GetServices(string ConnectionString)
        {

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                //objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("Svs_Get_Services", objConn);
                var _dataSet = new DataSet();


                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(objCmd1))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(_dataSet);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    //objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }

                return _dataSet;
            }
        }

        public DataSet GetUrgence(string ConnectionString)
        {

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                //objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("Svs_Get_Urgence", objConn);
                var _dataSet = new DataSet();


                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(objCmd1))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(_dataSet);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    //objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }

                return _dataSet;
            }
        }

        public bool Reserve(string In_Location, string In_Date_From, string In_Date_To, string In_Adults, string In_Children, string ConnectionString)
        {
            bool flag = false;
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("Pro_Cus_People_Count", objConn);
                var _dataSet = new DataSet();
                objCmd1.CommandType = CommandType.StoredProcedure;
                objCmd1.Parameters.Add(new SqlParameter("@In_LocId", In_Location));
                objCmd1.Parameters.Add(new SqlParameter("@In_FromDate", In_Date_From));
                objCmd1.Parameters.Add(new SqlParameter("@In_ToDate", In_Date_To));
                objCmd1.Transaction = objTrans;


                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(objCmd1))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(_dataSet);
                        objTrans.Commit();
                    }
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

                if (Convert.ToInt32(_dataSet.Tables[0].Rows[0]["remadults"]) > Convert.ToInt32(In_Adults)
                            && Convert.ToInt32(_dataSet.Tables[0].Rows[0]["remchildren"]) > Convert.ToInt32(In_Children))
                {
                    flag = true;
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    SqlCommand objCmd2 = new SqlCommand("Pro_Cus_People_Insert", objConn);
                    var _dataSet2 = new DataSet();
                    objCmd2.CommandType = CommandType.StoredProcedure;
                    objCmd2.Parameters.Add(new SqlParameter("@In_LocId", In_Location));
                    objCmd2.Parameters.Add(new SqlParameter("@In_FromDate", In_Date_From));
                    objCmd2.Parameters.Add(new SqlParameter("@In_ToDate", In_Date_To));
                    objCmd2.Parameters.Add(new SqlParameter("@In_NumAdult", In_Adults));
                    objCmd2.Parameters.Add(new SqlParameter("@In_NumChild", In_Children));
                    objCmd2.Transaction = objTrans;

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(objCmd2))
                        {
                            da.SelectCommand.CommandTimeout = 120;
                            da.Fill(_dataSet2);
                            objTrans.Commit();
                        }
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
                }


            }
            return flag;
        }

        public DataSet SaveServiceRequest(string In_ServiceId, string In_UrgencyId, string In_Name,
             string In_RoomNo, string In_Mobile, string ConnectionString)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                objTrans = objConn.BeginTransaction();
                SqlCommand objCmd1 = new SqlCommand("svs_save_request", objConn);
                var _dataSet = new DataSet();
                objCmd1.CommandType = CommandType.StoredProcedure;
                objCmd1.Parameters.Add(new SqlParameter("@In_ServiceId", In_ServiceId));
                objCmd1.Parameters.Add(new SqlParameter("@In_UrgencyId", In_UrgencyId));
                objCmd1.Parameters.Add(new SqlParameter("@In_Name", In_Name));
                objCmd1.Parameters.Add(new SqlParameter("@In_RoomNo", In_RoomNo));
                objCmd1.Parameters.Add(new SqlParameter("@In_Mobile", In_Mobile));
                objCmd1.Transaction = objTrans;


                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(objCmd1))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(_dataSet);
                        objTrans.Commit();
                    }
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

                return _dataSet;
            }
        }
    }
}
