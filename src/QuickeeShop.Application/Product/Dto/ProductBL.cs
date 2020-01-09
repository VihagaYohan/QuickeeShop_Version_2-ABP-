using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickeeShop.Product.Dto
{
	public class ProductBL : EntityDto<int>
	{
		[Required (ErrorMessage ="Product name required")]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required (ErrorMessage ="Product description required")]
		[MaxLength(100)]
		public string ProductDescription { get; set; }
		
		[Required]
		public decimal UnitPrice { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}
