using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        onlineshoppingContext db = new onlineshoppingContext();
        //[HttpGet]
        //public IEnumerable<Userstbl> getData()
        //{
        //    return db.Userstbls;
        //}
        [HttpPost]
        [Route("registration")]
              
        public IActionResult PostData(UsersRegister usersRegister)

        {
            Userstbl userstbl = new Userstbl();
            userstbl.Firstname = usersRegister.Firstname;
            userstbl.Lastname = usersRegister.Lastname;
            userstbl.Email = usersRegister.Email;
            userstbl.Password = usersRegister.Password;
            userstbl.Cpassword = usersRegister.Cpassword;
            userstbl.Contactnumber = usersRegister.Contactnumber;
            userstbl.Roletype = 0;

            if(db.Userstbls.Any(x=>x.Email==userstbl.Email))
            {
                return Ok("Warning ! Email Id Already Exists.");
            }
            else
            {

                if (userstbl.Password == userstbl.Cpassword)
                {

                    db.Userstbls.Add(userstbl);
                    db.SaveChanges();
                    return Ok("New Record Registered successfully.");
                }
                else
                {

                    return Ok("Error ! Password and Confirm Password must be same.");

                }
            }
        }
    }
}
