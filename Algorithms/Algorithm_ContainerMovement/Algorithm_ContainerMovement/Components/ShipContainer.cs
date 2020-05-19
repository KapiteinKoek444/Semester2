using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public class ShipContainer
	{
		public float Weight { get; set; }
		public bool Cooled { get; set; }
		public bool Valueable { get; set; }

		public ShipContainer(float weight, bool cooled, bool valueable)
		{
			Weight = weight;
			Cooled = cooled;
			Valueable = valueable;
		}
	}
}
