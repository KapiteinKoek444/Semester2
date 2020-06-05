using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pannekoeken_Sorter.Components
{
	public class PancakePanel
	{
		public Panel Pnl = new Panel();

		public PancakePanel()
		{

		}

		public void SetPanel(int i, PancakePanel pnl)
		{
			pancakePanel.Location = new Point((pnl.Pnl.Width - pancakePanel.Width) / 2, Convert.ToInt32((i * Height) - Height));
		}
	}
}
