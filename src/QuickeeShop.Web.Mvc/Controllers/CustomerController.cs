using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickeeShop.Controllers;
using QuickeeShop.Customer;
using QuickeeShop.Customer.Dto;

namespace QuickeeShop.Web.Controllers
{
    public class CustomerController : QuickeeShopControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var Customers = customerService.GetCustomers();
                if (Customers != null)
                    return View(Customers);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerBL customer) 
        {
            // need to apply client side validations
            try
            {
                if (ModelState.IsValid)
                {
                    customerService.CreateCustomer(customer);
                    return RedirectToAction("Index");
                }
                else 
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var customer = customerService.FindById(Id);
                return View(customer);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        [HttpPost]
        public IActionResult Edit(CustomerBL entity) 
        {
            // need to apply client validations
            try
            {
                var customer = customerService.UpdateCustomer(entity);
                if (customer != null)
                    return RedirectToAction("Index");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            var customer = customerService.FindById(Id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(CustomerBL entity) 
        {
            try
            {
                customerService.DeleteCustomer(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}