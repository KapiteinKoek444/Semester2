using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Factory
{
	public static class PizzaModelFactory
	{
		public static List<PizzaModel> ConvertPizza(List<Pizza> pizzas)
		{
			List<PizzaModel> Models = new List<PizzaModel>();
			List<IngredientModel> ingredients = new List<IngredientModel>();

			foreach (var pizza in pizzas)
			{
				var model = ConvertPizza(pizza);
				Models.Add(model);
			}

			return Models;
		}

		public static PizzaModel ConvertPizza(Pizza pizza)
		{

		}
	}
}
