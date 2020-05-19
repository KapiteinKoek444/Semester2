using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_Layer.Entities.Pizza_Components.IngredientTypes;
using Logic_Layer.Entities.Pizza_Components.BottomType;

namespace Logic_Layer.Entities.Pizza_Components
{
	public class Pizza
	{
		public List<Ingredients> Ingredients { get; set; }
		public Bottom Bottom { get; set; }

		public Pizza(List<Ingredients> ingredients, Bottom bottom)
		{
			Ingredients = ingredients;
			Bottom = bottom;
		}
	}
}
