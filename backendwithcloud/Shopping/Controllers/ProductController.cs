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
    //[Authorize]
    
    public class ProductController : ControllerBase
    {
        onlineshoppingContext db = new onlineshoppingContext();
        [HttpGet]
        [Route("all")]
        public IEnumerable<Productstbl> getData()
        {
          return db.Productstbls;
        }

        [HttpPost]
        [Route("productname/add")]
        public IActionResult postData(AddProduct addProduct)
        {
            Productstbl productstbl = new Productstbl();
            productstbl.Id = addProduct.id;
            productstbl.Productname = addProduct.Productname;
            productstbl.Productdesc = addProduct.Productdesc;
            productstbl.Price = addProduct.Price;
            productstbl.Features = addProduct.Features;
            productstbl.Status = 1;
            db.Productstbls.Add(productstbl);
            db.SaveChanges();

            return Ok("Product Added Successfully");
        }

        [HttpPut]
        [Route("productname/update/id")]
        public IActionResult putData(UpdateProdStatus updateProdStatus)
        {
            if (db.Productstbls.Any(x => x.Id == updateProdStatus.id))
            {
                var data = db.Productstbls.Where(x => x.Id == updateProdStatus.id).FirstOrDefault();
                data.Status = updateProdStatus.Status;
                db.Productstbls.Update(data);
                db.SaveChanges();
                return Ok(" Product status have been updated successfully !");
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]
        [Route("productname/delete/id")]
        public IActionResult deleteData(int Id)
        {
            if (db.Productstbls.Any(x => x.Id == Id))
            {
                var data = db.Productstbls.Where(x => x.Id == Id).FirstOrDefault();
                db.Productstbls.Remove(data);
                db.SaveChanges();
                return Ok("Product have been deleted successfully.");
            }

            return BadRequest("Record not found.");
        }

        [HttpGet]
        [Route("/search/productname")]
        public IActionResult GetByProductName(string productname)
        {
            var data = db.Productstbls.Where(x => x.Productname.Contains(productname));
            if (data == null)
            {
                return Ok("Record not found !");
            }
            return Ok(data);

        }
    }
}
