using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Product.Exceptions
{
	public class NoItemInStock : Exception
	{
		public NoItemInStock() : base("There are no available quantity")
		{

		}
	}
}
