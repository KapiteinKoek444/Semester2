using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kameleon_Opdracht.Components
{
	public class CreateChameleons
	{

		public static List<Chameleon> GenerateChameleons(int red, int blue, int green)
		{
			Random rnd = new Random();

			List<Chameleon> chameleons = new List<Chameleon>();

			for (int r = 0; r < red; r++)
			{
				Point speed = new Point(rnd.Next(1, 4), rnd.Next(1, 4));
				Chameleon chameleonRed = new Chameleon(CreatePanel(Color.Red, rnd), speed);
				chameleons.Add(chameleonRed);
			}

			for (int b = 0; b < blue; b++)
			{
				Point speed = new Point(rnd.Next(1, 4), rnd.Next(1, 4));
				Chameleon chameleonBlue = new Chameleon(CreatePanel(Color.Blue, rnd), speed);
				chameleons.Add(chameleonBlue);
			}

			for (int g = 0; g < green; g++)
			{
				Point speed = new Point(rnd.Next(1, 4), rnd.Next(1, 4));
				Chameleon chameleonGreen = new Chameleon(CreatePanel(Color.Green, rnd), speed);
				chameleons.Add(chameleonGreen);
			}

			return chameleons;
		}

		public static Panel CreatePanel(Color color, Random rnd)
		{
			Panel pnl = new Panel();
			pnl.Location = new Point(rnd.Next(1, 700 - 21), rnd.Next(1, 600 - 21));
			pnl.Size = new Size(20, 20);
			pnl.BackColor = color;

			return pnl;
		}
	}
}
