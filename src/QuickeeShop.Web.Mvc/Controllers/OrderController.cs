using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickeeShop.Controllers;
using QuickeeShop.Customer;
using QuickeeShop.Order;
using QuickeeShop.Product;

namespace QuickeeShop.Web.Controllers
{
    public class OrderController : QuickeeShopControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public OrderController(ICustomerService customerService,
                               IProductService productService,
                               IOrderService orderService)
        {
            this.customerService = customerService;
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}