using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using QuickeeShop.Customer.Dto;
using QuickeeShop.Entity;
using System;
using System.Collections.Generic;

using System.Text;

namespace QuickeeShop.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<CustomerDL> customerRepository;
        private readonly IObjectMapper mapper;

        public CustomerService(IRepository<CustomerDL> customerRepository,
                               IObjectMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        // get all customers
        public IEnumerable<CustomerBL> GetCustomers()
        {
            try
            {
                var ls_Customers = customerRepository.GetAll();
                return mapper.Map<IEnumerable<CustomerBL>>(ls_Customers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // add customer
        public void CreateCustomer(CustomerBL entity)
        {
            try
            {
                var customer = mapper.Map<CustomerDL>(entity);
                customerRepository.Insert(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // find customer by id
        public CustomerBL FindById(int id)
        {
            try
            {
                var customer = customerRepository.FirstOrDefault(id);
                return mapper.Map<CustomerBL>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // update customer
        public CustomerBL UpdateCustomer(CustomerBL entity)
        {
            try
            {
                var customer = FindById(entity.Id);
                if (entity == null)
                    throw new Exception("Customer not found");
                customerRepository.Update(mapper.Map<CustomerDL>(entity));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete customer
        public void DeleteCustomer(CustomerBL entity) 
        {
            try
            {
                var customer = FindById(entity.Id);
                if (customer != null)
                    customerRepository.Delete(mapper.Map<CustomerDL>(customer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
