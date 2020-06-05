using Repository.DBCon;
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
	}
}
