using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Entity
{
	public class OrderDL : Entity<int>
	{
		public int CustomerId { get; set; }
		public CustomerDL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public IEntity<OrderItemDL> OrderItem { get; set; }
		public decimal OrderTotal { get; set; }
	}
}
