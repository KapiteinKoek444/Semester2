using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_ContainerMovement.Components
{
	public class Ship
	{
		public readonly List<AssignedShipContainer> Containers = new List<AssignedShipContainer>();

		public Size Size { get; set; }
		public float MaxWeight { get; set; }

		public Ship(Size size, float maxweight)
		{
			Size = size;
			MaxWeight = maxweight;
		}

		public bool AddContainer(ShipContainer container, Point point)
		{
			if (CheckContainer(container, point))
			{
				Point position = point;
				AssignedShipContainer assignedContainer = new AssignedShipContainer(container.Weight, container.Cooled, container.Valueable, position);
				Containers.Add(assignedContainer);
				return true;
			}
			else
			{
				MessageBox.Show("Error, could not add container");
				return false;
			}
		}

		private bool CheckContainer(ShipContainer container, Point point)
		{
			float totalWeight = Containers.Sum(x => x.Weight);
			
			if (Containers.Count != 0)
			{
				if (totalWeight + container.Weight >= MaxWeight)
					return false;
				if(!CheckDoubles(point))
					return false;
				if (container.Valueable)
					if (!CheckNeighbors(point))
						return false;
				if (container.Cooled)
					if (!CheckRow(point))
						return false;
			}
			return true;
		}

		private bool CheckDoubles(Point point)
		{
			foreach (var container in Containers)
				if (point == container.Location)
					return false;

			return true;
		}

		private bool CheckRow(Point point)
		{
			if (point.Y == 0)
				return true;
			return false;
		}

		private bool CheckNeighbors(Point point)
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
