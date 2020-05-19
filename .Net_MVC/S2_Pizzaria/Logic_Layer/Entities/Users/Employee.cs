using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Entities.Users
{
	public class Employee : User
	{
		public Employee(string uName, string password, string email) : base(uName, password, email)
		{
		}
	}
}
