using AutoMapper;
using QuickeeShop.Customer.Dto;
using QuickeeShop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Customer
{
    public class CustomerBLMapper:Profile
    {
        public CustomerBLMapper()
        {
            CreateMap<CustomerBL, CustomerDL>().ReverseMap();
        }
    }
}
