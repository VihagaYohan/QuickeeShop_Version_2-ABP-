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
		public OrderBL()
		{

		}
		public int CustomerId { get; set; }
		public CustomerBL Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItemBL> OrderItems { get; set; }
		public decimal TotalAmount { get; set; }

		public OrderBL(int customerid, DateTime orderdate, List<OrderItemBL> orderitems, decimal ordertotal)
		{
			CustomerId = customerid;
			OrderDate = orderdate;
			OrderItems = orderitems;
			TotalAmount = ordertotal;
		}
	}
}
