using Circustrein_Matthijs.Components;
using CircusTrein_Opdracht.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein_UnitTest
{
	[TestClass]
	public class Wagon_Test
	{
		[TestMethod]
		public void AddAnimal_Test()
		{
			//Arrange
			int expectedAmount = 2;
			List<Animal> animalList = new List<Animal>();

			Animal animal2 = new Animal(false, 5);
			Animal animal1 = new Animal(true, 3);

			animalList.Add(animal1);
			animalList.Add(animal2);

			Wagon actualWagon = new Wagon();

			//Act
			foreach (var a in animalList)
				actualWagon.AddAnimal(a);

			//Assert
			Assert.AreEqual(expectedAmount, actualWagon.FilledAnimals.Count);
		}

		[TestMethod]
		public void CalculateCarryWeight_Test()
		{
			//Arrange
			int expectedCarryWeight = 5;
			Animal animal = new Animal(true, 5);

			Wagon wagon = new Wagon();
			wagon.AddAnimal(animal);

			//Act
			int actualCarryWeight = wagon.CalculateCarryweight();

			//Assert
			Assert.AreEqual(expectedCarryWeight, actualCarryWeight);
		}

		[TestMethod]
		public void CheckAnimal_Test()
		{
			//Arrange
			bool expectedOutcome = false;
			Wagon wagon = new Wagon();

			Animal carnivore = new Animal(true, 5);
			Animal herbivore = new Animal(false, 3);

			wagon.AddAnimal(carnivore);
			//Act
			bool actualOutcome = wagon.CheckAnimal(herbivore);

			//Assert
			Assert.AreEqual(expectedOutcome, actualOutcome);
		}

		[TestMethod]
		public void ConvertWagonToString_Test()
		{
			//Arrange
			string expectedString = "Wagon1 (9/10): ";

			Wagon wagon = new Wagon();
			
			Animal animal1 = new Animal(true, 1);
			Animal animal2 = new Animal(false, 5);
			Animal animal3 = new Animal(false, 3);


			wagon.AddAnimal(animal1);
			wagon.AddAnimal(animal2);
			wagon.AddAnimal(animal3);

			//Act
			List<string> actualString = wagon.ConvertWagonToString(1);

			//Assert
			Assert.AreEqual(expectedString, actualString[0]);
		}
	}
}

