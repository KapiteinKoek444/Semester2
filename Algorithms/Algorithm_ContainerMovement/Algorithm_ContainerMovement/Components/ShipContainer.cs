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
		public float Temperature { get; set; }
		public float Value { get; set; }

		public ShipContainer(float weight, float temperature, float value)
		{
			Weight = weight;
			Temperature = temperature;
			Value = value;
		}
	}
}
