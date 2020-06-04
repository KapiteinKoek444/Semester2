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
		public readonly ContainerLayer[] Layers;
		private readonly float MinimumWeight;

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
			MinimumWeight = MaxWeight * 0.5f;


			Layers = new ContainerLayer[3];
			SetLayers();
		}

		private void SetLayers()
		{
			for (int i = 0; i < Layers.Length; i++)
			{
				Layers[i] = new ContainerLayer();
			}
		}

		//Adding containers
		//Cooled
		public bool AddCooledContainer(ShipContainer c)
		{
			for (int i = 0; i < Layers.Length -1; i++)
			{
				for (int j = 0; j < Size.Width; j++)
				{
					Point pnt = new Point(0, j);
					int height = i;
					if (CheckOccupation(pnt, height))
					{
						AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Type, pnt, height);
						Layers[height].Containers.Add(cnt);
						return true;
					}
				}
			}

			return false;
		}

		//Valueable
		public bool AddValueableContainer(ShipContainer c, int side)
		{
			for (int z = 0; z < Layers.Length -1; z++)
			{
				for (int x = 0; x < Size.Width; x++)
				{
					for (int y = 0; y < Size.Height; y++)
					{
						Point pnt = new Point(x, y);
						int height = z;
						if (pnt.Y == side)
						{
							if (CheckOccupation(pnt, height))
							{
								if (CheckNeighbors(pnt, height))
								{
									AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Type, pnt, height);
									Layers[height].Containers.Add(cnt);
									return true;
								}
							}
						}
					}
				}
			}

			return false;
		}

		//Regular
		public bool AddNormalContainer(ShipContainer c, int side)
		{
			for (int z = 0; z < Layers.Length - 1; z++)
			{
				for (int x = 0; x < Size.Width; x++)
				{
					for (int y = 0; y < Size.Height; y++)
					{
						Point pnt = new Point(x, y);

						if (pnt.Y == side)
						{
							int height = z;
							if (CheckOccupation(pnt, height))
							{
								AssignedShipContainer cnt = new AssignedShipContainer(c.Weight, c.Type, pnt, height);
								Layers[height].Containers.Add(cnt);
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		public int CheckBalance()
		{
			LeftWeight = 0;
			RightWeight = 0;

			foreach (var layer in Layers)
			{
				foreach (var container in layer.Containers.Where(x => x.Location.Y == 0))
					LeftWeight += container.Weight;

				foreach (var container in layer.Containers.Where(x => x.Location.Y == 2))
					RightWeight += container.Weight;
			}

			if (LeftWeight < RightWeight * 1.1)
				return 0;

			if (RightWeight < LeftWeight * 1.1)
				return 2;

			return 1;
		}

		public float CheckCooledBalance()
		{
			foreach (var layer in Layers)
			{
				foreach (var container in layer.Containers.Where(x => x.Location.Y == 0))
				{
					LeftWeight += container.Weight;
				}
			}

			return LeftWeight;
		}

		private bool CheckNeighbors(Point point, int height)
		{
			int percentage = 1;
			int neighbors = 0;

			Point[] neighbours = new Point[]
			{
						new Point(0,-1),
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
			if (Layers[height] == null)
				return true;

			foreach (var container in Layers[height].Containers)
			{
				if (container.Location == point)
					return false;
			}
			return true;
		}

		public void SetWeight()
		{
			foreach (var layer in Layers)
				foreach (var container in layer.Containers)
					Weight += container.Weight;
		}
	}
}
