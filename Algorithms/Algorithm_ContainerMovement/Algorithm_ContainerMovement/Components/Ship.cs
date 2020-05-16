using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public class Ship
	{
		public List<AssignedShipContainer> Containers = new List<AssignedShipContainer>();
		private readonly int maxWeight = 120000;

		public Size Size { get; set; }
		public float MaxWeight { get; set; }

		public Ship(Size size, float maxweight)
		{
			Size = size;
			MaxWeight = maxweight;
		}

		public void AddContainer(ShipContainer container, Point point)
		{
			if (CheckContainer(container, point))
			{
				Point position = point;
				AssignedShipContainer assignedContainer = new AssignedShipContainer(container.Weight, container.Temperature, container.Value, position);
				Containers.Add(assignedContainer);
			}
			else
			{

			}
		}

		public bool CheckContainer(ShipContainer container, Point point)
		{
			float totalWeight = Containers.Sum(x => x.Weight);
			
			if (Containers.Count != 0)
			{
				if (totalWeight + container.Weight >= MaxWeight)
					return false;
				if(!CheckDoubles(point))
					return false;
				if (container.Value >= 3000)
					if (!CheckNeighbors(point))
						return false;
				if (container.Temperature <= 15)
					if (!CheckRow(point))
						return false;
			}
			return true;
		}

		public bool CheckDoubles(Point point)
		{
			foreach (var container in Containers)
				if (point == container.Location)
					return false;

			return true;
		}

		public bool CheckRow(Point point)
		{
			if (point.Y == 0)
				return true;
			return false;
		}

		public bool CheckNeighbors(Point point)
		{
			int percentage = 3;
			int neighbors = 0;

			Point[] neighbours = new Point[]
			{
						new Point(0,-1),
						new Point(-1, 0),
						new Point(1, 0),
						new Point(0, 1)
			};

			foreach (var _point in neighbours)
			{
				Point checkingPoint = new Point(point.X + _point.X, point.Y + _point.Y);
				foreach (var assignedContainer in Containers)
				{
					if (checkingPoint == assignedContainer.Location)
						neighbors++;
				}
			}

			if (neighbors > percentage)
				return false;

			return true;
		}
	}
}
