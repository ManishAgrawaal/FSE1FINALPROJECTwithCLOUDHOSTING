using System;
using System.Collections.Generic;

#nullable disable

namespace LoginServices.Models
{
    public partial class Orderstbl
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public int Customerid { get; set; }
        public string Date { get; set; }
        public string Orderid { get; set; }
    }
}
