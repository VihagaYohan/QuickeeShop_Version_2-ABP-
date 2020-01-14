using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Exceptions.Order
{
	public class OrderItemNotFound : Exception
	{
		public OrderItemNotFound() : base("Order item not found")
		{

		}
	}
}
