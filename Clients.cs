using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{
    class Clients
    {
        private int _Id_cl;
        private string _cod_prod;
        private string _name;
        private string _address;
        private string _phone;
        public Clients(int i, string c, string n, string a, string p)
        {
            _Id_cl = i;
            _cod_prod = c;
            _name = n;
            _address = a;
            _phone = p;
        }
        public int Id_cl
        {
            get
            {
                return _Id_cl;
            }
        }
        public string cod_prod
        {
            get
            {
                return _cod_prod;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
        }
        public string address
        {
            get
            {
                return _address;
            }
        }
        public string phone
        {
            get
            {
                return _phone;
            }
        }
    }
}
