namespace fsap.EntityMetadataClassGen
{
	partial class frmMain
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
			this.btnRun = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSrc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDest = new System.Windows.Forms.TextBox();
			this.btnSrcSelect = new System.Windows.Forms.Button();
			this.btnDestSelect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRun.ForeColor = System.Drawing.Color.Red;
			this.btnRun.Location = new System.Drawing.Point(16, 83);
			this.btnRun.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(632, 64);
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "Generate Now";
			this.btnRun.UseVisualStyleBackColor = false;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "&Source Folder";
			// 
			// txtSrc
			// 
			this.txtSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSrc.Location = new System.Drawing.Point(207, 11);
			this.txtSrc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSrc.Name = "txtSrc";
			this.txtSrc.Size = new System.Drawing.Size(382, 26);
			this.txtSrc.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(189, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "&Destination Folder";
			// 
			// txtDest
			// 
			this.txtDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDest.Location = new System.Drawing.Point(207, 41);
			this.txtDest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDest.Name = "txtDest";
			this.txtDest.Size = new System.Drawing.Size(382, 26);
			this.txtDest.TabIndex = 4;
			// 
			// btnSrcSelect
			// 
			this.btnSrcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSrcSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSrcSelect.ForeColor = System.Drawing.Color.Blue;
			this.btnSrcSelect.Location = new System.Drawing.Point(595, 11);
			this.btnSrcSelect.Name = "btnSrcSelect";
			this.btnSrcSelect.Size = new System.Drawing.Size(53, 26);
			this.btnSrcSelect.TabIndex = 5;
			this.btnSrcSelect.Text = "...";
			this.btnSrcSelect.UseVisualStyleBackColor = true;
			// 
			// btnDestSelect
			// 
			this.btnDestSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDestSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDestSelect.ForeColor = System.Drawing.Color.Blue;
			this.btnDestSelect.Location = new System.Drawing.Point(595, 41);
			this.btnDestSelect.Name = "btnDestSelect";
			this.btnDestSelect.Size = new System.Drawing.Size(53, 26);
			this.btnDestSelect.TabIndex = 6;
			this.btnDestSelect.Text = "...";
			this.btnDestSelect.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 160);
			this.Controls.Add(this.btnDestSelect);
			this.Controls.Add(this.btnSrcSelect);
			this.Controls.Add(this.txtDest);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSrc);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRun);
			this.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "frmMain";
			this.Text = "Metadata Code Generator for Entity Classes - fsap";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSrc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDest;
		private System.Windows.Forms.Button btnSrcSelect;
		private System.Windows.Forms.Button btnDestSelect;
	}
}