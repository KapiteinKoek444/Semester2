using Repository.DBCon;
using Repository.Entities.Pizza_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class SauceRepository
	{
		public PizzariaDB database;

		public SauceRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public Sauce AddSauce(Sauce sauce)
		{
			database.Sauce.Add(sauce);
			return sauce;
		}

		public void RemoveSauce(Sauce sauce)
		{
			database.Sauce.Remove(sauce);
		}

		public Sauce GetSauce(Sauce sauce)
		{
			var chosen = database.Sauce.Where(x => x.Id == sauce.Id).FirstOrDefault();
			return chosen;
		}

		public List<Sauce> GetAllSauce()
		{
			return database.Sauce.ToList();
		}
	}
}
