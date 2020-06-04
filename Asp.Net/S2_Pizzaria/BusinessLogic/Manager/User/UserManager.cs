using BusinessLogic.Models;
using BusinessLogic.Factory;
using Repository.DBCon;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Manager.User
{
	public class UserManager
	{
		PizzariaDB db = new PizzariaDB();
		UserRepository repository;
		UserModel User = new UserModel();

		public UserManager()
		{
			repository = new UserRepository(db);
		}

		public void AddUser(UserModel _user)
		{
			UserModel user = UserFactory.ConvertUser(repository.AddUser(UserModelFactory.ConvertUser(_user)));
			User = user;
		}

		public void GetUser(string username, string password)
		{
			UserModel user = UserFactory.ConvertUser(repository.GetUser(username, password));
			User = user;
		}
	}
}
