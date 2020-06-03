using CircusTrein_Opdracht.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein_Matthijs.Components.FoodEnum;

namespace Circustrein_Matthijs.Components
{
	public class AnimalFactory
	{

		public static List<Animal> GenerateRandomAnimals(int amount)
		{
			List<Animal> animals = new List<Animal>();
			Random rnd = new Random();

			for (int i = 0; i < amount; i++)
			{
				Animal animal;

				int chapping = rnd.Next(2);
				int size = rnd.Next(4);

				if (size == 0)
					size = 1;
				else if (size == 1)
					size = 3;
				else
					size = 5;

				if (chapping == 0)
					animal = new Animal(foodType.Carnivore , size);
				else
					animal = new Animal(foodType.Herbivore, size);

				animals.Add(animal);
			}

			return animals;
		}

		public static List<Animal> GenerateCarnivores(int amount)
		{
			List<Animal> animals = new List<Animal>();
			Random rnd = new Random();

			for (int i = 0; i < amount; i++)
			{
				int size = rnd.Next(4);

				if (size == 0)
					size = 1;
				else if (size == 1)
					size = 3;
				else
					size = 5;

				Animal animal = new Animal(foodType.Carnivore , size);
				animals.Add(animal);
			}

			return animals;
		}

		public static List<Animal> GenerateHerbivores(int amount)
		{
			List<Animal> animals = new List<Animal>();
			Random rnd = new Random();

			for (int i = 0; i < amount; i++)
			{
				int size = rnd.Next(4);

				if (size == 0)
					size = 1;
				else if (size == 1)
					size = 3;
				else
					size = 5;

				Animal animal = new Animal(foodType.Herbivore, size);
				animals.Add(animal);
			}

			return animals;
		}

		public static List<Animal> GenerateSelectAnimal(foodType type, int Size, int amount)
		{
			List<Animal> Animals = new List<Animal>();

			for (int i = 0; i < amount; i++)
			{
				Animal animal = new Animal(type, Size);
				Animals.Add(animal);
			}

			return Animals;
		}

		public static List<Animal> MergeAnimalLists(List<Animal> currentAnimals, List<Animal> addedAnimals)
		{
			if (currentAnimals == null)
				return addedAnimals;
			else if(addedAnimals == null)
				return currentAnimals;
			else
			{
				List<Animal> mergedAnimals = new List<Animal>();

				foreach (var a in currentAnimals)
					mergedAnimals.Add(a);
				foreach (var a in addedAnimals)
					mergedAnimals.Add(a);

				return mergedAnimals;
			}
		}
	}
}
