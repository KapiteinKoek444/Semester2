using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.Pizza_Components.IngredientTypes;
using Repository.Entities.Pizza_Components.BottomType;

namespace Repository.Entities.Pizza_Components
{
	public class Pizza
	{
		public List<Ingredients> Ingredients { get; set; }
		public Bottom Bottom { get; set; }
	}
}
