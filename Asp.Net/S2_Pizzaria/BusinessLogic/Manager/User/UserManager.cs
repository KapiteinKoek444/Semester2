using BusinessLogic.Models;
using BusinessLogic.Factory;
using System;
using System.Linq;
using Repository.UnitOfWork;

namespace BusinessLogic.Manager.User
{
	public static class UserManager
	{
		public static UserModel AddUser(UserModel model)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var user = UserFactory.ConvertUser(model);
			user.Id = Guid.NewGuid();
			unitOfWork.UserRepository.AddUser(user);
			return model;
		}

		public static UserModel GetUser(string username, string password)
		{
			UnitOfWorkRepository unitOfWork = new UnitOfWorkRepository();
			var user = unitOfWork.UserRepository.GetUser(username, password);
			var model = UserModelFactory.ConvertUser(user);
			return model;
		}
	}
}
