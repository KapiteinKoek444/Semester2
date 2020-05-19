using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Entities.Pizza_Components.IngredientTypes
{
	public enum Type
	{
		Olives,
		Herbs,
		Greens,
		Fruit,
	}

	class Greens : Ingredients
	{
		public Type Type { get; set; }
		public Greens(string name, int price, int spicyGrade, int quantity, Type type) : base(name, price, spicyGrade, quantity)
		{
			Type = type;
		}
	}
}
