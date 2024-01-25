using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public class Location
    {
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private string _location;

        public string _Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _locationName;

        public string _LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        private bool _ReqNo;

        public bool ReqNo
        {
            get { return _ReqNo; }
            set { _ReqNo = value; }
        }

        private List<Location> _getLocation;
        public List<Location> GetLocation
        {
            get { return _getLocation; }
            set { _getLocation = value; }
        }
    }
}
