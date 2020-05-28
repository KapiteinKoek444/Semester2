using Pannekoeken_Sorter.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pannekoeken_Sorter
{
	public partial class Pancakes : Form
	{
		PancakeStack stack;
		PancakePanel pnl = new PancakePanel();

		public Pancakes()
		{
			InitializeComponent();
			pnl.Pnl = pnlPancakes;
		}

		private void SolveButton_Click(object sender, EventArgs e)
		{
			stack.AutoSort();
			Visualise(stack.Pancakes);
		}

		private void Set_Pancakes_Click(object sender, EventArgs e)
		{
			stack = StackFactory.GenerateStack(Convert.ToInt32(numUDCount.Value), pnl);
			Visualise(stack.Pancakes);
		}

		private void Visualise(List<Pancake> pancakes)
		{
			pnl.Pnl.Controls.Clear();
			foreach (var pan in pancakes)
			{
				pnl.Pnl.Controls.Add(pan.pancakePanel);
			}
		}
	}
}
