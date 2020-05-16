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
		List<Pancake> pancakeList = new List<Pancake>();
		List<Panel> prevPanels = new List<Panel>();
		Random rnd = new Random();

		public Pancakes()
		{
			InitializeComponent();
		}

		public void SetValues()
		{
			decimal height = 1 * (pnlPancakes.Height / numUDCount.Value);

			for (int i = 0; i < numUDCount.Value; i++)
			{
				decimal w = rnd.Next(0, pnlPancakes.Width);
				Pancake pancake = new Pancake(w, height);
				pancakeList.Add(pancake);
			}
			Visualize(pancakeList);
		}

		private void Visualize(List<Pancake> pancakes)
		{
			if (prevPanels.Count != 0)
			{
				for (int i = 0; i < prevPanels.Count; i++)
				{
					Panel pnl = prevPanels[i];
					pnlPancakes.Controls.Remove(pnl);
				}
			}
			for (int i = 0; i < pancakes.Count; i++)
			{
				Pancake pancake = pancakes[i];
				Panel pnl = new Panel();
				pnl.Width = Convert.ToInt32(pancake.Width);
				pnl.Height = Convert.ToInt32(pancake.Height);
				pnl.Location = new Point((pnlPancakes.Width - pnl.Width) / 2, Convert.ToInt32(pancake.Height + (i * pancake.Height)));
				pnl.BackColor = Color.Transparent;
				pnl.BorderStyle = BorderStyle.FixedSingle;
				prevPanels.Add(pnl);
				pnlPancakes.Controls.Add(pnl);
			}
		}

		private int IndexOfBiggest(List<Pancake> pancakes, int n)
		{
			int index = 0;

			for (int i = 0; i < n; i++)
			{
				if (pancakes[index].Width < pancakes[i].Width)
				{
					index = i;
				}
			}

			return index;
		}

		private void Flip(List<Pancake> pancakes, int end)
		{
			for (var start = 0; start < end; start++, end--)
			{
				var startpoint = pancakes[start];
				pancakes[start] = pancakes[end];
				pancakes[end] = startpoint;
			}
		}

		private List<Pancake> Sort(List<Pancake> pancakes)
		{
			for (int arraylength = pancakes.Count - 1; arraylength >= 0; arraylength--)
			{
				int indexOfMax = IndexOfBiggest(pancakes, arraylength);
				if (indexOfMax != arraylength)
				{
					Flip(pancakes, indexOfMax);
					Flip(pancakes, arraylength);
				}
			}

			return pancakes;
		}

		private void SolveButton_Click(object sender, EventArgs e)
		{
			Visualize(Sort(pancakeList));
		}
		private void Set_Pancakes_Click(object sender, EventArgs e)
		{
			SetValues();
		}
	}
}
