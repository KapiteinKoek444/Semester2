using Repository.DBCon;
using Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class UserRepository
	{
		public PizzariaDB database;

		public UserRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public User AddUser(User user)
		{
			database.Users.Add(user);
			database.SaveChanges();
			return user;
		}

		public User GetUser(string username, string password)
		{
			var user = database.Users.Where(x => x.UName == username && x.Password == password).SingleOrDefault();
			return user;
		}
	}
}
