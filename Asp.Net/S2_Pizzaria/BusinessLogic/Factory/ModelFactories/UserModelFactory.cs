using Repository.Users;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.DBCon;

namespace BusinessLogic.Factory
{
	public static class UserModelFactory
	{
		public static List<UserModel> ConvertUser(List<User> users)
		{
			List<UserModel> userModels = new List<UserModel>();

			foreach (var user in users)
			{
				var userMod = ConvertUser(user);
				userModels.Add(userMod);
			}
			return userModels;
		}

		public static UserModel ConvertUser(User user)
		{
			UserModel customerMod = new UserModel
			{
				Id = user.Id,
				UName = user.UName,
				Password = user.Password,
				Email = user.Email,
				ZipCode = user.ZipCode,
				HouseNr = user.HousNr,
				IsEmployee = user.IsEmployee
			};

			return customerMod;
		}
	}
}
