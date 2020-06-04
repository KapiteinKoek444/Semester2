using Algorithm_ContainerMovement.Components.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_ContainerMovement.Components
{
	public class Dock
	{
		public List<ShipContainer> UnAssignedContainers = new List<ShipContainer>();
		public Ship Ship;
		public int TotalContainerWeight;

		public Dock()
		{
			Ship = ComponentFactory.GenerateDefaultShip();
		}

		public void AddContainer(List<ShipContainer> containers)
		{
			foreach (var con in containers)
				UnAssignedContainers.Add(con);
		}

		//Algorithm
		public bool SolveContainers()
		{
			List<ShipContainer> CooledContainers = UnAssignedContainers.Where(x => x.Type == Types.ContainerTypes.Cooled).OrderByDescending(x => x.Weight).ToList();
			List<ShipContainer> ValueableContainers = UnAssignedContainers.Where(x => x.Type == Types.ContainerTypes.Valueable).OrderByDescending(x => x.Weight).ToList();
			List<ShipContainer> RegularContainers = UnAssignedContainers.Where(x => x.Type == Types.ContainerTypes.Regular).OrderByDescending(x => x.Weight).ToList();

			int amount = 0;

			for (int i = 0; i < CooledContainers.Count; i++)
			{
				Ship.AddCooledContainer(CooledContainers[i]);
				amount += 1;
			}

			if (amount == CooledContainers.Count)
				CooledContainers.Clear();


			var leftWeight = Ship.CheckCooledBalance();

			ValueableContainers = AddSides(ValueableContainers);

			if (Ship.CheckBalance() == 1)
			{
				amount = 0;
				for (int i = 0; i < RegularContainers.Count; i++)
				{
					if(Ship.AddNormalContainer(RegularContainers[i], 1))
					{
						amount++;
					}
				}
				for (int i = 0; i < amount; i++)
					RegularContainers.Remove(RegularContainers[i]);
			}
			else
			{
				RegularContainers = AddSides(RegularContainers);
			}

			if (CooledContainers.Count == 0 && ValueableContainers.Count == 0 && RegularContainers.Count == 0)
			{
				UnAssignedContainers.Clear();
				Ship.SetWeight();
				return true;
			}

			return false;
		}

		public List<ShipContainer> AddSides(List<ShipContainer> containers)
		{
			int side = 2;
			int amount = 0;

			for (int i = 0; i < containers.Count; i++)
			{
				if (Ship.AddValueableContainer(containers[i], side))
				{
					if (Ship.CheckBalance() == 0)
						side = 0;

					if (Ship.CheckBalance() == 2)
						side = 2;

					amount++;
				}
				else
				{
					if (side == 2)
						side = 0;
					else if (side == 0)
						side = 2;

					if (!Ship.AddValueableContainer(containers[i], side))
						break;

					amount++;
				}
			}

			if (amount == containers.Count)
				containers.Clear();

			return containers;
		}
	}
}
