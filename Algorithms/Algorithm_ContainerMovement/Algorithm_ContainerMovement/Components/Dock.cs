using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public class Dock
	{
		public readonly List<ShipContainer> UnAssignedContainers = new List<ShipContainer>();
		public readonly List<Ship> Ships = new List<Ship>();

		public void AddShip(Ship ship)
		{
			Ships.Add(ship);
		}

		public void AddContainer(List<ShipContainer> containers)
		{
			foreach(var con in containers)
				UnAssignedContainers.Add(con);
		}

		public void ManualAssignContainer(Point point, Ship ship, ShipContainer container)
		{
			if (ship.AddContainer(container, point))
				UnAssignedContainers.RemoveAll(con => con == container);
		}
	}
}
