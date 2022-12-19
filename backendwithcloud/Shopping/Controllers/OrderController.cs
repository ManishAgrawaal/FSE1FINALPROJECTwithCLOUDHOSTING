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
    
    public class OrderController : ControllerBase
    {
        onlineshoppingContext db = new onlineshoppingContext();
        [HttpPost]
        [Route("add")]


        public IActionResult postData(OrderPlaced orderPlaced)
        {
            Random random = new Random();
            int uid = random.Next(10000,99999);
            String orderid = "OD"+uid;
            Orderstbl orderstbl = new Orderstbl();
            orderstbl.Productid = orderPlaced.Productid;
            orderstbl.Customerid = orderPlaced.Customerid;
            orderstbl.Date = DateTime.Now.ToString();
            orderstbl.Orderid = orderid.ToString();
            db.Orderstbls.Add(orderstbl);
            db.SaveChanges();

            return Ok("Order added Successfully");
        }
    }
}
