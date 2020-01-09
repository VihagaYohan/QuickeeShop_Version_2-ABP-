using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickeeShop.Customer.Dto
{
    public class CustomerBL : EntityDto<int>
    {
        [Required(ErrorMessage = "First name required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName 
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
