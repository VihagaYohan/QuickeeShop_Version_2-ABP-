using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using QuickeeShop.Entity;
using QuickeeShop.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickeeShop.Order
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<OrderDL> orderRepository;
		private readonly IObjectMapper mapper;

		public OrderService(IRepository<OrderDL> orderRepository,
							IObjectMapper mapper)
		{
			this.orderRepository = orderRepository;
			this.mapper = mapper;
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
	}
}
