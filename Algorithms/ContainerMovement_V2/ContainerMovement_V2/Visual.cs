using ContainerMovement_V2.Factories;
using ContainerMovement_V2.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerMovement_V2
{
	public partial class containerMovementForm : Form
	{
		Dock dock;
		TextBox[] boxes = new TextBox[12];

		public containerMovementForm()
		{
			InitializeComponent();

			dock = new Dock();

			boxes[0] = tboxPile1;
			boxes[1] = tboxPile5;
			boxes[2] = tboxPile9;
			boxes[3] = tboxPile2;
			boxes[4] = tboxPile6;
			boxes[5] = tboxPile10;
			boxes[6] = tboxPile3;
			boxes[7] = tboxPile7;
			boxes[8] = tboxPile11;
			boxes[9] = tboxPile4;
			boxes[10] = tboxPile8;
			boxes[11] = tboxPile12;
		}

		private void AddContainers_Click(object sender, EventArgs e)
		{
			int amount = (int)numUDContainerAmount.Value;
			dock.AddContainer(ContainerFactory.GenerateRandomContainers(amount));

			VisualiseContainers();
		}

		private void SolveDock_Click(object sender, EventArgs e)
		{
			if (dock.AssignContainers())
				MessageBox.Show("succes");
			else
				MessageBox.Show("Failed");

			VisualiseContainers();
		}

		public void VisualiseContainers()
		{
			tboxUnassignedContainer.Text = " ";

			foreach (var container in dock.unassignedContainers)
			{
				tboxUnassignedContainer.Text += container.Type.ToString();
				tboxUnassignedContainer.Text += " ";
				tboxUnassignedContainer.Text += container.Weight.ToString();
				tboxUnassignedContainer.Text += "\r\n";
			}

			for (int i = 0; i < dock.Ship.piles.Count; i++)
			{
				boxes[i].Text = " ";
				foreach (var container in dock.Ship.piles[i].containers)
				{
					boxes[i].Text += container.Type.ToString();
					boxes[i].Text += " ";
					boxes[i].Text += container.Weight.ToString();
					boxes[i].Text += "\r\n";
				}
			}

			tboxShipInfo.Text = " ";
			tboxShipInfo.Text += dock.Ship.Weight.ToString();
			tboxShipInfo.Text += "\r\n";
			tboxShipInfo.Text += dock.Ship.LeftWeight.ToString();
			tboxShipInfo.Text += "\r\n";
			tboxShipInfo.Text += dock.Ship.RightWeight.ToString();
			tboxShipInfo.Text += "\r\n";
		}
	}
}
