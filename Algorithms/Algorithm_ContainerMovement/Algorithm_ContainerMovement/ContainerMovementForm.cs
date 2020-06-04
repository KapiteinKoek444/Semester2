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

		private void Solve_Click(object sender, EventArgs e)
		{
			if (dock.SolveContainers())
				MessageBox.Show("Succes");
			else
				MessageBox.Show(dock.UnAssignedContainers.Count.ToString());
			
			LogUnAssignedContainer();
			LogShipContainers();
		}

		private void CreateRandomContainers_Click(object sender, EventArgs e)
		{
			dock.AddContainer(ComponentFactory.GenerateRandomContainers(10));
			LogUnAssignedContainer();
		}

		private void LogShipContainers()
		{
			console_Ship.Text = "";
			console_Ship.Text += "Ship 1:";
			console_Ship.Text += "\r\n";
			console_Ship.Text += dock.Ship.LeftWeight.ToString();
			console_Ship.Text += "\r\n";
			console_Ship.Text += dock.Ship.RightWeight.ToString();
			console_Ship.Text += "\r\n";
			console_Ship.Text += dock.Ship.Weight.ToString();
			console_Ship.Text += "\r\n";
			console_Ship.Text += dock.Ship.MaxWeight.ToString();

			foreach (var layer in dock.Ship.Layers)
				foreach (var Container in layer.Containers)
				{
					
				}
		}

		private void LogUnAssignedContainer()
		{
			console_Containers.Text = "";

			foreach (var con in dock.UnAssignedContainers)
			{
				console_Containers.Text += con.Type.ToString();
				console_Containers.Text += " "; 
				console_Containers.Text += con.Weight.ToString();
				console_Containers.Text += "\r\n";
			}
		}
	}
}
