using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Entities.Users
{
	public class Customer : User
	{
		public Adress Adress { get; set; }
		public Customer(string uName, string password, string email, Adress adress) : base(uName, password, email)
		{
			Adress = adress;
		}
	}
}
