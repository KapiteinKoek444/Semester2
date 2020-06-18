using BusinessLogic.Models;
using Repository.Entities.Connections;
using Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory.ItemFactories
{
	public static class OrderFactory
	{
		public static List<Order> ConvertOrderModels(List<OrderModel> models)
		{
			List<Order> orders = new List<Order>();
			foreach (var model in models)
			{
				var order = ConvertOrderModels(model);
				orders.Add(order);
			}

			return orders;
		}

		public static Order ConvertOrderModels(OrderModel model)
		{
			var orderRules = OrderRuleFactory.ConvertOrderRuleModel(model.OrderRules);

			Order order = new Order()
			{
				Id = model.Id,
				UserId = model.UserId,
				OrderRule = orderRules
			};

			return order;
		}
	}
}
