using Algorithm_ContainerMovement.Components.Enums;
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
		public int Height { get; set; }

		public AssignedShipContainer(float weight, Types.ContainerTypes Type, Point location, int height) : base(weight, Type)
		{
			Location = location;
			Height = height;
		}
	}
}
