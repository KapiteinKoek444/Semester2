using Circustrein_Matthijs.Components;
using CircusTrein_Opdracht.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein_UnitTest
{
	[TestClass]
	public class Animal_test
	{
		[TestMethod]
		public void ConvertNametoString_Test()
		{
			//Arrange
			Animal animal = new Animal(true, 5);
			int animalNumber = 1;

			//Act
			string actualString = animal.ConvertNametoString(animalNumber);

			//Assert
			Assert.AreEqual("Animal1: 5, Carnivore", actualString);
		}
	}
}

