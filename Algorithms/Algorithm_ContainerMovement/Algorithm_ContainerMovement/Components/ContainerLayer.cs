using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_ContainerMovement.Components
{
	public class ContainerLayer
	{
		public List<AssignedShipContainer> Containers;

		public ContainerLayer()
		{
			Containers = new List<AssignedShipContainer>();
		}
	}
}
