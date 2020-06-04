using Repository.Users;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Factory
{
	public static class UserModelFactory
	{
		public static List<User> ConvertUser(List<UserModel> userModels)
		{
			List<User> users = new List<User>();

			foreach (var userModel in userModels)
			{
				var userMod = ConvertUser(userModel);
				users.Add(userMod);
			}
			return users;
		}

		public static User ConvertUser(UserModel cusModel)
		{
			User customer = new User();
			return customer;
		}
	}
}
