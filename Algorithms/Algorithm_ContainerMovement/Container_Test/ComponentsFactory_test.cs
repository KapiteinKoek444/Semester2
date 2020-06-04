using Algorithm_ContainerMovement.Components;
using Algorithm_ContainerMovement.Components.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;

namespace Container_Test
{
	public class ComponentsFactory_test
	{
		[TestMethod]
		public void GenerateRandomContainers_Test()
		{
			//Arrange
			int amount = 10;

			//Act
			List<ShipContainer> containers = ComponentFactory.GenerateRandomContainers(10);

			//Assert
			Assert.AreEqual(amount, containers.Count);
		}

		[TestMethod]
		public void GenerateChosenContainer_Test()
		{
			//Arrange
			float weight = 10000;
			var type = Types.ContainerTypes.Cooled;
			//Act
			ShipContainer container = ComponentFactory.GenereateSpecificContainer(weight, type, 1)[0];

			//Assert
			Assert.AreEqual(weight, container.Weight);
			Assert.AreEqual(type, container.Type);
		}

		[TestMethod]
		public void MergeList_Test()
		{
			//Arrange
			float weight1 = 10000;
			var type1 = Types.ContainerTypes.Cooled;

			float weight2 = 20000;
			var type2 = Types.ContainerTypes.Valueable;

			List<ShipContainer> containers1 = ComponentFactory.GenereateSpecificContainer(weight1, type1, 5);
			List<ShipContainer> containers2 = ComponentFactory.GenereateSpecificContainer(weight2, type2, 5);

			//Act
			List<ShipContainer> MergedList = ComponentFactory.MergeLists(containers1, containers2);

			//Assert
			Assert.AreEqual(containers1.Count + containers2.Count, MergedList.Count);
		}

		[TestMethod]
		public void GenerateDefaultShip_Test()
		{
			//Arrange
			Ship ship;
			Size size = new Size(5, 3);

			//Act
			ship = ComponentFactory.GenerateDefaultShip();

			//Assert
			Assert.AreEqual(size, ship.Size);
		}
	}
}
