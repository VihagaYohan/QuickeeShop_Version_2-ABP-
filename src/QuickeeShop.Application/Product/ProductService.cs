using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using QuickeeShop.Entity;
using QuickeeShop.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickeeShop.Product
{
	public class ProductService :IProductService
	{
		private readonly IRepository<ProductDL> productRepository;
		private readonly IObjectMapper mapper;

		public ProductService(IRepository<ProductDL> productRepository,
							  IObjectMapper mapper)
		{
			this.productRepository = productRepository;
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
	}
}
