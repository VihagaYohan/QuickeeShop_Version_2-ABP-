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
using QuickeeShop.Product;
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
            var customerNameList = customerService.GetCustomers()
                                                  .Select(s => new CustomerListModel
                                                   {
                                                       Text = s.FullName,
                                                       Value = s.Id
                                                   });
            var productNameList = productService.AllProducts()
                                                .Select(p => new ProductListModel
                                                {
                                                    Text = p.Name,
                                                    Value = p.Id
                                                });
            PlaceOrderViewModel model = new PlaceOrderViewModel
            {
                CustomerNameList = new List<SelectListItem>(),
                ProductNameList = new List<SelectListItem>()
            };

            foreach (var item in customerNameList)
            {
                model.CustomerNameList.Add(new SelectListItem 
                { 
                    Text = item.Text,
                    Value = item.Value.ToString()
                });
            }

            foreach (var item in productNameList)
            {
                model.ProductNameList.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value.ToString()
                });
            }

            model.OrderDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CustomerBL entity) 
        {
            return View();
        }
    }
}