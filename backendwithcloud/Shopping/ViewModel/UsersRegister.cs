using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping.ViewModel
{
    public class UsersRegister
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpassword { get; set; }
        public string Contactnumber { get; set; }
        [JsonIgnore]
        public int Roletype { get; set; }

    }
}
