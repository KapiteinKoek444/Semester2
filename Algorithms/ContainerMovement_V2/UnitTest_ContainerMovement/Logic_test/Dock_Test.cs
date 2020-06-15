using ContainerMovement_V2.Factories;
using ContainerMovement_V2.Logic;
using ContainerMovement_V2.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UnitTest_ContainerMovement.Logic_test
{
	[TestClass]
	public class Dock_Test
	{
		Dock Test_Dock = new Dock();

		[TestMethod]
		public void AddContainer_Test()
		{
			//Arrange
			List<ShipContainer> expected = ContainerFactory.GenereateSpecificContainer(7000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Cooled, 10);

			//Act
			Test_Dock.AddContainer(expected);

			//Assert
			Assert.AreEqual(expected.Count, Test_Dock.unassignedContainers.Count);
		}

		[TestMethod]
		public void AddCooledContainers_Test()
		{
			//Arrange
			List<ShipContainer> expected = ContainerFactory.GenereateSpecificContainer(7000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Cooled, 10);

			//Act
			Test_Dock.AddCooledContainers(expected);
			var actual = Test_Dock.Ship.piles.Where(x => x.containers.Count > 0).ToList();

			//Assert
			Assert.AreEqual(expected.Count, actual.Sum(x => x.containers.Count));
		}

		[TestMethod]
		public void AddCooledContainers_Test_02()
		{
			//Arrange
			List<ShipContainer> CooledCon = ContainerFactory.GenereateSpecificContainer(7000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Cooled, 10);
			Test_Dock.AddCooledContainers(CooledCon);
			int expectedAmount = 10;

			//Act
			var actual = Test_Dock.Ship.piles.Where(x => x.containers.Count > 0 && x.Location.X == 0).ToList();

			//Assert
			Assert.AreEqual(expectedAmount, actual.Sum(x => x.containers.Count));
		}

		[TestMethod]
		public void AddRegularContainers_Test()
		{
			//Arrange
			List<ShipContainer> expected = ContainerFactory.GenereateSpecificContainer(7000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Regular, 10);

			//Act
			Test_Dock.AddRegularContainers(expected);
			var actual = Test_Dock.Ship.piles.Where(x => x.containers.Count > 0).ToList();

			//Assert
			Assert.AreEqual(expected.Count, actual.Sum(x => x.containers.Count));
		}

		[TestMethod]
		public void AddValueableContainers_Test()
		{
			//Arrange
			List<ShipContainer> expected = ContainerFactory.GenereateSpecificContainer(7000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Valueable, 10);

			//Act
			Test_Dock.AddValueableContainers(expected);
			var pilesList = Test_Dock.Ship.piles.Where(x => x.containers.Count > 0).ToList();
			List<ShipContainer> actual = new List<ShipContainer>();
			foreach (var pile in pilesList)
				foreach (var con in pile.containers)
					actual.Add(con);

			//Assert
			Assert.AreEqual(expected.Count, actual.Count);
		}

		[TestMethod]
		public void SolveContainer_Test()
		{
			//Arrange
			List<ShipContainer> Containers = ContainerFactory.GenerateRandomContainers(20);
			Test_Dock.AddContainer(Containers);
			bool expected = true;

			//Act
			bool actual = Test_Dock.AssignContainers();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CheckSides_Test()
		{
			//Arrange
			ShipContainer con = ContainerFactory.GenereateSpecificContainer(70000, ContainerMovement_V2.Objects.Enums.Types.ContainerTypes.Regular, 1)[0];
			
			Ship expected = ShipFactory.GenerateDefaultShip();
			expected.AddRegularContainer(con, ContainerMovement_V2.Objects.Enums.Types.Sides.Left);
			expected.AddRegularContainer(con, ContainerMovement_V2.Objects.Enums.Types.Sides.Right);
			expected.CheckBalance();

			Test_Dock.Ship.AddRegularContainer(con, ContainerMovement_V2.Objects.Enums.Types.Sides.Left);

			//Act
			Test_Dock.CheckSides(con);
			var actual = Test_Dock.Ship;
			actual.CheckBalance();

			//Assert
			Assert.AreEqual(expected.LeftWeight, actual.LeftWeight);
			Assert.AreEqual(expected.RightWeight, actual.RightWeight);
		}
	}
}
