using AutoMapper;
using QuickeeShop.Entity;
using QuickeeShop.Product.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Product
{
	public class ProductBLMapper :Profile
	{
		public ProductBLMapper()
		{
			CreateMap<ProductBL, ProductDL>().ReverseMap();
		}
	}
}
