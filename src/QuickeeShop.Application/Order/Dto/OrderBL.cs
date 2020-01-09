using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using QuickeeShop.Customer.Dto;
using QuickeeShop.Product.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Order.Dto
{
	public class OrderBL : EntityDto<int>
	{
		public int CustomerId { get; set; }
		public CustomerBL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public IEntity<OrderItemBL> OrderItem { get; set; }
		public decimal OrderTotal { get; set; }
	}
}
