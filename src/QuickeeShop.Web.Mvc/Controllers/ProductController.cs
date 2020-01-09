using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickeeShop.Controllers;
using QuickeeShop.Product;

namespace QuickeeShop.Web.Controllers
{
    public class ProductController : QuickeeShopControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = productService.AllProducts();

            return View(product);
        }
    }
}