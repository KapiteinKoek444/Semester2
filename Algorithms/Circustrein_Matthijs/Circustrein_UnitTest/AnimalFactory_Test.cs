using Circustrein_Matthijs.Components;
using CircusTrein_Opdracht.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein_UnitTest
{
	[TestClass]
	public class AnimalFactory_Test
	{
		[TestMethod]
		public void GenerateRandomList_Test()
		{
			//Arrange
			int expectedAmount = 3;

			//Act
			List<Animal> actualAnimalList = AnimalFactory.GenerateRandomAnimals(expectedAmount);

			//Assert
			Assert.AreEqual(expectedAmount, actualAnimalList.Count);
		}

		[TestMethod]
		public void GenerateRandomCarnivores_Test()
		{
			//Arrange
			List<Animal> expectedCarnivoreList = new List<Animal>();
			int amount = 5;
			for (int i = 0; i < amount; i++)
			{
				Animal animal = new Animal(true, 3);
				expectedCarnivoreList.Add(animal);
			}

			//Act
			List<Animal> actualCarnivoreList = AnimalFactory.GenerateCarnivores(amount);

			//Assert
			Assert.AreEqual(expectedCarnivoreList[4].Carnivore, actualCarnivoreList[4].Carnivore);
		}

		[TestMethod]
		public void GenerateRandomHerbivores_Test()
		{
			//Arrange
			List<Animal> expectedHerbivoreList = new List<Animal>();
			int amount = 5;
			for (int i = 0; i < amount; i++)
			{
				Animal animal = new Animal(false, 3);
				expectedHerbivoreList.Add(animal);
			}

			//Act
			List<Animal> actualHerbivoreList = AnimalFactory.GenerateHerbivores(amount);

			//Assert
			Assert.AreEqual(expectedHerbivoreList[2].Carnivore, actualHerbivoreList[2].Carnivore);
		}

		[TestMethod]
		public void GenerateSelectedAnimals_Test()
		{
			//Arrange
			Animal expectedAnimal = new Animal(true, 3);

			int amount = 2;
			int size = 3;
			bool carnivore = true;

			//Act
			List<Animal> testingAnimals = AnimalFactory.GenerateSelectAnimal(carnivore, size, amount);

			//Assert
			Assert.AreEqual(expectedAnimal.Carnivore, testingAnimals[1].Carnivore);
			Assert.AreEqual(expectedAnimal.Size, testingAnimals[1].Size);
		}

		[TestMethod]
		public void MergeAnimalLists_Test()
		{
			//Arrange
			List<Animal> expectedAnimalList = new List<Animal>();
			Animal animal1 = new Animal(true, 5);
			Animal animal2 = new Animal(false, 1);
			expectedAnimalList.Add(animal1);
			expectedAnimalList.Add(animal2);

			List<Animal> animal1List = new List<Animal>();
			animal1List.Add(animal1);
			List<Animal> animal2List = new List<Animal>();
			animal2List.Add(animal2);

			//Act
			List<Animal> actualAnimalList = AnimalFactory.MergeAnimalLists(animal1List, animal2List);

			//Assert
			Assert.AreEqual(expectedAnimalList.Count, actualAnimalList.Count);
		}
	}
}
