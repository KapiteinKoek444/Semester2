using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory
{
	public static class PizzaFactory
	{
		public static List<Pizza> ConvertPizzaModel(List<PizzaModel> models)
		{
			List<Pizza> pizzas = new List<Pizza>();

			foreach(var model in models)
			{
				var pizza = ConvertPizzaModel(model);
				pizzas.Add(pizza);
			}

			return pizzas;
		}
		
		public static Pizza ConvertPizzaModel(PizzaModel model)
		{
			Pizza pizza = new Pizza
			{

			}

			return pizza;
		}
	}
}
