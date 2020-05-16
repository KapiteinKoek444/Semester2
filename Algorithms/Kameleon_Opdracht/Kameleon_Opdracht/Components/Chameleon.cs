using System.Drawing;
using System.Windows.Forms;

namespace Kameleon_Opdracht.Components
{
	public class Chameleon
	{
		public Panel Body { get; set; }
		public Point Speed { get; set; }

		public Chameleon(Panel body, Point speed)
		{
			Body = body;
			Speed = speed;
		}

		public void MoveLocation()
		{
			Body.Location = new Point(Body.Location.X + Speed.X, Body.Location.Y + Speed.Y);
		}

		public void CheckBorders(Panel Island)
		{
			if (Body.Location.X + Body.Width >= Island.Width || Body.Location.X <= 0)
				Speed = new Point(Speed.X * -1, Speed.Y);
			
			if (Body.Location.Y + Body.Height >= Island.Height || Body.Location.Y <= 0)
				Speed = new Point(Speed.X, Speed.Y * -1);
		}

		public void ColorCheck(Chameleon partner)
		{
			for (int xC = 0; xC < Body.Width; xC++)
			{
				int ChameleonWidth = xC + Body.Location.X;
				if (ChameleonWidth > partner.Body.Location.X
					&& ChameleonWidth < partner.Body.Location.X + partner.Body.Size.Width
					&& Body.Location.Y < partner.Body.Location.Y + partner.Body.Size.Height
					&& Body.Location.Y + Body.Size.Height > partner.Body.Location.Y)
				{
					if(Body.BackColor == Color.Red && partner.Body.BackColor == Color.Blue 
						|| Body.BackColor == Color.Blue && partner.Body.BackColor == Color.Red)
					{
						Body.BackColor = Color.Green;
						partner.Body.BackColor = Color.Green;
					}
					else if(Body.BackColor == Color.Green && partner.Body.BackColor == Color.Blue
						|| Body.BackColor == Color.Blue && partner.Body.BackColor == Color.Green)
					{
						Body.BackColor = Color.Red;
						partner.Body.BackColor = Color.Red;
					}
					else if(Body.BackColor == Color.Red && partner.Body.BackColor == Color.Green
						|| Body.BackColor == Color.Green && partner.Body.BackColor == Color.Red)
					{
						Body.BackColor = Color.Blue;
						partner.Body.BackColor = Color.Blue;
					}

					Speed = new Point(Speed.X * -1, Speed.Y * -1);
					partner.Speed = new Point(partner.Speed.X * -1, partner.Speed.Y * -1);
				}
			}
		}
	}
}
