using Repository.DBCon;
using Repository.Entities.Pizza_Components.IngredientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class IngredientRepository
	{
		public PizzariaDB database;

		public IngredientRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public void AddIngredients(List<Ingredients> ingredients)
		{
			foreach (var ing in ingredients)
				AddIngredient(ing);
		}

		public void AddIngredient(Ingredients ingredient)
		{
			database.Ingredient.Add(ingredient);
			database.SaveChanges();
		}

		public void RemoveIngredient(Ingredients ingredient)
		{
			database.Ingredient.Remove(ingredient);
		}

		public List<Ingredients> GetAllIngredients()
		{
			var ingredients = database.Ingredient.ToList();
			return ingredients;
		}
	}
}
