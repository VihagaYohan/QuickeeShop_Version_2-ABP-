using QuickeeShop.Order.Dto;
using QuickeeShop.Product.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Product
{
	public interface IProductService
	{
		IEnumerable<ProductBL> AllProducts();
		//public void UpdateQuantity(int productId, int qty);
		public void UpdateQuantity(List<OrderItemBL> OrderItems);
	}
}
