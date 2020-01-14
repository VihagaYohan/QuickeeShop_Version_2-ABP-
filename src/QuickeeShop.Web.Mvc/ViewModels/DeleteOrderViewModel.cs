using QuickeeShop.Customer.Dto;
using QuickeeShop.Order.Dto;
using QuickeeShop.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickeeShop.Web.ViewModels
{
	public class DeleteOrderViewModel
	{
		public IEnumerable<CustomerBL> Customers { get; set; }
		public IEnumerable<ProductBL> Products { get; set; }
		public DateTime OrderDate { get; set; }
		public IEnumerable<OrderItemBL> OrderItems { get; set; }

		public CustomerBL Customer { get; set; }
		public ProductBL Product { get; set; }
		public OrderBL Order { get; set; }
	}
}
