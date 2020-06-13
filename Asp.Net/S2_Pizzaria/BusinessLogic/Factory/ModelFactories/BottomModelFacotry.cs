using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Pizza_Components;
using Repository.Entities.Pizza_Components.BottomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory.ModelFactories
{
	public static class BottomModelFacotry
	{
		public static List<BottomModel> ConvertBottom(List<Bottom> bottoms, List<SauceModel> sauces)
		{
			List<BottomModel> models = new List<BottomModel>();

			foreach (var bot in bottoms)
			{
				var model = ConvertBottom(bot, sauces.Where(x => x.Id == bot.SauceId).FirstOrDefault());
				models.Add(model);
			}

			return models;
		}

		public static BottomModel ConvertBottom(Bottom bottom, SauceModel sauce)
		{
			BottomModel model = new BottomModel()
			{
				Id = bottom.Id,
				Sauce = sauce,
				Price = bottom.Price,
				Surface = bottom.Surface,
				Thick = bottom.Thick,
				Name = bottom.Name,
			};

			return model;
		}
	}
}
