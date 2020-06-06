using Pannekoeken_Sorter.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
   