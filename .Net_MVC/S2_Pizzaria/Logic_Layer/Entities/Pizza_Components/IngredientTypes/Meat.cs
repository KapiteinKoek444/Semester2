using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Entities.Pizza_Components.IngredientTypes
{

	public enum Animal
	{
		Cow,
		Chicken,
		Sheep,
		Horse,
		Pig,
		Rhino
	}

	public class Meat : Ingredients
	{

		public bool Halal { get; set; }
		public bool Vegetarian { get; set; }
		public Animal Animal { get; set; }
		public Meat(string name, int price, int spicyGrade, int quantity, bool halal, bool vegetarian, Animal animal) : base(name, price, spicyGrade, quantity)
		{
			Halal = halal;
			Vegetarian = vegetarian;
			Animal = animal;
		}
	}
}
