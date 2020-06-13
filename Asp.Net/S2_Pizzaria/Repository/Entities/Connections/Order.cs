using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities.Connections
{
	public class Order : EntityModelBase
	{
		public Guid UserId { get; set; }
		public List<OrderRule> OrderRule { get; set; }
	}
}
