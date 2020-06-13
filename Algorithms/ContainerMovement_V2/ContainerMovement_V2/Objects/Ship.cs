using ContainerMovement_V2.Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerMovement_V2.Objects
{
	public class Ship
	{
		public readonly List<Stack> piles = new List<Stack>();

		public Size Size { get; set; }

		public int MaxWeight { get; set; }
		public int Weight { get; set; }

		public int LeftWeight { get; set; }
		public int RightWeight { get; set; }

		public Ship(Size size, int maxWeight)
		{
			Size = size;
			MaxWeight = maxWeight;


			//Adding 
			for (int i = 0; i < Size.Width; i++)
			{
				for (int j = 0; j < Size.Height; j++)
				{
					Stack pile = new Stack(new Point(i,j));
					piles.Add(pile);
				}
			}
		}

		public bool AddCooledContainer(ShipContainer c)
		{
			int amount = 0;
			while (true)
			{
				for (int j = 0; j < Size.Height; j++)
				{
					Point point = new Point(0, j);
					if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
					{
						if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
							return true;

						return false;
					}

					if (((j + 1) % 3) == 0)
						amount++;
				}
			}
		}

		public bool AddValueableContainer(ShipContainer c, Types.Sides side)
		{
			int amount = 0;
			while (true)
			{
				for (int i = 0; i < Size.Width; i++)
				{
					if (side == Types.Sides.Left)
					{
						Point point = new Point(i, 0);
						if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
						{
							if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
								return true;

							return false;
						}
					}

					if (side == Types.Sides.Right)
					{
						Point point = new Point(i, Size.Height - 1);
						if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
						{
							if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
								return true;

							return false;
						}
					}

					if (((i + 1) % 4) == 0)
						amount++;

				}
			}
		}

		public bool AddRegularContainer(ShipContainer c, Types.Sides side)
		{
			int amount = 0;
			while (true)
			{
				for (int i = 0; i < Size.Width; i++)
				{
					if (side == Types.Sides.Left)
					{
						Point point = new Point(i, 0);
						if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
						{
							if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
								return true;

							return false;
						}
					}

					if (side == Types.Sides.Right)
					{
						Point point = new Point(i, Size.Height - 1);
						if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
						{
							if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
								return true;

							return false;
						}
					}

					if (side == Types.Sides.Middle)
					{
						Point point = new Point(i, 1);
						if (piles.Where(x => x.Location == point).Sum(x => x.containers.Count) == amount)
						{
							if (piles.Where(x => x.Location == point).FirstOrDefault().AddContainer(c))
								return true;

							return false;
						}
					}

					if (((i + 1) % 4) == 0)
						amount++;
				}
			}
		}

		public bool CheckOccupation(Point point)
		{
			if (piles.Where(x => x.Location == point).Any())
				return false;

			return true;
		}

		public Types.Sides CheckBalance()
		{
			LeftWeight = 0;
			RightWeight = 0;
			Weight = 0;

			foreach (var stack in piles)
			{
				if (stack.Location.Y == 0)
					LeftWeight += stack.getWeight();

				if (stack.Location.Y == Size.Height - 1)
					RightWeight += stack.getWeight();

				Weight += stack.getWeight();
			}

			if (LeftWeight >= RightWeight * 1.2)
				return Types.Sides.Right;

			if (RightWeight >= LeftWeight * 1.2)
				return Types.Sides.Left;

			return Types.Sides.Middle;
		}
	}
}
