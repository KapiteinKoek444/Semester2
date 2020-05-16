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
	}
}
