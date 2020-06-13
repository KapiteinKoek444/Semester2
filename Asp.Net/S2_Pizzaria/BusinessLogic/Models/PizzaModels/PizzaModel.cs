using BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.IngredientComponents
{
	public class PizzaModel : EntityModelBase
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public List<IngredientModel> Ingredients { get; set; }
		public BottomModel Bottom { get; set; }
	}
}
