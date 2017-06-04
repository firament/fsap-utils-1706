namespace fsap.Pi
{
    partial class frmPI
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
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.ssBotm = new System.Windows.Forms.StatusStrip();
            this.tslEngineType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFilterType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFilterData = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLastProcessed = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpInput.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.ssBotm.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.btnClear);
            this.grpInput.Controls.Add(this.btnGo);
            this.grpInput.Controls.Add(this.txtFilter);
            this.grpInput.Controls.Add(this.cboFilter);
            this.grpInput.Controls.Add(this.lblFilter);
            this.grpInput.Location = new System.Drawing.Point(6, 7);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(874, 62);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Inputs";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(730, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGo.Location = new System.Drawing.Point(586, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(138, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Get Details";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Location = new System.Drawing.Point(301, 23);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(279, 23);
            this.txtFilter.TabIndex = 2;
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(108, 23);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(187, 23);
            this.cboFilter.TabIndex = 1;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(14, 26);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(88, 16);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "&Filter By:";
            // 
            // grpOutput
            // 
            this.grpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Location = new System.Drawing.Point(6, 80);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(874, 197);
            this.grpOutput.TabIndex = 1;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtOutput
            // 
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtOutput.HideSelection = false;
            this.txtOutput.Location = new System.Drawing.Point(3, 19);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(868, 175);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "Processed Output will come here";
            this.txtOutput.WordWrap = false;
            // 
            // ssBotm
            // 
            this.ssBotm.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssBotm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEngineType,
            this.tslFilterType,
            this.tslFilterData,
            this.tslLastProcessed});
            this.ssBotm.Location = new System.Drawing.Point(0, 280);
            this.ssBotm.Name = "ssBotm";
            this.ssBotm.Size = new System.Drawing.Size(887, 22);
            this.ssBotm.TabIndex = 2;
            this.ssBotm.Text = "statusStrip1";
            // 
            // tslEngineType
            // 
            this.tslEngineType.Name = "tslEngineType";
            this.tslEngineType.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tslEngineType.Size = new System.Drawing.Size(255, 17);
            this.tslEngineType.Text = "System.Diagnostics.Process";
            // 
            // tslFilterType
            // 
            this.tslFilterType.Name = "tslFilterType";
            this.tslFilterType.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tslFilterType.Size = new System.Drawing.Size(71, 17);
            this.tslFilterType.Text = "PID";
            // 
            // tslFilterData
            // 
            this.tslFilterData.Name = "tslFilterData";
            this.tslFilterData.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tslFilterData.Size = new System.Drawing.Size(87, 17);
            this.tslFilterData.Text = "90526";
            // 
            // tslLastProcessed
            // 
            this.tslLastProcessed.Name = "tslLastProcessed";
            this.tslLastProcessed.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tslLastProcessed.Size = new System.Drawing.Size(143, 17);
            this.tslLastProcessed.Text = "13:51:07.951";
            this.tslLastProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPI
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 302);
            this.Controls.Add(this.ssBotm);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpInput);
            this.Font = new System.Drawing.Font("Noto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPI";
            this.Text = "Process Info - Sys.Diag.Process";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.ssBotm.ResumeLayout(false);
            this.ssBotm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.StatusStrip ssBotm;
        private System.Windows.Forms.ToolStripStatusLabel tslEngineType;
        private System.Windows.Forms.ToolStripStatusLabel tslFilterType;
        private System.Windows.Forms.ToolStripStatusLabel tslFilterData;
        private System.Windows.Forms.ToolStripStatusLabel tslLastProcessed;
    }
}

