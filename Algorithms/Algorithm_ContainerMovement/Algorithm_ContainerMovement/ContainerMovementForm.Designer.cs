namespace Algorithm_ContainerMovement
{
	partial class ContainerMovementForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tControlShips = new System.Windows.Forms.TabControl();
			this.btnAddDefaultShip = new System.Windows.Forms.Button();
			this.tControlDistributor = new System.Windows.Forms.TabControl();
			this.tPageManual = new System.Windows.Forms.TabPage();
			this.tPageAlgorithm = new System.Windows.Forms.TabPage();
			this.tControlDistributor.SuspendLayout();
			this.tPageManual.SuspendLayout();
			this.SuspendLayout();
			// 
			// tControlShips
			// 
			this.tControlShips.Location = new System.Drawing.Point(274, 12);
			this.tControlShips.Name = "tControlShips";
			this.tControlShips.SelectedIndex = 0;
			this.tControlShips.Size = new System.Drawing.Size(633, 562);
			this.tControlShips.TabIndex = 0;
			// 
			// btnAddDefaultShip
			// 
			this.btnAddDefaultShip.Location = new System.Drawing.Point(7, 478);
			this.btnAddDefaultShip.Name = "btnAddDefaultShip";
			this.btnAddDefaultShip.Size = new System.Drawing.Size(237, 48);
			this.btnAddDefaultShip.TabIndex = 1;
			this.btnAddDefaultShip.Text = "Add Default Ship";
			this.btnAddDefaultShip.UseVisualStyleBackColor = true;
			this.btnAddDefaultShip.Click += new System.EventHandler(this.AddDefaultShip_Click);
			// 
			// tControlDistributor
			// 
			this.tControlDistributor.Controls.Add(this.tPageManual);
			this.tControlDistributor.Controls.Add(this.tPageAlgorithm);
			this.tControlDistributor.Location = new System.Drawing.Point(13, 13);
			this.tControlDistributor.Name = "tControlDistributor";
			this.tControlDistributor.SelectedIndex = 0;
			this.tControlDistributor.Size = new System.Drawing.Size(255, 561);
			this.tControlDistributor.TabIndex = 2;
			// 
			// tPageManual
			// 
			this.tPageManual.Controls.Add(this.btnAddDefaultShip);
			this.tPageManual.Location = new System.Drawing.Point(4, 25);
			this.tPageManual.Name = "tPageManual";
			this.tPageManual.Padding = new System.Windows.Forms.Padding(3);
			this.tPageManual.Size = new System.Drawing.Size(247, 532);
			this.tPageManual.TabIndex = 0;
			this.tPageManual.Text = "Manual";
			this.tPageManual.UseVisualStyleBackColor = true;
			// 
			// tPageAlgorithm
			// 
			this.tPageAlgorithm.Location = new System.Drawing.Point(4, 25);
			this.tPageAlgorithm.Name = "tPageAlgorithm";
			this.tPageAlgorithm.Padding = new System.Windows.Forms.Padding(3);
			this.tPageAlgorithm.Size = new System.Drawing.Size(247, 532);
			this.tPageAlgorithm.TabIndex = 1;
			this.tPageAlgorithm.Text = "Algorithm";
			this.tPageAlgorithm.UseVisualStyleBackColor = true;
			// 
			// ContainerMovementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 586);
			this.Controls.Add(this.tControlDistributor);
			this.Controls.Add(this.tControlShips);
			this.Name = "ContainerMovementForm";
			this.Text = "ContainerMoveMent";
			this.tControlDistributor.ResumeLayout(false);
			this.tPageManual.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tControlShips;
		private System.Windows.Forms.Button btnAddDefaultShip;
		private System.Windows.Forms.TabControl tControlDistributor;
		private System.Windows.Forms.TabPage tPageManual;
		private System.Windows.Forms.TabPage tPageAlgorithm;
	}
}

