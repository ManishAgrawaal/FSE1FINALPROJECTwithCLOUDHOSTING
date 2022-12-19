using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping.ViewModel
{
    public class OrderPlaced
    {
        public int Productid { get; set; }
        public int Customerid { get; set; }
       [JsonIgnore]
        public string Date { get; set; }
    }
}
