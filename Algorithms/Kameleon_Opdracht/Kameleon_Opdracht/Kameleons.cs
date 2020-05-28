﻿using Kameleon_Opdracht.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kameleon_Opdracht
{
	public partial class Kameleons : Form
	{
		List<Chameleon> chameleons = new List<Chameleon>();

		public Kameleons()
		{
			InitializeComponent();
		}

		private void Start_Simulation_Click(object sender, EventArgs e)
		{
			int red = Convert.ToInt32(numUDRedChameleon.Value);
			int blue = Convert.ToInt32(numUDBlueChameleon.Value);
			int green = Convert.ToInt32(numUDGreenChameleon.Value);

			chameleons = CreateChameleons.GenerateChameleons(red, blue, green);

			foreach (var chameleon in chameleons)
				pnlVisualisation.Controls.Add(chameleon.Body);

			tmrMain.Enabled = true;
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			tmrMain.Enabled = false;
			pnlVisualisation.Controls.Clear();
			chameleons.Clear();
			tboxCoordinates.Text = "";
		}

		private void TmrMain_Tick(object sender, EventArgs e)
		{
			tboxCoordinates.Text = "";
			
			for (int i = 0; i < chameleons.Count; i++)
			{
				chameleons[i].MoveLocation();
				chameleons[i].CheckBorders(pnlVisualisation);

				for (int j = 0; j < chameleons.Count; j++)
				{
					chameleons[i].ColorCheck(chameleons[j]);
				}

				tboxCoordinates.Text += $"Chameleon{i}:" + "\r\n";
				tboxCoordinates.Text += $"   {chameleons[i].Body.Location.X}, {chameleons[i].Body.Location.Y}" + "\r\n";
				tboxCoordinates.Text += $"   {chameleons[i].Body.BackColor}" + "\r\n";
			}

		}
	}
}