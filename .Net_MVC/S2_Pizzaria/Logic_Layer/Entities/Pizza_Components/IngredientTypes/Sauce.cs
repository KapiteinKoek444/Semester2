using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Entities.Pizza_Components.IngredientTypes
{
	public enum SauceType
	{
		Pesto,
		Tomato,
		special
	}

	public class Sauce : Ingredients
	{
		public SauceType SauceType { get; set; }
		public Sauce(string name, int price, int spicyGrade, int quantity, SauceType saucetype) : base(name, price, spicyGrade, quantity)
		{
			SauceType = saucetype;
		}
	}
}
