using ContainerMovement_V2.Factories;
using ContainerMovement_V2.Objects;
using ContainerMovement_V2.Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContainerMovement_V2.Logic
{
	public class Dock
	{
		public List<ShipContainer> unassignedContainers = new List<ShipContainer>();
		public Ship Ship;

		public Dock()
		{
			Ship = ShipFactory.GenerateDefaultShip();
		}

		public void AddContainer(List<ShipContainer> containers)
		{
			foreach (var con in containers)
				unassignedContainers.Add(con);
		}

		public bool AssignContainers()
		{
			if (unassignedContainers.Sum(x => x.Weight) < Ship.Weight / 2)
				return false;

			List<ShipContainer> CooledContainers = unassignedContainers.Where(x => x.Type == Types.ContainerTypes.Cooled).OrderByDescending(x => x.Weight).ToList();
			List<ShipContainer> ValueableContainers = unassignedContainers.Where(x => x.Type == Types.ContainerTypes.Valueable).OrderByDescending(x => x.Weight).ToList();
			List<ShipContainer> RegularContainers = unassignedContainers.Where(x => x.Type == Types.ContainerTypes.Regular).OrderByDescending(x => x.Weight).ToList();

			if (AddCooledContainers(CooledContainers))
				CooledContainers.Clear();
			else
				return false;

			if (AddValueableContainers(ValueableContainers))
				ValueableContainers.Clear();
			else
				return false;

			if (AddRegularContainers(RegularContainers))
				RegularContainers.Clear();
			else
				return false;

			if (Ship.CheckBalance() == Types.Sides.Middle)
				return true;

			return false;
		}

		//Add Cooled
		public bool AddCooledContainers(List<ShipContainer> Cooled)
		{
			foreach (var con in Cooled)
				if (!Ship.AddCooledContainer(con))
					return false;

			return true;
		}

		//AddValueable
		public bool AddValueableContainers(List<ShipContainer> Valueable)
		{
			foreach (var c in Valueable)
				if (!CheckSides(c))
					return false;

			return true;
		}

		//AddRegular
		public bool AddRegularContainers(List<ShipContainer> Regular)
		{
			foreach (var c in Regular)
				if (!CheckSides(c))
					return false;

			return true;
		}

		public bool CheckSides(ShipContainer c)
		{
			if (c.Type == Types.ContainerTypes.Regular)
			{
				if (Ship.AddRegularContainer(c, Ship.CheckBalance()))
					return true;
			}

			if (c.Type == Types.ContainerTypes.Valueable)
			{
				var side = Ship.CheckBalance();
				if (side == Types.Sides.Middle)
					if (Ship.AddValueableContainer(c, Types.Sides.Left))
						return true;
					else
						if (Ship.AddValueableContainer(c, side))
						return true;

				if (Ship.AddValueableContainer(c, side))
					return true;
			}

			return false;
		}
	}
}
