using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    [Route("[controller]")]
    [Route("Items")]
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index(int filterId = 0, string filtername = "")
        {
            return View(myProducts.Where(x => x.Id == filterId || x.Name.Contains(filtername)));
        }
        [Route("products")]
        [Route("View")]
        public IActionResult View(int id)
        {
            if (IdValidation.isValidID(id, myProducts)) return View(myProducts.Find(x => x.Id == id));
            else return View("NotExists", id);
        }
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {   
            if (IdValidation.isValidID(id, myProducts)) return View(myProducts.Find(x => x.Id == id));
            else return View("NotExists", id);
        }
        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Product product)
        {
            int index = myProducts.FindIndex(x => x.Id == product.Id);
            if (index != -1)
            {
                myProducts[index] = product;
            }
            var updatedProduct = myProducts.Find(x => x.Id == product.Id);

            return View("View", updatedProduct);
        }

        [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);

            return View("View", myProducts.Find(x => x.Id == product.Id));
        }

        [Route("new")]
        [Route("Create")]
        public IActionResult Create()
        {
            Product product = new Product() { Id = myProducts.Count + 1 };
            return View(product);
        }
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            if (IdValidation.isValidID(id, myProducts))
            {
                myProducts.Remove(myProducts.Find(product => product.Id == id));
                return View("Index", myProducts);
            }else return View("NotExists", id);
        }
        [Route("Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            if (IdValidation.isValidID(id, myProducts))
            {
                myProducts.Remove(myProducts.Find(product => product.Id == id));
                return View("Index", myProducts);
            }
            else return View("NotExists", id);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
