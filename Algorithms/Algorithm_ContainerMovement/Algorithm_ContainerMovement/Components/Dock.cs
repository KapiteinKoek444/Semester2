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
		Ship Ship;
		public int TotalContainerWeight;

		public void AddShip(Ship ship)
		{
			Ship = ship;
		}

		public void AddContainer(List<ShipContainer> containers)
		{
			foreach(var con in containers)
				UnAssignedContainers.Add(con);
		}

		public void AssignContainer(Point point, int height, Ship ship, ShipContainer container)
		{
			if (ship.AddContainer(container, point, height))
				UnAssignedContainers.RemoveAll(con => con == container);
		}

		//Algorithm
		public bool SolveContainers()
		{
			OrderContainers();
			
		}

		public void OrderContainers()
		{
			UnAssignedContainers.OrderByDescending(x => x.Weight);
		}

		public bool PlaceCooledContainers()
		{
			return UnAssignedContainers.Where(x => x.Cooled == true).All(c => Ship.AddCooledContainer(c) != false);
		}

		public bool PlaceNormalContainers()
		{
			return UnAssignedContainers.Where(x => x.Cooled == false && x.Valueable == false).All(c => Ship.AddNormalContainer(c) != false);
		}

		public bool PlaceValueableContainers()
		{
			return UnAssignedContainers.Where(x => x.Valueable == true).All(c => Ship.AddValueableContainer(c) != false);
		}
	}
}
