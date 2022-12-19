using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
 
    public class OrderHistoryController : ControllerBase
    {
        onlineshoppingContext db = new onlineshoppingContext();
        [HttpGet]
        [Route("ViewDetails")]

        
        public IActionResult getData()
        {
            var query = (from o in db.Orderstbls
                         join p in db.Productstbls on o.Productid equals p.Id
                         join u in db.Userstbls on o.Customerid equals u.Id

                         select new
                         {
                             o.Orderid,
                             o.Date,
                             p.Productname,
                             p.Price,
                             u.Firstname,
                             u.Email
                         });

            var findData = query.ToList();
            if(findData==null)
            {
                return Ok("Order is Empty !");
            }
            return Ok(findData);
        }
    }
}
