using BusinessLogic.Factory;
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
		public static List<PizzaModel> AddPizzas(List<PizzaModel> models)
		{
			foreach (var model in models)
			{
				AddPizza(model);
			}

			return models;
		}

		public static PizzaModel AddPizza(PizzaModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var pizza = PizzaFactory.ConvertPizzaModel(model);
			unitOfWork.PizzaRepository.AddPizza(pizza);
			return model;
		}

		public static List<PizzaModel> getAllPizzas()
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var pizzas = unitOfWork.PizzaRepository.GetAllPizza().Where(x => x.OrderRuleId == null).ToList();
			var models = PizzaModelFactory.ConvertPizza(pizzas);
			return models;
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

		public static PizzaModel OrderPizza(OrderModel order, PizzaModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			OrderRuleModel orderrule = new OrderRuleModel();
			orderrule.OrderId = order.Id;
			orderrule.Pizza = model;
			model.OrderRuleId = orderrule.Id;
			order.OrderRules.Add(orderrule);

			var pizza = PizzaFactory.ConvertPizzaModel(model);
			unitOfWork.PizzaRepository.UpdatePizza(pizza);
			return model;
		}

	}
}
