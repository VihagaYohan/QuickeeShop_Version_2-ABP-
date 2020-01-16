using QuickeeShop.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Order
{
	public interface IOrderService
	{
		IEnumerable<OrderBL> AllOrder();
		void AddOrder(OrderBL order);
		OrderBL FindByOrderId(int Id);
		void UpdateOrder(OrderBL order);
		void DeleteOrder(OrderBL order);
	}
}
