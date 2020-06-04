using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities.Pizza_Components.IngredientTypes
{
	public class Ingredients
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int SpicyGrade { get; set; }
		public int Quantity { get; set; }
		public bool? IsVegetarian { get; set; }
		public bool? IsVegan { get; set; }
		public bool? IsHalal { get; set; }
		public bool? ContainsLactose { get; set; }
	}
}
