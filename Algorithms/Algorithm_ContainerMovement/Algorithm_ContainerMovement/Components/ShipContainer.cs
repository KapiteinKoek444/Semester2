using Algorithm_ContainerMovement.Components.Enums;
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
		public Types.ContainerTypes Type { get; set; }

		public ShipContainer(float weight, Types.ContainerTypes type)
		{
			Weight = weight;
			Type = type;
		}
	}
}
