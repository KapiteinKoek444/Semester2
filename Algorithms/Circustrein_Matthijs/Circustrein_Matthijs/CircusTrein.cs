using Circustrein_Matthijs.Components;
using CircusTrein_Opdracht.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circustrein_Matthijs
{
	public partial class CircusTrein : Form
	{
		List<Animal> AllAnimalList = new List<Animal>();
		List<Wagon> AllWagonList = new List<Wagon>();

		public CircusTrein()
		{
			InitializeComponent();
		}


		//Functionality
		//Sorting animals
		private void Sort_Animals_Click(object sender, EventArgs e)
		{
			List<Animal> AnimalsSorted = AllAnimalList.OrderBy(animal => animal.Size).ThenBy(animal => animal.Carnivore).ToList();

			SetAnimalBox(AnimalsSorted);
		}

		//Distributing Animals
		private void Distribute_Animals_Click(object sender, EventArgs e)
		{
			AllWagonList = Components.WagonDistributor.Distribute(AllAnimalList);
			SetWagonBox(AllWagonList);
		}

		//Clear Animals
		private void ClearAnimals_Click(object sender, EventArgs e)
		{
			tboxAnimals.Text = "";
			AllAnimalList.Clear();
		}


		//Naming Components:
		//Animals
		private void SetAnimalBox(List<Animal> Animals)
		{
			tboxAnimals.Text = "";
			for (int i = 0; i < Animals.Count; i++)
				tboxAnimals.Text += Animals[i].ConvertNametoString(i + 1) + "\r\n";
		}
		//Wagons
		private void SetWagonBox(List<Wagon> Wagons)
		{
			tboxWagons.Text = "";

			for (int i = 0; i < Wagons.Count; i++)
			{ 
				List<string> wagonString = Wagons[i].ConvertWagonToString(i + 1);

				foreach (var str in wagonString)
					tboxWagons.Text += str + "\r\n";
			}
		}

		//Adding:
		//RandomAnimals
		private void AddAnimals_Click(object sender, EventArgs e)
		{
			int animalAmount = Convert.ToInt32(numUDAnimalCount.Value);

			List<Animal> ToBeAddedAnimals = AnimalFactory.GenerateRandomAnimals(animalAmount);
			AllAnimalList = AnimalFactory.MergeAnimalLists(AllAnimalList, ToBeAddedAnimals);

			SetAnimalBox(AllAnimalList);
		}

		//Specific Animal
		private void AddSpecificAnimal_Click(object sender, EventArgs e)
		{
			int animalSize = Convert.ToInt32(cBSize);
			int animalAmount = Convert.ToInt32(numUDAnimalCount.Value);
			bool Carnivore = true;

			if (cBCarnivore.SelectedIndex == 1 || cBCarnivore.SelectedIndex == 0)
				Carnivore = true;
			else if (cBCarnivore.SelectedIndex == 2)
				Carnivore = false;

			List<Animal> AnimalsToBeAdded = AnimalFactory.GenerateSelectAnimal(Carnivore, animalSize, animalAmount);
			AllAnimalList = AnimalFactory.MergeAnimalLists(AllAnimalList, AnimalsToBeAdded);

			SetAnimalBox(AllAnimalList);
		}

		//Add Herbivores
		private void AddHerbivores_Click(object sender, EventArgs e)
		{
			int animalAmount = Convert.ToInt32(numUDAnimalCount.Value);

			List<Animal> ToBeAddedAnimals = AnimalFactory.GenerateHerbivores(animalAmount);
			AllAnimalList = AnimalFactory.MergeAnimalLists(AllAnimalList, ToBeAddedAnimals);

			SetAnimalBox(AllAnimalList);
		}

		//Add Carnivores
		private void AddCarnivores_Click(object sender, EventArgs e)
		{
			int animalAmount = Convert.ToInt32(numUDAnimalCount.Value);

			List<Animal> ToBeAddedAnimals = AnimalFactory.GenerateCarnivores(animalAmount);
			AllAnimalList = AnimalFactory.MergeAnimalLists(AllAnimalList, ToBeAddedAnimals);

			SetAnimalBox(AllAnimalList);
		}
	}
}
