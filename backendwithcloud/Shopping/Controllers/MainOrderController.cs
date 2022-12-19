using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainOrderController : ControllerBase
    {
        onlineshoppingContext db = new onlineshoppingContext();
        [HttpGet]
        [Route("all")]
        public IEnumerable<Orderstbl> getData()
        {
            return db.Orderstbls;
        }

    }
}
