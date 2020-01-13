﻿using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using QuickeeShop.Entity;
using QuickeeShop.Exceptions.Order;
using QuickeeShop.Order.Dto;
using QuickeeShop.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickeeShop.Order
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<OrderDL> orderRepository;
		private readonly IRepository<ProductDL> productRepository;
		private readonly IObjectMapper mapper;
		private readonly IUnitOfWorkManager unitOfWorkManager;
		private readonly IProductService productService;

		public OrderService(IRepository<OrderDL> orderRepository,
							IRepository<ProductDL> productRepository,
							IProductService productService,
							IObjectMapper mapper,
							IUnitOfWorkManager unitOfWorkManager)
		{
			this.orderRepository = orderRepository;
			this.productRepository = productRepository;
			this.productService = productService;
			this.mapper = mapper;
			this.unitOfWorkManager = unitOfWorkManager;
		}

		// get all orders
		public IEnumerable<OrderBL> AllOrder()
		{
			try
			{
				var orders = orderRepository.GetAll().AsNoTracking().OrderBy(o => o.Id);
				return mapper.Map<IEnumerable<OrderBL>>(orders);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// create order
		public void AddOrder(OrderBL entity)
		{
			if (entity == null)
			{
				throw new OrderNotFound();
			}
			var OrderListItems = new List<OrderItemBL>();
			foreach (var item in entity.OrderItems)
			{
				var product = productRepository.GetAll().AsNoTracking()
														.FirstOrDefault(p => p.Id == item.ProductId);
				item.ProductName = product.Name;
				item.UnitPrice = product.UnitPrice;
				item.Quantity = item.Quantity;
				item.LineTotal = item.UnitPrice * item.Quantity;

				OrderListItems.Add(item);
			}

			using (var unitOfWork = unitOfWorkManager.Begin()) 
			{
				try
				{
					// create order
					var model = new OrderBL(entity.CustomerId, entity.OrderDate, entity.OrderItems, entity.TotalAmount);
					var orderEntity = mapper.Map<OrderDL>(model);
					orderRepository.Insert(orderEntity);

					// update product quantity
					productService.UpdateQuantity(OrderListItems);

					unitOfWork.Complete();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			//foreach (var item in entity.OrderItems)
			//{
			//	var getProdId = productRepository.Get(item.ProductId);
			//	productService.UpdateQuantity(item.ProductId, -(item.Quantity));

			//}
			


		}
	}
}

