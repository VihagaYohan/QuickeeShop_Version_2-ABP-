using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickeeShop.Controllers;
using QuickeeShop.Customer;
using QuickeeShop.Customer.Dto;
using QuickeeShop.Order;
using QuickeeShop.Order.Dto;
using QuickeeShop.Product;
using QuickeeShop.Product.Dto;
using QuickeeShop.Web.ListModels;
using QuickeeShop.Web.ViewModels;

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
            var orders = orderService.AllOrder();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            try
            {
                var viewModel = new PlaceOrderViewModel()
                {
                    Customers = customerService.GetCustomers(),
                    Products = productService.AllProducts(),
                    OrderDate = Convert.ToDateTime(DateTime.Today.ToShortDateString())
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderBL entity) 
        {
            if (ModelState.IsValid) 
            {
                orderService.AddOrder(entity);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}