using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public class Services
    {
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private string _serviceid;

        public string _Service
        {
            get { return _serviceid; }
            set { _serviceid = value; }
        }

        private string _serviceName;

        public string _ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        private List<Services> _getServices;
        public List<Services> GetServices
        {
            get { return _getServices; }
            set { _getServices = value; }
        }
    }
}
