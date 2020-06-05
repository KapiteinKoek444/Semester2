using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Pizza_Components
{
	public class Sauce : EntityModelBase
	{
		public Guid BottomId { get; set; }
		public string Name { get; set; }
		public bool IsSpicy { get; set; }
		public double Price { get; set; }
	}
}
