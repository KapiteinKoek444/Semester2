using BusinessLogic.Factory;
using BusinessLogic.Factory.ItemFactories;
using BusinessLogic.Factory.ModelFactories;
using BusinessLogic.Models;
using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Connections;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Manager.Pizza
{
	public static class PizzaManager
	{
		public static void RemovePizza(PizzaModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var pizza = PizzaFactory.ConvertPizzaModel(model);
			unitOfWork.PizzaRepository.RemovePizza(pizza.Id);
		}

		public static List<PizzaModel> AddPizzas(List<PizzaModel> models)
		{
			foreach (var model in models)
			{
				AddPizza(model);
			}

			return models;
		}

		public static PizzaModel AssignIngredients(PizzaModel model, List<IngredientModel> ingredients)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			foreach (var ing in ingredients)
			{
				PizzaIngredientModel pizIng = new PizzaIngredientModel
				{
					Id = new Guid(),
					Ingredient = ing,
					PizzaId = model.Id
				};
				unitOfWork.PizzaIngredientRepository.AddPizza_Ingredients(PizzaIngredientFactory.ConvertPizzaIngredientModel(pizIng));
				model.PizzaIngredients.Add(pizIng);
			}
			unitOfWork.PizzaRepository.UpdatePizza(PizzaFactory.ConvertPizzaModel(model));
			return model;
		}

		public static PizzaModel AssignBottomToPizza(PizzaModel model, BottomModel bottom, SauceModel sauce)
		{
			if (model == null || bottom == null || sauce == null)
				return null;

			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();

			bottom.Sauce = sauce;
			model.Bottom = bottom;

			unitOfWork.PizzaRepository.UpdatePizza(PizzaFactory.ConvertPizzaModel(model));
			return model;
		}

		public static List<PizzaModel> getAllPizzas()
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var pizzas = unitOfWork.PizzaRepository.GetAllPizza().ToList();
			var models = PizzaModelFactory.ConvertPizzas(pizzas);
			return models;
		}

		public static PizzaModel GetPizza(Guid id)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var pizzas = unitOfWork.PizzaRepository.GetPizzaId(id);
			var model = PizzaModelFactory.ConvertPizza(pizzas);
			return model;
		}

		public static PizzaModel AddIngredientToPizza(PizzaModel pizza, IngredientModel ingredient)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			PizzaIngredientModel pizIngModel = new PizzaIngredientModel();
			pizIngModel.Ingredient = ingredient;
			pizIngModel.PizzaId = pizza.Id;
			pizza.PizzaIngredients.Add(pizIngModel);
			var _object = PizzaFactory.ConvertPizzaModel(pizza);
			unitOfWork.PizzaRepository.UpdatePizza(_object);
			return pizza;
		}

		public static PizzaModel OrderPizza(Guid userId, PizzaModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			OrderRuleModel orderrule = new OrderRuleModel();
			var order = unitOfWork.OrderRepository.GetAllOrders().Where(x => x.UserId == userId).FirstOrDefault();
			var modelOrder = OrderModelFactory.ConvertOrder(order);
			
			orderrule.OrderId = order.Id;
			orderrule.Pizza = model;
			
			model.OrderRuleId = orderrule.Id;
			modelOrder.OrderRules.Add(orderrule);

			unitOfWork.OrderRuleRepository.AddOrderRule(OrderRuleFactory.ConvertOrderRuleModel(orderrule));
			unitOfWork.OrderRepository.AddOrUpdate(OrderFactory.ConvertOrderModel(modelOrder));
			unitOfWork.PizzaRepository.UpdatePizza(PizzaFactory.ConvertPizzaModel(model));
			
			return model;
		}

		public static PizzaModel AddPizza(PizzaModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			model.Id = Guid.NewGuid();
			var pizza = PizzaFactory.ConvertPizzaModel(model);
			unitOfWork.PizzaRepository.AddPizza(pizza);
			return model;
		}
	}
}
