using BusinessLogic.Models;
using BusinessLogic.Factory;
using Repository.DBCon;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.UnitOfWork;

namespace BusinessLogic.Manager.User
{
	public static class UserManager
	{
		public static UserModel AddUser(UserModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var user = UserModelFactory.ConvertUser(model);
			user.Id = Guid.NewGuid();
			unitOfWork.UserRepository.AddUser(user);
			return model;
		}

		public static UserModel GetUser(string username, string password)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var user = unitOfWork.UserRepository.GetUser(username, password);
			var model = UserFactory.ConvertUser(user);
			return model;
		}
	}
}
