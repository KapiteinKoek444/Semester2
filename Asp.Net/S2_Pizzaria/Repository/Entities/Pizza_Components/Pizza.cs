﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.Pizza_Components.IngredientTypes;
using Repository.Entities.Pizza_Components.BottomType;
using Repository.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Entities.Connections;

namespace Repository.Entities.Pizza_Components
{
	public class Pizza : EntityModelBase
	{
		public Guid BottomId { get; set; }

		public OrderRule OrderRule { get; set; }
		public Pizza_Ingredient PizzaIngredient { get; set; }
		
		public string Name { get; set; }
		public double Price { get; set; }
	}
}