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
    public class BLLocation
    {
        public Location GetLocation(string ConnectionString)
        {
            var model = new Location();
            var _DLLocation = new DLLocation();
            var DSItems = new DataSet();
            try
            {
                DSItems = _DLLocation.GetLocation(ConnectionString);

                if (DSItems.Tables[0].Rows.Count > 0)
                {
                    var listItems = new List<Location>();

                    foreach (DataRow R in DSItems.Tables[0].Rows)
                    {
                        var Items = new Location();
                        Items._Location = R["locid"].ToString();
                        Items._LocationName = R["locationname"].ToString();

                        listItems.Add(Items);
                    }
                    model.GetLocation = listItems;
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

        public Location Reserve(string In_Location, string In_Date_From, string In_Date_To, string In_Adults, string In_Children, string ConnectionString)
        {
            var model = new Location();
            var _DLLocation = new DLLocation();
            var DSItems = new DataSet();
            bool flag;
            try
            {
                flag = _DLLocation.Reserve(In_Location, In_Date_From, In_Date_To,
                    In_Adults, In_Children, ConnectionString);

                if (DSItems.Tables[0].Rows.Count > 0)
                {
                    var listItems = new List<Location>();

                    foreach (DataRow R in DSItems.Tables[0].Rows)
                    {
                        var Items = new Location();
                        Items.ReqNo = flag;

                        listItems.Add(Items);
                    }
                    model.GetLocation = listItems;
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

            public Services SaveServiceRequest(string In_ServiceId, string In_UrgencyId, string In_Name,
                 string In_RoomNo, string In_Mobile, string ConnectionString)
        {
            var model = new Services();
            var _DLLocation = new DLLocation();
            var DSItems = new DataSet();
            
            try
            {
                DSItems = _DLLocation.SaveServiceRequest(In_ServiceId, In_UrgencyId, In_Name,
                    In_RoomNo, In_Mobile, ConnectionString);

                if (DSItems.Tables[0].Rows.Count > 0)
                {
                    var listItems = new List<Services>();

                    foreach (DataRow R in DSItems.Tables[0].Rows)
                    {
                        var Items = new Services();
                        Items._Service = DSItems.Tables[0].Rows[0][0].ToString();

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
    }
}

