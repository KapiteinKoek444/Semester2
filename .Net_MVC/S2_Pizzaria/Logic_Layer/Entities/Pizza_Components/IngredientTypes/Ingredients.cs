using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Entities.Pizza_Components.IngredientTypes
{
	public class Ingredients
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int SpicyGrade { get; set; }
		public int Quantity { get; set; }

		public Ingredients(string name, int price, int spicyGrade, int quantity)
		{
			Name = name;
			Price = price;
			SpicyGrade = spicyGrade;
			Quantity = quantity;
		}
	}
}
