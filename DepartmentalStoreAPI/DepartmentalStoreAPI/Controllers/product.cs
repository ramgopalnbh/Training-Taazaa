using DepartmentalStoreAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class product : ControllerBase
    {
        //[HttpGet]
        //public List<Product> GetProduct()
        //{
        //    Product p = new Product();
        //    var a = p.getProducts();
        //    return a;
        //}

        //[HttpPost]
        //public void addP(Product product)
        //{
        //    product.addProduct(product);
        //}

        public object get()
        {
            return new
            {
                id = 12,
                Name = "Ram"
            };
        }

        [HttpGet("abc")]
        public object a()
        {
            return new
            {
                id = 12,
                Name = "Ram Gopal"
            };
        }
    }
}
