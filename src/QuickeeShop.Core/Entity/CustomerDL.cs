using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Entity 
{
    public class CustomerDL:Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
