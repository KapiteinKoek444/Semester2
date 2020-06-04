using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.IngredientComponents
{
	public class SauceModel : IngredientModel
	{
		public enum SauceType
		{
			Pesto,
			Tomato,
			special
		}

		public Enum Type { get; set; }
	}
}
