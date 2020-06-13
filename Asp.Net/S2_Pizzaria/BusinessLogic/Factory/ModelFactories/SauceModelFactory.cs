﻿using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory.ModelFactories
{
	public static class SauceModelFactory
	{
		public static List<SauceModel> ConvertSauce(List<Sauce> sauces)
		{
			List<SauceModel> models = new List<SauceModel>();

			foreach (var sauce in sauces)
			{
				var model = ConvertSauce(sauce);
				models.Add(model);
			}

			return models;
		}

		public static SauceModel ConvertSauce(Sauce sauce)
		{
			SauceModel model = new SauceModel()
			{
				Id = sauce.Id,
				IsSpicy = sauce.IsSpicy,
				Name = sauce.Name,
				Price = sauce.Price,
			};

			return model;
		}
	}
}
