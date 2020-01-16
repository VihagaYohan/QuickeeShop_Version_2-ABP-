using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using QuickeeShop.Entity;
using QuickeeShop.Order.Dto;
using QuickeeShop.Product.Dto;
using QuickeeShop.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickeeShop.Product
{
	public class ProductService : IProductService
	{
		private readonly IRepository<ProductDL> productRepository;
		private readonly IRepository<OrderDL> orderRepository;
		private readonly IRepository<OrderItemDL> orderItemRepository;
		private readonly IObjectMapper mapper;

		public ProductService(IRepository<ProductDL> productRepository,
							  IRepository<OrderDL> orderRepository,
							  IRepository<OrderItemDL> orderItemRepository,
							  IObjectMapper mapper)
		{
			this.productRepository = productRepository;
			this.orderRepository = orderRepository;
			this.orderItemRepository = orderItemRepository;
			this.mapper = mapper;
		}

		// get all products
		public IEnumerable<ProductBL> AllProducts()
		{
			try
			{
				var product = productRepository.GetAll().AsNoTracking().OrderBy(p => p.Id);
				return mapper.Map<IEnumerable<ProductBL>>(product);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// update product quantity
		//public void UpdateQuantity(int productid, int qty)
		//{
		//	var getId = productRepository.Get(productid);
		//	getId.Quantity = getId.Quantity + qty;
		//	var updateQty = mapper.Map<ProductDL>(getId);
		//	productRepository.Update(updateQty);
		//}

		public void UpdateQuantity(List<OrderItemBL> orderItems) 
		{
			foreach (var item in orderItems)
			{
				var product = productRepository.GetAll().AsNoTracking().FirstOrDefault(p => p.Id == item.ProductId);
				var existingOrderItem = orderItemRepository.GetAll().AsNoTracking().FirstOrDefault(i => i.Id == item.Id);

				var existingQty = 0;
				var currentInStock = product.Quantity;
				var requestedQty = item.Quantity;
				var QuantityToBeUpdated = 0;
				var NewQuantity = 0;

				// check if product is adding for the first time
				if (existingOrderItem == null)
				{
					//existingQty = existingOrderItem.Quantity;
					existingQty = item.Quantity;
					NewQuantity = product.Quantity - existingQty;
				}

				else if (requestedQty < existingQty)
				{
					QuantityToBeUpdated = existingQty - requestedQty;
					NewQuantity = currentInStock + QuantityToBeUpdated;
				}
				else if (requestedQty > existingQty)
				{
					QuantityToBeUpdated = existingQty - requestedQty;
					NewQuantity = currentInStock - QuantityToBeUpdated;
				}
				else if (requestedQty == existingQty) 
				{
					NewQuantity = currentInStock - requestedQty;
				}

				if (currentInStock <= 0) 
				{
					throw new NoItemInStock();
				}

				product.Quantity = NewQuantity;
				productRepository.Update(product);
			}
		}
	}
}
