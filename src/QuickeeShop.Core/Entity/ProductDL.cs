using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickeeShop.Entity
{
	public class ProductDL : Entity<int>
	{
		[Required(ErrorMessage = "Product name required")]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Product description required")]
		[MaxLength(100)]
		public string ProductDescription { get; set; }

		[Required]
		public decimal UnitPrice { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}
