using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannekoeken_Sorter
{
	public class Pancake
	{
		public decimal Width { get; set; }
		public decimal Height { get; set; }

		public Pancake(decimal width, decimal height)
		{
			Width = width;
			Height = height;
		}
	}
}
   