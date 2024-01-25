using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public class Customer
    {
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private List<Customer> _getCustomer;
        public List<Customer> GetCustomer
        {
            get { return _getCustomer; }
            set { _getCustomer = value; }
        }
    }
}
