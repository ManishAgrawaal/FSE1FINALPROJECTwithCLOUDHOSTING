using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping.ViewModel
{
    public class AddProduct
    {
        public int id { get; set; }
        public string Productname { get; set; }
        public string Productdesc { get; set; }
        public string Price { get; set; }
        public string Features { get; set; }
        
        public int Status { get; set; }
    }
}
