using Circustrein_Matthijs;
using Circustrein_Matthijs.Components;
using CircusTrein_Opdracht.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein_UnitTest
{
	[TestClass]
	public class WagonDistributor_Test
	{
		[TestMethod]
		public void Distribute_Test()
		{
			//Arrange
			int expectedWagonAmount = 5;

			List<Animal> DistributedAnimals = AnimalFactory.GenerateCarnivores(expectedWagonAmount);

			//Act
			List<Wagon> actualWagonList = WagonDistributor.Distribute(DistributedAnimals);

			//Assert
			Assert.AreEqual(expectedWagonAmount, actualWagonList.Count);
		}

		[TestMethod]
		public void AllAnimalsAdded_Test()
		{
			//Arrange
			int excpected = 10;

			List<Wagon> wagons = new List<Wagon>();
			List<Animal> animals = AnimalFactory.GenerateRandomAnimals(10);
			//Act
			wagons = WagonDistributor.Distribute(animals);
			int actual = 0;
			foreach (var wagon in wagons)
			{
				actual += wagon.FilledAnimals.Count;
			}

			//Assert
			Assert.AreEqual(excpected, actual);
		}

	}
}
