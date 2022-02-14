using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{
    class Comments
    {
        private int _Id_cm;
        private int _Id_cl;
        private string _rating;
        private string _comment;
        public Comments(int icm, int icl, string r, string c)
        {
            _Id_cm = icm;
            _Id_cl = icl;
            _rating = r;
            _comment = c;
        }
        public int Id_cm
        {
            get
            {
                return _Id_cm;
            }
        }
        public int Id_cl
        {
            get
            {
                return _Id_cl;
            }
        }
        public string Rating
        {
            get
            {
                return _rating;
            }
        }
        public string Comment
        {
            get
            {
                return _comment;
            }
        }
    }
}
