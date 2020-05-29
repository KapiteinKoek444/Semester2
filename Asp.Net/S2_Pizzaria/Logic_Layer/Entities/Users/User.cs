using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Entities.Users
{
	public class User
	{
		public string UName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public Adress Adress { get; set; }
		public bool IsEmployee { get; set; }

		public User(string uName, string password, string email, Adress adress, bool isEmployee)
		{
			UName = uName;
			Password = password;
			Email = email;
			Adress = adress;
			IsEmployee = isEmployee;
		}
	}
}
