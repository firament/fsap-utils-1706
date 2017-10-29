namespace CodeGenerator
{
	partial class frmCodeGen
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
			this.splContainer = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSegmentSize = new System.Windows.Forms.Label();
			this.cboSegmentSize = new System.Windows.Forms.ComboBox();
			this.lblChars = new System.Windows.Forms.Label();
			this.lblSegmentSeperator = new System.Windows.Forms.Label();
			this.cboSegmentSeperator = new System.Windows.Forms.ComboBox();
			this.lblSegmentsPerCode = new System.Windows.Forms.Label();
			this.numSegmentsPerCode = new System.Windows.Forms.NumericUpDown();
			this.lblIterationsIn = new System.Windows.Forms.Label();
			this.numIterations = new System.Windows.Forms.NumericUpDown();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.txtNote = new System.Windows.Forms.TextBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.splContainer)).BeginInit();
			this.splContainer.Panel1.SuspendLayout();
			this.splContainer.Panel2.SuspendLayout();
			this.splContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numSegmentsPerCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
			this.SuspendLayout();
			// 
			// splContainer
			// 
			this.splContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splContainer.Location = new System.Drawing.Point(0, 0);
			this.splContainer.Name = "splContainer";
			// 
			// splContainer.Panel1
			// 
			this.splContainer.Panel1.Controls.Add(this.txtNote);
			this.splContainer.Panel1.Controls.Add(this.btnReset);
			this.splContainer.Panel1.Controls.Add(this.btnRun);
			this.splContainer.Panel1.Controls.Add(this.numIterations);
			this.splContainer.Panel1.Controls.Add(this.lblIterationsIn);
			this.splContainer.Panel1.Controls.Add(this.numSegmentsPerCode);
			this.splContainer.Panel1.Controls.Add(this.lblSegmentsPerCode);
			this.splContainer.Panel1.Controls.Add(this.cboSegmentSeperator);
			this.splContainer.Panel1.Controls.Add(this.lblSegmentSeperator);
			this.splContainer.Panel1.Controls.Add(this.lblChars);
			this.splContainer.Panel1.Controls.Add(this.cboSegmentSize);
			this.splContainer.Panel1.Controls.Add(this.lblSegmentSize);
			this.splContainer.Panel1.Controls.Add(this.label1);
			// 
			// splContainer.Panel2
			// 
			this.splContainer.Panel2.Controls.Add(this.txtOutput);
			this.splContainer.Size = new System.Drawing.Size(536, 480);
			this.splContainer.SplitterDistance = 217;
			this.splContainer.SplitterWidth = 8;
			this.splContainer.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Parameters:";
			// 
			// lblSegmentSize
			// 
			this.lblSegmentSize.AutoSize = true;
			this.lblSegmentSize.Location = new System.Drawing.Point(13, 49);
			this.lblSegmentSize.Name = "lblSegmentSize";
			this.lblSegmentSize.Size = new System.Drawing.Size(139, 19);
			this.lblSegmentSize.TabIndex = 1;
			this.lblSegmentSize.Text = "Segment Size:";
			// 
			// cboSegmentSize
			// 
			this.cboSegmentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSegmentSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboSegmentSize.Items.AddRange(new object[] {
            "4",
            "6",
            "8"});
			this.cboSegmentSize.Location = new System.Drawing.Point(13, 71);
			this.cboSegmentSize.Name = "cboSegmentSize";
			this.cboSegmentSize.Size = new System.Drawing.Size(65, 27);
			this.cboSegmentSize.TabIndex = 2;
			// 
			// lblChars
			// 
			this.lblChars.AutoSize = true;
			this.lblChars.Location = new System.Drawing.Point(84, 74);
			this.lblChars.Name = "lblChars";
			this.lblChars.Size = new System.Drawing.Size(59, 19);
			this.lblChars.TabIndex = 3;
			this.lblChars.Text = "Chars";
			// 
			// lblSegmentSeperator
			// 
			this.lblSegmentSeperator.AutoSize = true;
			this.lblSegmentSeperator.Location = new System.Drawing.Point(13, 118);
			this.lblSegmentSeperator.Name = "lblSegmentSeperator";
			this.lblSegmentSeperator.Size = new System.Drawing.Size(189, 19);
			this.lblSegmentSeperator.TabIndex = 4;
			this.lblSegmentSeperator.Text = "Segment Seperator:";
			// 
			// cboSegmentSeperator
			// 
			this.cboSegmentSeperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSegmentSeperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboSegmentSeperator.FormattingEnabled = true;
			this.cboSegmentSeperator.Items.AddRange(new object[] {
            "-",
            "_",
            " "});
			this.cboSegmentSeperator.Location = new System.Drawing.Point(13, 140);
			this.cboSegmentSeperator.Name = "cboSegmentSeperator";
			this.cboSegmentSeperator.Size = new System.Drawing.Size(65, 27);
			this.cboSegmentSeperator.TabIndex = 5;
			// 
			// lblSegmentsPerCode
			// 
			this.lblSegmentsPerCode.AutoSize = true;
			this.lblSegmentsPerCode.Location = new System.Drawing.Point(13, 186);
			this.lblSegmentsPerCode.Name = "lblSegmentsPerCode";
			this.lblSegmentsPerCode.Size = new System.Drawing.Size(189, 19);
			this.lblSegmentsPerCode.TabIndex = 6;
			this.lblSegmentsPerCode.Text = "Segments per Code:";
			// 
			// numSegmentsPerCode
			// 
			this.numSegmentsPerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numSegmentsPerCode.Location = new System.Drawing.Point(13, 208);
			this.numSegmentsPerCode.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numSegmentsPerCode.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numSegmentsPerCode.Name = "numSegmentsPerCode";
			this.numSegmentsPerCode.Size = new System.Drawing.Size(62, 26);
			this.numSegmentsPerCode.TabIndex = 7;
			this.numSegmentsPerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numSegmentsPerCode.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lblIterationsIn
			// 
			this.lblIterationsIn.AutoSize = true;
			this.lblIterationsIn.Location = new System.Drawing.Point(84, 337);
			this.lblIterationsIn.Name = "lblIterationsIn";
			this.lblIterationsIn.Size = new System.Drawing.Size(99, 19);
			this.lblIterationsIn.TabIndex = 8;
			this.lblIterationsIn.Text = "Iteration";
			// 
			// numIterations
			// 
			this.numIterations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numIterations.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numIterations.Location = new System.Drawing.Point(13, 335);
			this.numIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numIterations.Name = "numIterations";
			this.numIterations.Size = new System.Drawing.Size(65, 26);
			this.numIterations.TabIndex = 9;
			this.numIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numIterations.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(13, 367);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(189, 44);
			this.btnRun.TabIndex = 10;
			this.btnRun.Text = "Run &Batch";
			this.btnRun.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(13, 424);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(189, 44);
			this.btnReset.TabIndex = 11;
			this.btnReset.Text = "E&xit";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// txtNote
			// 
			this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNote.Font = new System.Drawing.Font("Noto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNote.Location = new System.Drawing.Point(13, 240);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.ReadOnly = true;
			this.txtNote.Size = new System.Drawing.Size(189, 79);
			this.txtNote.TabIndex = 12;
			this.txtNote.TabStop = false;
			this.txtNote.Text = "Generated Text will come here";
			// 
			// txtOutput
			// 
			this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Location = new System.Drawing.Point(0, 0);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(311, 480);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.WordWrap = false;
			// 
			// frmCodeGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 480);
			this.Controls.Add(this.splContainer);
			this.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "frmCodeGen";
			this.Text = "Code Generator";
			this.Load += new System.EventHandler(this.frmCodeGen_Load);
			this.splContainer.Panel1.ResumeLayout(false);
			this.splContainer.Panel1.PerformLayout();
			this.splContainer.Panel2.ResumeLayout(false);
			this.splContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splContainer)).EndInit();
			this.splContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numSegmentsPerCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splContainer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblChars;
		private System.Windows.Forms.ComboBox cboSegmentSize;
		private System.Windows.Forms.Label lblSegmentSize;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.NumericUpDown numIterations;
		private System.Windows.Forms.Label lblIterationsIn;
		private System.Windows.Forms.NumericUpDown numSegmentsPerCode;
		private System.Windows.Forms.Label lblSegmentsPerCode;
		private System.Windows.Forms.ComboBox cboSegmentSeperator;
		private System.Windows.Forms.Label lblSegmentSeperator;
		private System.Windows.Forms.TextBox txtNote;
		private System.Windows.Forms.TextBox txtOutput;
	}
}

