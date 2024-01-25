using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModule;
using System.Data;
using DataLayer;

namespace BusinessLogic
{
    public class BLCustomer
    {
        public Customer Register(string In_Email, string In_Password, string ConnectionString)
        {
            var model = new Customer();
            DataSet mDataSet = new DataSet();
            try
            {
                DLCustomer objDLCustomer = new DLCustomer();
                objDLCustomer.Register(In_Email, In_Password, ConnectionString);             
            }
            catch (Exception ex)
            {
                model.Error = "Error with " + ex.Message;
            }

            return model;
        }

        

    }
}
