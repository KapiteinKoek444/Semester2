using BusinessLogic.Models;
using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Connections;
using Repository.Entities.Pizza_Components;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory.ModelFactories
{
	public static class OrderModelFactory
	{
		public static List<OrderModel> ConvertOrders(List<Order> orders)
		{
			List<OrderModel> models = new List<OrderModel>();
			foreach (var order in orders)
			{
				var model = ConvertOrders(order);
				models.Add(model);
			}
			return models;
		}

		public static OrderModel ConvertOrders(Order order)
		{
			var OrderRules = OrderRuleModelFactory.ConvertOrderRules(order.OrderRule);
			OrderModel model = new OrderModel()
			{
				Id = order.Id,
				UserId = order.UserId,
				OrderRules = OrderRules
			};

			return model;
		}

		public static OrderModel GetOrderModel(Guid Id)
		{
			UnitOfWorkRepository unitofWork = new UnitOfWorkRepository();
			var order = unitofWork.OrderRepository.GetOrderId(Id);
			var model = ConvertOrders(order);
			return model;
		}
	}
}
