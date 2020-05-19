using Algorithm_ContainerMovement.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_ContainerMovement
{
	public partial class ContainerMovementForm : Form
	{
		Dock dock;

		public ContainerMovementForm()
		{
			InitializeComponent();
			dock = new Dock(); 
		}

		private void AddDefaultShip_Click(object sender, EventArgs e)
		{
			Ship ship = ComponentFactory.GenerateDefaultShip();
			dock.AddShip(ship);
			VisualizeShip();
		}

		private void VisualizeShip()
		{
			tControlShips.Controls.Clear();

			for (int i = 0; i < dock.Ships.Count; i++)
			{
				TabPage page = new TabPage();
				page.Name = $"ship {i}";
				page.Text = $"ship {i}";

				tControlShips.Controls.Add(page);
			}
		}
	}
}
