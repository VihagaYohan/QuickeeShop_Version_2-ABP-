using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Entity
{
	public class OrderDL : Entity<int>
	{
		public OrderDL()
		{

		}

		public int CustomerId { get; set; }
		public CustomerDL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItemDL> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }

		public OrderDL(int customerid, DateTime orderdate, List<OrderItemDL> orderitems, decimal ordertotal)
		{
			CustomerId = customerid;
			OrderDate = orderdate;
			OrderItems = orderitems;
			TotalAmount = ordertotal;
		}
	}
}
