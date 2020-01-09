using QuickeeShop.Customer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerBL> GetCustomers();
        void CreateCustomer(CustomerBL customer);
        CustomerBL FindById(int id);

        CustomerBL UpdateCustomer(CustomerBL customer);
        void DeleteCustomer(CustomerBL entity);
    }
}
