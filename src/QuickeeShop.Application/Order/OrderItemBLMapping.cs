﻿using AutoMapper;
using QuickeeShop.Entity;
using QuickeeShop.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickeeShop.Order
{
	public class OrderItemBLMapping :Profile
	{
		public OrderItemBLMapping()
		{
			CreateMap<OrderItemBL, OrderItemDL>().ReverseMap();
		}
	}
}
