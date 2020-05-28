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
		public Panel pancakePanel = new Panel();

		public Pancake(decimal width, decimal height)
		{
			Width = width;
			Height = height;
		}

		public void SetPanel(int i, PancakePanel pnl)
		{
			pancakePanel.Location = new Point((pnl.Pnl.Width - pancakePanel.Width) / 2 , Convert.ToInt32((i * Height) - Height));
		}
	}
}
   