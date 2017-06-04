using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace fsap.Pi
{
    public partial class frmPI : Form
    {
        const string MC_MISSING = "**-NA-**";

        protected Dictionary<int, string> mdtFilterType = new Dictionary<int, string>();

        eFilterType meFilter = eFilterType.ByPID;
        eEngineType meEngine = eEngineType.SysMgmtMgmtCls;
        string MS_LineTemplate_2c = "| {0} | {1} |" + Environment.NewLine;
        string MS_LineTemplate_3c = "| {0} | {1} | {2} |" + Environment.NewLine;
        string MS_LineTemplate_5c = "| {0} | {1} | {2} | {3} | {4} |" + Environment.NewLine;


        public frmPI()
        {
            InitializeComponent();
            //    Unknown = 0,
            //NoFilter = 1,
            //ByPID = 2,
            //ByName = 3,
            mdtFilterType.Add(0, "Select Filter Type");
            mdtFilterType.Add(1, "All Processes");
            mdtFilterType.Add(2, "Process ID");
            mdtFilterType.Add(3, "Process Name");

            cboFilter.DataSource = mdtFilterType.ToList();
            cboFilter.ValueMember = "Key";
            cboFilter.DisplayMember = "Value";

        }

        private string ListLocalProcs()
        {
            StringBuilder lsbInfo = new StringBuilder();
            lsbInfo.AppendLine("Process List - Local Machine");
            lsbInfo.AppendFormat(MS_LineTemplate_5c, "ID", "Name", "Module", "Window Title", "Exec Path");

            foreach (Process vProc in Process.GetProcesses())    
            {
                bool lbHasMods = false;
                try { lbHasMods = (vProc.MainModule.ModuleName.Length > 0); }
                catch (Exception Ex) { lbHasMods = false; }

                lsbInfo.AppendFormat(MS_LineTemplate_5c
                    , vProc.Id
                    , vProc.ProcessName
                    , (lbHasMods)? vProc.MainModule.ModuleName : MC_MISSING
                    , vProc.MainWindowTitle
                    , (lbHasMods) ? vProc.MainModule.FileName : MC_MISSING  
                    );
            }
            return lsbInfo.ToString();
        }

        private string GetProcessInfoMC(int pivID = 0)
        {
            StringBuilder lsbInfo = new StringBuilder();
            return lsbInfo.ToString();
        }

        private string GetProcInfoP(int piID = 0)
        {
            StringBuilder lsbInfo = new StringBuilder();
            Process lpProcess = Process.GetProcessById(piID);

            // validate to confirm a process exists
            lsbInfo.AppendLine(getProcessesDetails(lpProcess));

            return lsbInfo.ToString();
        }

        private string GetProcInfoP(string psName = "")
        {
            StringBuilder lsbInfo = new StringBuilder();

            foreach (Process vProcess in Process.GetProcessesByName(psName))
            {
                // validate to confirm a process exists
                lsbInfo.AppendLine(getProcessesDetails(vProcess));
            }


            return lsbInfo.ToString();
        }

        private string getProcessesDetails(Process vProc)
        {
            if (vProc == null)
            {
                return string.Empty;
            }
            bool lbHasMods = false;
            try
            {
                lbHasMods = (vProc.MainModule.ModuleName.Length > 0);
            }
            catch (Exception Ex)
            {
                lbHasMods = false;
            }

            StringBuilder lsbInfo = new StringBuilder();
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "ID", vProc.Id);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "ProcessName", vProc.ProcessName);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "MainWindowTitle", vProc.MainWindowTitle);

            lsbInfo.AppendFormat(MS_LineTemplate_2c, "HandleCount", vProc.HandleCount);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "MainModule.ModuleName", lbHasMods ? vProc.MainModule.ModuleName : MC_MISSING) ;

            lsbInfo.AppendFormat(MS_LineTemplate_2c, "Responding", vProc.Responding);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "SessionId", vProc.SessionId);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "StartTime", lbHasMods ? vProc.StartTime.ToString("dd-mmm-yyyy HH:MM:SS") : MC_MISSING);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "Threads.Count", vProc.Threads.Count);

            lsbInfo.AppendLine(getStartInfoDetails(vProc.StartInfo));

            return lsbInfo.ToString();
        }

        private string getStartInfoDetails(ProcessStartInfo pStartInfo)
        {
            StringBuilder lsbInfo = new StringBuilder();

            // Add empty row, to indicate a collection
            // lsbInfo.AppendFormat(MS_LineTemplate_2c, "", "");
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "**StartInfo Details:**", "");

            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo.WorkingDirectory);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo.UserName);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo.Arguments);

            lsbInfo.AppendFormat(MS_LineTemplate_2c, "StartInfo - Environment Variables", MC_MISSING);

            foreach (DictionaryEntry de in pStartInfo.EnvironmentVariables)
            {
                lsbInfo.AppendFormat(MS_LineTemplate_2c, de.Key, de.Value);
            }



            // lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo.EnvironmentVariables);
            /*
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo);
            lsbInfo.AppendFormat(MS_LineTemplate_2c, "", pStartInfo);
            */

            return lsbInfo.ToString();
        }

        private string getModuleDetails(ProcessModule poModule)
        {
            StringBuilder lsbInfo = new StringBuilder();

            return lsbInfo.ToString();
        }

        private string writeHeader(string psFormat = "md")
        {
            StringBuilder lsbInfo = new StringBuilder();
            switch (psFormat)
            {
                default:
                    break;
            }
            return lsbInfo.ToString();
        }

        private bool IsValid()
        {
            // TODO: 
            // if txtFilter is empty, see if anything is selecetd in the txtOutput. if so, use as PID or Name
            bool lbHasErrors = false;
            int liPID = 0;
            switch ((eFilterType)cboFilter.SelectedValue)
            {
                case eFilterType.Unknown:
                    lbHasErrors = true;
                    break;
                case eFilterType.NoFilter:
                    break;
                case eFilterType.ByPID:
                    if (!int.TryParse(txtFilter.Text.Trim(), out liPID))
                    {
                        lbHasErrors = true;
                    }
                    break;
                case eFilterType.ByName:
                    if (string.IsNullOrWhiteSpace(txtFilter.Text))
                    {
                        lbHasErrors = true;
                    }
                    break;
                default:
                    break;
            }

            return !lbHasErrors;
        }

        private string AsMDString(string psProp, Object psVal)
        {
            
            return string.Format(MS_LineTemplate_2c, psProp, psVal.ToString());
        }

        #region Events
        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print(cboFilter.SelectedValue.ToString() + " - " + cboFilter.SelectedItem.ToString() );
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            //txtOutput.Text = GetProcInfoP(4100);
            txtOutput.Text = ListLocalProcs();

            if (!IsValid())
            {
                txtOutput.Text = "UNKNOWN ERROR!";
                return;
            }

            string lsInput = txtFilter.Text.Trim();
            string lsOutput = "";
            switch ((eFilterType)cboFilter.SelectedValue)
            {
                case eFilterType.NoFilter:
                    lsOutput = ListLocalProcs();
                    break;
                case eFilterType.ByPID:
                    lsOutput = GetProcInfoP(int.Parse(lsInput));
                    break;
                case eFilterType.ByName:
                    lsOutput = GetProcInfoP(lsInput);
                    break;
                case eFilterType.Unknown:
                default:
                    break;
            }
            txtOutput.Text = lsOutput;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        #endregion

    }
}
