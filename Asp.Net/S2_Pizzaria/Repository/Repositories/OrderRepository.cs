using Repository.DBCon;
using Repository.Entities.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class OrderRepository
	{
		public PizzariaDB database;

		public OrderRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public Order GetOrder(Order order)
		{
			return database.Order.Where(x => x.Id == order.Id).FirstOrDefault();
		}
	}
}
