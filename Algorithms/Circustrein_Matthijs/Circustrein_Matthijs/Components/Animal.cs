using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein_Opdracht.Components
{
	public class Animal
	{
		public bool Carnivore { get; set; }
		public int Size { get; set; }

		public Animal(bool carnivore, int size)
		{
			Carnivore = carnivore;
			Size = size;
		}

		public string ConvertNametoString(int i)
		{
			string name;

			if (Carnivore)
				name = $"Animal{i}: {Size}, Carnivore";
			else
				name = $"Animal{i}: {Size}, Herbivore";

			return name;
		}
	}
}
