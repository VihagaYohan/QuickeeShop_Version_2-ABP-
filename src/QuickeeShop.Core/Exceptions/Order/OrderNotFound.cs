using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Exceptions.Order
{
	public class OrderNotFound : Exception
	{
		public OrderNotFound() : base("Unable to locate requested order")
		{

		}
	}
}
