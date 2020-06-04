using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities.Pizza_Components.BottomType
{
	public class Bottom
	{
		public double Price;
		public double PricePerCM = 0.1;
		public double MaxSurface { get; }
		public double MinSurface { get; }
		public double Radius { get; set; }
		public string BotType { get; set; }
		public bool Thick { get; set; }
		public Sauce Sauce { get; set; }
	}
}
