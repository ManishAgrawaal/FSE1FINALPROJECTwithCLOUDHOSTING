using System;
using System.Collections.Generic;

#nullable disable

namespace LoginServices.Models
{
    public partial class Userstbl
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpassword { get; set; }
        public string Contactnumber { get; set; }
        public int Roletype { get; set; }
    }
}
