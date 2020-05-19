using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircusTrein_Opdracht.Components
{
	public class Wagon
	{
		public readonly List<Animal> FilledAnimals = new List<Animal>();
		private readonly int MaxWeight;

		public Wagon(int weight = 10)
		{
			MaxWeight = weight;
		}

		public void AddAnimal(Animal animal)
		{
			if (CheckAnimal(animal))
			{
				FilledAnimals.Add(animal);
			}
		}

		public bool CheckAnimal(Animal newAnimal)
		{
			if (FilledAnimals.Sum(animal => animal.Size) + newAnimal.Size > MaxWeight)
				return false;

			if (FilledAnimals.Any(animal => animal.Carnivore))
				return !(newAnimal.Carnivore || newAnimal.Size <= FilledAnimals.First(animal => animal.Carnivore).Size);

			if (FilledAnimals.Count > 0)
				return !(newAnimal.Carnivore && newAnimal.Size > FilledAnimals.Min(animal => animal.Size));

			return true;
		}

		public List<string> ConvertWagonToString(int i)
		{
			List<string> wagonString = new List<string>();

			int amount = CalculateCarryweight();

			string wagonName = $"Wagon{i} ({amount}/10): ";
			wagonString.Add(wagonName);

			for (int j = 0; j < FilledAnimals.Count; j++)
			{
				string animal;
				animal = "   -" + FilledAnimals[j].ConvertNametoString(j + 1);
				wagonString.Add(animal);
			}

			return wagonString;
		}

		public int CalculateCarryweight()
		{
			int count = 0;

			foreach (var a in FilledAnimals)
				count += a.Size;

			return count;
		}
	}
}
