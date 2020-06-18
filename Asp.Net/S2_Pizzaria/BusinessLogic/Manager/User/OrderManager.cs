using BusinessLogic.Factory;
using BusinessLogic.Factory.ItemFactories;
using BusinessLogic.Factory.ModelFactories;
using BusinessLogic.Models;
using Repository.UnitOfWork;
using System.Linq;

namespace BusinessLogic.Manager.User
{
	public static class OrderManager
	{
		public static OrderModel AddOrder(OrderModel orderMod)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var order = OrderFactory.ConvertOrderModels(orderMod);
			unitOfWork.OrderRepository.AddOrder(order);
			return orderMod;
		}

		public static OrderModel GetOrder(UserModel user)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var order = OrderModelFactory.GetOrderModel(user.Order.Id);
			return order;
		}
	}
}
