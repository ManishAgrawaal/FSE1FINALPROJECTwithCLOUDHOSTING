using LoginServices.Interfaces;
using LoginServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Threading.Tasks;

namespace LoginServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private readonly onlineshoppingContext db;
        private readonly IJWTManagerRepository iJWTManagerRepository;
       public LoginController(onlineshoppingContext _db, IJWTManagerRepository _iJWTManagerRepository)
        {
            db = _db;
            iJWTManagerRepository = _iJWTManagerRepository;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var token = iJWTManagerRepository.Authenticate(loginViewModel);
            if(token==null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        //[HttpPost]
        //public IActionResult Register(LoginViewModel loginViewModel)
        //{
        //    var token = iJWTManagerRepository.Authenticate(loginViewModel,true);
        //    if (token == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(token);
        //}

    }
}
