using BusinessLogic.Models.IngredientComponents;
using Repository.Entities.Pizza_Components;
using Repository.Entities.Pizza_Components.BottomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factory.ItemFactories
{
	public static class BottomFactory
	{
		public static List<Bottom> ConvertBottom(List<BottomModel> models)
		{
			List<Bottom> bottoms = new List<Bottom>();

			foreach (var model in models)
			{
				var bottom = ConvertBottom(model);
				bottoms.Add(bottom);
			}

			return bottoms;
		}

		public static Bottom ConvertBottom(BottomModel model)
		{
			Bottom bottom = new Bottom()
			{
				Id = model.Id,
				SauceId = model.Sauce.Id,
				Name = model.Name,
				Price = model.Price,
				Thick = model.Thick,
				Surface = model.Surface,
			};

			return bottom;
		}
	}
}
