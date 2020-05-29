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
		public readonly ContainerLayer[] Layers = new ContainerLayer[3];
		private readonly float offset = 1000;

		public Size Size { get; set; }
		public float MaxWeight { get; set; }
		public float Weight { get; set; }
		public float LeftWeight { get; set; }
		public float RightWeight { get; set; }
		public float Balance { get; set; }

		public Ship(Size size, float maxweight)
		{
			Size = size;
			MaxWeight = maxweight;
		}

		public bool CheckContainerFit(ShipContainer container, Point point, int height)
		{
			if (CheckWeight(container))
				return false;

			if (height > 0)
				if (!CheckContainersBelow(point, height))
					return false;
			foreach (var layer in Layers)
				if (layer.Containers.Count == 0)
					return true;

			if (!CheckOccupation(point, height))
				return false;
			if (container.Valueable)
				if (!CheckNeighbors(point, height))
					return false;
			if (container.Cooled)
				if (!CheckRow(point))
					return false;

		}

		private bool CheckContainersBelow(Point point, int height)
		{
			foreach (var container in Layers[height - 1].Containers)
				if (container.Location == point)
					return true;

			return false;
		}

		private bool CheckNeighbors(Point point, int height)
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
				foreach (var assignedContainer in Layers[height].Containers)
				{
					if (checkingPoint == assignedContainer.Location)
						neighbors++;
				}
			}

			if (neighbors > percentage)
				return false;

			return true;
		}

		private bool CheckOccupation(Point point, int height)
		{
			foreach (var container in Layers[height].Containers)
			{
				if (container.Location == point)
					return false;
			}
			return true;
		}

		private bool CheckRow(Point point)
		{
			if (point.Y == 0)
				return true;
			return false;
		}

		private bool CheckWeight(ShipContainer container)
		{
			return (container.Weight + Weight > MaxWeight);
		}

		private bool CheckWeightBalance()
		{
			foreach (var layer in Layers)
				foreach (var container in layer.Containers)
					if (container.Location.Y == 0)
						LeftWeight += container.Weight;
					else if (container.Location.Y == 2)
						RightWeight += container.Weight;

			Balance = RightWeight - LeftWeight;

			if (Balance > offset || (Balance * -1) > offset)
			{
				return false;
			}

			return true;
		}
	}
}
