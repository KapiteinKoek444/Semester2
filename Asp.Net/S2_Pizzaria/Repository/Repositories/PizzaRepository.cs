using Repository.DBCon;
using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class PizzaRepository
	{
		public PizzariaDB database;

		public PizzaRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public Pizza AddPizza(Pizza pizza)
		{
			database.Pizzas.Add(pizza);
			return pizza;
		}

		public void RemovePizza(Pizza pizza)
		{
			database.Pizzas.Remove(pizza);
		}

		public Pizza GetPizza(Pizza pizza)
		{
			var chosen = database.Pizzas.Where(x => x.Id == pizza.Id).FirstOrDefault();
			return chosen;
		}

		public List<Pizza> GetAllPizza()
		{
			return database.Pizzas.ToList();
		}
	}
}
