using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Entity
{
	public class OrderItemDL:Entity<int>
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public decimal LineTotal { get; set; }
	}
}
