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
			this.Solve = new System.Windows.Forms.Button();
			this.console_Containers = new System.Windows.Forms.TextBox();
			this.console_Ship = new System.Windows.Forms.TextBox();
			this.CreateRandomContainers = new System.Windows.Forms.Button();
			this.numUdAmount = new System.Windows.Forms.NumericUpDown();
			this.lblAmount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numUdAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// Solve
			// 
			this.Solve.Location = new System.Drawing.Point(12, 774);
			this.Solve.Name = "Solve";
			this.Solve.Size = new System.Drawing.Size(147, 23);
			this.Solve.TabIndex = 0;
			this.Solve.Text = "Solve";
			this.Solve.UseVisualStyleBackColor = true;
			this.Solve.Click += new System.EventHandler(this.Solve_Click);
			// 
			// console_Containers
			// 
			this.console_Containers.Location = new System.Drawing.Point(173, 12);
			this.console_Containers.Multiline = true;
			this.console_Containers.Name = "console_Containers";
			this.console_Containers.Size = new System.Drawing.Size(607, 784);
			this.console_Containers.TabIndex = 1;
			// 
			// console_Ship
			// 
			this.console_Ship.Location = new System.Drawing.Point(786, 12);
			this.console_Ship.Multiline = true;
			this.console_Ship.Name = "console_Ship";
			this.console_Ship.Size = new System.Drawing.Size(607, 784);
			this.console_Ship.TabIndex = 2;
			// 
			// CreateRandomContainers
			// 
			this.CreateRandomContainers.Location = new System.Drawing.Point(12, 745);
			this.CreateRandomContainers.Name = "CreateRandomContainers";
			this.CreateRandomContainers.Size = new System.Drawing.Size(147, 23);
			this.CreateRandomContainers.TabIndex = 3;
			this.CreateRandomContainers.Text = "RandomContainers";
			this.CreateRandomContainers.UseVisualStyleBackColor = true;
			this.CreateRandomContainers.Click += new System.EventHandler(this.CreateRandomContainers_Click);
			// 
			// numUdAmount
			// 
			this.numUdAmount.Location = new System.Drawing.Point(13, 717);
			this.numUdAmount.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.numUdAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numUdAmount.Name = "numUdAmount";
			this.numUdAmount.Size = new System.Drawing.Size(146, 22);
			this.numUdAmount.TabIndex = 4;
			this.numUdAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblAmount
			// 
			this.lblAmount.AutoSize = true;
			this.lblAmount.Location = new System.Drawing.Point(12, 697);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(56, 17);
			this.lblAmount.TabIndex = 5;
			this.lblAmount.Text = "Amount";
			// 
			// ContainerMovementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1405, 809);
			this.Controls.Add(this.lblAmount);
			this.Controls.Add(this.numUdAmount);
			this.Controls.Add(this.CreateRandomContainers);
			this.Controls.Add(this.console_Ship);
			this.Controls.Add(this.console_Containers);
			this.Controls.Add(this.Solve);
			this.Name = "ContainerMovementForm";
			this.Text = "ContainerMoveMent";
			((System.ComponentModel.ISupportInitialize)(this.numUdAmount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Solve;
		private System.Windows.Forms.TextBox console_Containers;
		private System.Windows.Forms.TextBox console_Ship;
		private System.Windows.Forms.Button CreateRandomContainers;
		private System.Windows.Forms.NumericUpDown numUdAmount;
		private System.Windows.Forms.Label lblAmount;
	}
}

