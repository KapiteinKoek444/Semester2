using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_ContainerMovement.Components
{
	public class Ship
	{
		public readonly ContainerLayer[] Layers = new ContainerLayer[3];
		private readonly float offset;

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
			offset = 0.20f * MaxWeight;
		}

		public bool MinimumWeight()
		{
			float weight = 0f;

			foreach (var Layer in Layers)
			{
				foreach (var container in Layer.Containers)
				{
					weight += container.Weight;
				}
			}

			if(weight <= 0.5f * MaxWeight)
				return false;

			return true;
		}

		public bool AddCooledContainer(ShipContainer c)
		{
			for (int i = 0; i < Size.Width; i++)
			{
				for (int j = 0; j < Layers.Length; j++)
				{
					Point pnt = new Point(0, i);
					int height = j;
					if (CheckOccupation(pnt, height))
					{
						AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Cooled, c.Valueable, pnt, height);
						Layers[height].Containers.Add(cnt);
						return true;
					}
				}
			}

			return false;
		}

		public bool AddNormalContainer(ShipContainer c)
		{
			for (int x = 0; x < Size.Width; x++)
			{
				for (int y = 0; y < Size.Height; y++)
				{
					for (int z = 0; z < Layers.Length; z++)
					{
						Point pnt = new Point(x, y);
						int height = z;
						if (CheckOccupation(pnt, height))
						{
							AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Cooled, c.Valueable, pnt, height);
							Layers[height].Containers.Add(cnt);
							return true;
						}
					}
				}
			}

			return false;
		}

		public bool AddValueableContainer(ShipContainer c)
		{
			for (int x = 0; x < Size.Width; x++)
			{
				for (int y = 0; y < Size.Height; y++)
				{
					for (int z = 0; z < Layers.Length; z++)
					{
						Point pnt = new Point(x, y);
						int height = z;
						if (CheckOccupation(pnt, height))
						{
							if (CheckNeighbors(pnt, height))
							{
								AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Cooled, c.Valueable, pnt, height);
								Layers[height].Containers.Add(cnt);
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		public bool AddContainer(ShipContainer container, Point point, int height)
		{
			if (CheckContainerFit(container, point, height))
			{
				AssignedShipContainer assignedContainer = new AssignedShipContainer(container.Weight, container.Cooled, container.Valueable, point, height);
				Layers[height].Containers.Add(assignedContainer);
				return true;
			}
			else
			{
				MessageBox.Show("Container could not be added");
				return false;
			}

		}

		public bool CheckBalance()
		{
			foreach (var Layer in Layers)
			{
				foreach (var container in Layer.Containers)
				{
					if(container.Location.Y == 0)
					{
						container.Weight += LeftWeight;
					}
					else if(container.Location.Y == 2)
					{
						container.Weight += RightWeight;
					}
				}
			}

			if((LeftWeight - (LeftWeight * 0.2f)) > RightWeight || (RightWeight - (RightWeight * 0.2f)) > LeftWeight)
				return false; 

			return true;
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


			return true;
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
