﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator
{
	public partial class frmCodeGen : Form
	{
		public frmCodeGen()
		{
			InitializeComponent();
		}

		private void frmCodeGen_Load(object sender, EventArgs e)
		{
			setDefaults();
			cboSegmentSize.TextChanged += UpdateCodeCount;
			numSegmentsPerCode.ValueChanged += UpdateCodeCount;
			btnRun.Click += BtnRun_Click;
		}

		private void BtnRun_Click(object sender, EventArgs e)
		{
			txtOutput.Text = GenerateCodes(
				  Convert.ToInt32(numIterations.Value)
				, Convert.ToInt32(cboSegmentSize.Text)
				, Convert.ToInt32(numSegmentsPerCode.Value)
				, Convert.ToChar(cboSegmentSeperator.Text)
				);
		}

		private void UpdateCodeCount(object sender, EventArgs e)
		{
			txtNote.Text = setNoteContents(
				  Convert.ToInt32(cboSegmentSize.Text)
				, Convert.ToInt32(numSegmentsPerCode.Value)
				);
		}

		private void setDefaults()
		{
			cboSegmentSeperator.SelectedIndex = 0;
			cboSegmentSize.SelectedIndex = 0;
			txtNote.Text = setNoteContents(
				  Convert.ToInt32(cboSegmentSize.Text)
				, Convert.ToInt32(numSegmentsPerCode.Value)
				);
			txtOutput.Text = string.Empty;

		}

		private string setNoteContents(int piSegmentSize = 4, int piSegmentCount = 3)
		{
			const string LC_TEMPLATE = "{0} codes will be generated per iteration.";
			int liCodeCount = getCounts(piSegmentSize, piSegmentCount)[MI_CODE_COUNT];
			return string.Format(LC_TEMPLATE, liCodeCount);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="pdValue"></param>
		/// <returns></returns>
		[Obsolete("Not needed in C#. decimal value is truncated, not rounded")]
		private int RoundDown(double pdValue = 0.0)
		{
			/*
			int liValue = 0;
			int liDecPos = 0;
			*/
			Console.WriteLine(pdValue.ToString());
			Console.WriteLine(pdValue.ToString().Split('.'));
			string lsValue = pdValue.ToString().Split('.')[0];
			if (string.IsNullOrWhiteSpace(lsValue)) lsValue = "0";
			return Convert.ToInt32(lsValue);
		}



		#region STAND ALONE CODE
		// This section is to be shared as a snippet that can be used as a dropin

		const int MI_GUID_LEN   = 32;
		const int MI_MAX_LIMIT  = 10;
		const int MI_CODE_COUNT = 0;
		const int MI_GUID_COUNT = 1;

		/// <summary>
		/// Calculate Rounded number of GUIDs needed to generate Codes of given length
		/// </summary>
		/// <param name="piSegmentSize">Number of characters in each segment of the code</param>
		/// <param name="piSegmentCount">Number of segments in each code</param>
		/// <returns>Array of with counts of total GUIDs to be concatenated and the number of Codes that will be generated from thence. Used to calculate number of Codes for one run (iteration)</returns>
		private int[] getCounts(int piSegmentSize = 4, int piSegmentCount = 3)
		{
			int[] laiCounts = new int[2];

			// GUUID will be 32 chars
			// Calculate possible count using segment size and segment count
			// Derive a formula to run the calculation in one step

			int liGuidLen = MI_GUID_LEN;    // starts with 32, and incremented by 32 per iteration
			int liCodeLen = piSegmentSize * piSegmentCount;
			int liGuidCount = 1;
			int liModulus = -1;
			int liReminder = 0; // .NET will truncate the fraction, and return only the whole number part

			// Add input parameter validation
			if ((piSegmentSize <= 0) || (piSegmentCount <= 0))
			{
				// log a  new ArgumentOutOfRangeException()
				// Caller should check for -ve values
				for (int i = 0; i < laiCounts.Length; i++) { laiCounts[i] = -1; }
			}

			bool lbDone = false;
			do
			{
				liReminder = liGuidLen / liCodeLen;
				liModulus = liGuidLen % liCodeLen;
				lbDone = (liModulus == 0) && (liReminder > 0);
				if (!lbDone)
				{
					liGuidLen += MI_GUID_LEN;
					liGuidCount++;
				}
				if (liGuidCount > MI_MAX_LIMIT) lbDone = true; // avoid infinite loop
			} while (!lbDone);

			if (liGuidCount > MI_MAX_LIMIT)
			{
				// Flag error condition
				Console.WriteLine("Needs more than 10 GUIDS, investigate use case");
			}

			laiCounts[MI_GUID_COUNT] = liGuidCount;
			laiCounts[MI_CODE_COUNT] = liReminder;

			return laiCounts;
		}

		/// <summary>
		/// Generates Codes, and returns with one code per line
		/// </summary>
		/// <param name="piIterPerBatch">Number of times to repeat the code generation</param>
		/// <param name="piSegSize">Number of characters in each segment of the code</param>
		/// <param name="piSegCount">Number of segments in each code</param>
		/// <param name="prSegSep">Character to use for seperating each segment of the code</param>
		/// <returns>Generated Codes, one per line</returns>
		private string GenerateCodes(int piIterPerBatch, int piSegSize, int piSegCount, char prSegSep = '-')
		{
			StringBuilder lsbDatas = new StringBuilder();
			string lsGUIDs = string.Empty;
			int liCodeCount, liGuidCount, liCodeSize;

			// Add input parameter validation
			if (
				   (piIterPerBatch <= 0)
				|| (piSegSize <= 0)
				|| (piSegCount <= 0)
				)
			{
				// Setup validation error message, identify each individual failure
				lsbDatas.AppendLine("INPUT DATA FAILED VALIDATION");
				return lsbDatas.ToString(); // Should contain validation errors.
			}

			int[] laiCounts = getCounts(piSegSize, piSegCount);	
			liCodeCount = laiCounts[MI_CODE_COUNT];
			liGuidCount = laiCounts[MI_GUID_COUNT];

			// Get the full length code string data
			lsbDatas.Clear();
			for (int vGuidCount = 0; vGuidCount < liGuidCount * piIterPerBatch; vGuidCount++)
			{
				lsGUIDs += Guid.NewGuid().ToString("N");
				lsbDatas.Append(Guid.NewGuid().ToString("N"));
			}
			lsGUIDs = lsbDatas.ToString();

			string lsCode = string.Empty;
			liCodeSize = piSegSize * piSegCount;

			// Validate if we have enough chars
			if (liCodeSize * liCodeCount * piIterPerBatch > lsGUIDs.Length)
			{
				// Flag error condition
				Console.WriteLine("ERROR: (liCodeSize * liCodeCount > lsGUIDs.Length)");
				lsbDatas.AppendLine("ERROR: (liCodeSize * liCodeCount > lsGUIDs.Length)");
				return lsbDatas.ToString(); // Should contain appropiate error data.
			}

			// Process one code at a time
			lsbDatas.Clear();
			for (int viCode = 0; viCode < (liCodeSize * liCodeCount * piIterPerBatch); viCode += liCodeSize)
			{
				// Process one segment at a time
				lsCode = string.Empty;
				for (int viSeg = viCode; viSeg < viCode + liCodeSize; viSeg += piSegSize)
				{  lsCode += lsGUIDs.Substring(viSeg, piSegSize) + prSegSep;  }
				lsbDatas.AppendLine(lsCode.TrimEnd(prSegSep));
			}
			return lsbDatas.ToString();
		}


		#endregion





	}
}
