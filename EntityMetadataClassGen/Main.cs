using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fsap.EntityMetadataClassGen
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			InputData loInputs = new InputData()
			{
				SourceRootFolder = txtSrc.Text,
				DestinationFolder = txtDest.Text
			};
			int liReturnValue = MDGenerator.Generate(loInputs) ?? -1;

			// give user feedback on return status
			MessageBox.Show("Process completed with Status = " + liReturnValue);
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			string lsText = "";
			txtSrc.Text = Properties.Settings.Default.Properties["DefaultSourceFolder"].DefaultValue.ToString();
			txtDest.Text = Properties.Settings.Default.Properties["DefaultDestinationFolder"].DefaultValue.ToString();

			//txtSrc.Text = @"E:\Work\buffer\EntityMetadataClassGen-Test";
			//txtDest.Text = @"E:\Work\buffer\EntityMetadataClassGen-Test\EntityMetadata";
		}
	}
}
