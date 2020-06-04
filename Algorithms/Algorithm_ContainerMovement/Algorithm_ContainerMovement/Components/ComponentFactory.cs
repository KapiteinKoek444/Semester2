using Algorithm_ContainerMovement.Components.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public static class ComponentFactory
	{
		public static List<ShipContainer> GenerateRandomContainers(int amount)
		{
			Random rnd = new Random();
			List<ShipContainer> containers = new List<ShipContainer>();

			for (int i = 0; i < amount; i++)
			{
				ShipContainer container;
				float weight = rnd.Next(4, 10);
				weight = GetActualCount(weight);
				int type = rnd.Next(3);

				if (type == 1 )
					container = new ShipContainer(weight, Types.ContainerTypes.Cooled);
				else if (type == 2)
					container = new ShipContainer(weight, Types.ContainerTypes.Regular);
				else
					container = new ShipContainer(weight, Types.ContainerTypes.Valueable);

				containers.Add(container);
			}

			return containers;
		}

		public static List<ShipContainer> GenereateSpecificContainer(float weight, Types.ContainerTypes type, int amount)
		{
			List<ShipContainer> containers = new List<ShipContainer>();

			for (int i = 0; i < amount; i++)
			{
				ShipContainer container = new ShipContainer(weight, type);
				containers.Add(container);
			}

			return containers;
		}

		public static List<ShipContainer> MergeLists(List<ShipContainer> currentList, List<ShipContainer> mergeList)
		{
			if (currentList == null)
				return mergeList;
			else if (mergeList == null)
				return currentList;
			else
			{
				foreach (var container in mergeList)
				{
					currentList.Add(container);
				}
			}
			return currentList;
		}

		public static Ship GenerateCustomShip(Size size, float maxWeight)
		{
			return new Ship(size, GetActualCount(maxWeight));
		}

		public static Ship GenerateDefaultShip()
		{
			return new Ship(new Size(5, 3), GetActualCount(120));
		}

		public static float GetActualCount(float value)
		{
			return value * 1000;
		}
	}
}
