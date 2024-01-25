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
    public class BLLServices
    {
        public Services GetServices(string ConnectionString)
        {
            var model = new Services();
            var _DLLocation = new DLLocation();
            var DSItems = new DataSet();
            try
            {
                DSItems = _DLLocation.GetServices(ConnectionString);

                if (DSItems.Tables[0].Rows.Count > 0)
                {
                    var listItems = new List<Services>();

                    foreach (DataRow R in DSItems.Tables[0].Rows)
                    {
                        var Items = new Services();
                        Items._Service = R["serviceid"].ToString();
                        Items._ServiceName = R["servicename"].ToString();

                        listItems.Add(Items);
                    }
                    model.GetServices = listItems;
                }
                else
                {
                    model.Error = "NO DATA FOUND";
                }
            }
            catch (Exception ex)
            {
                model.Error = "NO DATA FOUND";
            }
            return model;
        }

        public Urgence GetUrgence(string ConnectionString)
        {
            var model = new Urgence();
            var _DLLocation = new DLLocation();
            var DSItems = new DataSet();
            try
            {
                DSItems = _DLLocation.GetUrgence(ConnectionString);

                if (DSItems.Tables[0].Rows.Count > 0)
                {
                    var listItems = new List<Urgence>();

                    foreach (DataRow R in DSItems.Tables[0].Rows)
                    {
                        var Items = new Urgence();
                        Items._Urgence = R["urgence_id"].ToString();
                        Items._UrgenceName = R["urgence"].ToString();

                        listItems.Add(Items);
                    }
                    model.GetUrgence = listItems;
                }
                else
                {
                    model.Error = "NO DATA FOUND";
                }
            }
            catch (Exception ex)
            {
                model.Error = "NO DATA FOUND";
            }
            return model;
        }
    }
}
