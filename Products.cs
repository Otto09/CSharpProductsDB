using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{
    class Products
    {
        private string _cod_prod;
        private string _name;
        private int _price;
        private string _availability;
        private string _best_seller;
        public Products(string c, string n, int p, string a, string b)
        {
            _cod_prod = c;
            _name = n;
            _price = p;
            _availability = a;
            _best_seller = b;
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
        public int price
        {
            get
            {
                return _price;
            }
        }
        public string availability
        {
            get
            {
                return _availability;
            }
        }
        public string best_seller
        {
            get
            {
                return _best_seller;
            }
        }
    }
}
