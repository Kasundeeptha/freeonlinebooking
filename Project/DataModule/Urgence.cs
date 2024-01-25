using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public class Urgence
    {
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private string _urgenceid;

        public string _Urgence
        {
            get { return _urgenceid; }
            set { _urgenceid = value; }
        }

        private string _urgenceName;

        public string _UrgenceName
        {
            get { return _urgenceName; }
            set { _urgenceName = value; }
        }

        private List<Urgence> _getUrgence;
        public List<Urgence> GetUrgence
        {
            get { return _getUrgence; }
            set { _getUrgence = value; }
        }
    }
}
