using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public class AssignedShipContainer : ShipContainer
	{
		public Point Location { get; set; }

		public AssignedShipContainer(float weight, float temperature, float value, Point location) : base(weight, temperature, value)
		{
			Location = location;
		}
	}
}
