using System;
using System.Collections.Generic;

#nullable disable

namespace LoginServices.Models
{
    public partial class Productstbl
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Productdesc { get; set; }
        public string Price { get; set; }
        public string Features { get; set; }
        public int Status { get; set; }
    }
}
