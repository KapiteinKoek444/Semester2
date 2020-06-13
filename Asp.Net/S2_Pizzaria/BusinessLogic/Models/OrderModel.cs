using BusinessLogic.Models.Base;
using Repository.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
	public class OrderModel : EntityModelBase
	{
		public User User { get; set; }
	}
}
