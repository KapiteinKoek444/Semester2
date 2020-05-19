using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Entities.Pizza_Components.IngredientTypes
{
	public enum CheeseType
	{
		Goat,
		Sheep,
		Cow,
		Buffalo
	}

	public class Cheese : Ingredients
	{

		public bool Lactose { get; set; }
		public CheeseType Type { get; set; }

		public Cheese(string name, int price, int spicyGrade, int quantity, bool lactose, CheeseType type) : base(name, price, spicyGrade, quantity)
		{
			Lactose = lactose;
			Type = type;
		}
	}
}
