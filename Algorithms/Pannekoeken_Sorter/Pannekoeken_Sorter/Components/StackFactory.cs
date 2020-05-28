using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pannekoeken_Sorter.Components
{
	public static class StackFactory
	{
		public static PancakeStack GenerateStack(int amount, PancakePanel pnl)
		{
			PancakeStack stack = new PancakeStack();
			stack.pnl = pnl;
			Random rnd = new Random();

			decimal height = (pnl.Pnl.Height / amount);

			for (int i = 0; i < amount; i++)
			{

					decimal w = rnd.Next(0, pnl.Pnl.Height);
					Pancake pancake = new Pancake(w, height);
					pancake.pancakePanel = GeneratePanel(pancake, pnl, i);
					stack.Pancakes.Add(pancake);
			}

			return stack;
		}

		public static Panel GeneratePanel(Pancake pancake, PancakePanel panel, int i )
		{
			Panel pnl = new Panel();
			pnl.Width = Convert.ToInt32(pancake.Width);
			pnl.Height = Convert.ToInt32(pancake.Height);
			pnl.Location = new Point((panel.Pnl.Width - pnl.Width) / 2, Convert.ToInt32((i * pancake.Height) - pancake.Height));
			pnl.BackColor = Color.Transparent;
			pnl.BorderStyle = BorderStyle.FixedSingle;
			return pnl;
		}
	}
}
