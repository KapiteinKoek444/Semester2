using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.IngredientComponents
{
	public class PizzaModel
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public List<IngredientModel> Ingredients { get; set; }
		public BottomModel Bottom { get; set; }
	}
}
