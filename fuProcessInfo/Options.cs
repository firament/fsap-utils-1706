using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsap.Pi
{
    class Options
    {
    }

    public enum eEngineType
    {
        Unknown = 0,
        SysDiagProc = 1,
        SysMgmtMgmtCls = 2,
    }

    public enum eFilterType
    {
        Unknown = 0,
        NoFilter = 1,
        ByPID = 2,
        ByName = 3,
    }

    public class ddEntry
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}


/*
lsbInfo.AppendLine(AsMDString("BasePriority", lpProcess ));
lsbInfo.AppendLine(AsMDString("CanRaiseEvents", lpProcess ));
lsbInfo.AppendLine(AsMDString("Container", lpProcess ));
lsbInfo.AppendLine(AsMDString("DesignMode", lpProcess ));
lsbInfo.AppendLine(AsMDString("EnableRaisingEvents", lpProcess ));
lsbInfo.AppendLine(AsMDString("Events", lpProcess ));
lsbInfo.AppendLine(AsMDString("ExitCode", lpProcess ));
lsbInfo.AppendLine(AsMDString("ExitTime", lpProcess ));
lsbInfo.AppendLine(AsMDString("Handle", lpProcess ));
lsbInfo.AppendLine(AsMDString("HandleCount", lpProcess ));
lsbInfo.AppendLine(AsMDString("HasExited", lpProcess ));
lsbInfo.AppendLine(AsMDString("Id", lpProcess ));
lsbInfo.AppendLine(AsMDString("MachineName", lpProcess ));
lsbInfo.AppendLine(AsMDString("MainModule", lpProcess ));
lsbInfo.AppendLine(AsMDString("MainWindowHandle", lpProcess ));
lsbInfo.AppendLine(AsMDString("MainWindowTitle", lpProcess ));
lsbInfo.AppendLine(AsMDString("MaxWorkingSet", lpProcess ));
lsbInfo.AppendLine(AsMDString("MinWorkingSet", lpProcess ));
lsbInfo.AppendLine(AsMDString("Modules", lpProcess ));
lsbInfo.AppendLine(AsMDString("NonpagedSystemMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("NonpagedSystemMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PagedMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("PagedMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PagedSystemMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("PagedSystemMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakPagedMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakPagedMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakVirtualMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakVirtualMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakWorkingSet", lpProcess ));
lsbInfo.AppendLine(AsMDString("PeakWorkingSet64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PriorityBoostEnabled", lpProcess ));
lsbInfo.AppendLine(AsMDString("PriorityClass", lpProcess ));
lsbInfo.AppendLine(AsMDString("PrivateMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("PrivateMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("PrivilegedProcessorTime", lpProcess ));
lsbInfo.AppendLine(AsMDString("ProcessName", lpProcess ));
lsbInfo.AppendLine(AsMDString("ProcessorAffinity", lpProcess ));
lsbInfo.AppendLine(AsMDString("Responding", lpProcess ));
lsbInfo.AppendLine(AsMDString("SafeHandle", lpProcess ));
lsbInfo.AppendLine(AsMDString("SessionId", lpProcess ));
lsbInfo.AppendLine(AsMDString("Site", lpProcess ));
lsbInfo.AppendLine(AsMDString("StandardError", lpProcess ));
lsbInfo.AppendLine(AsMDString("StandardInput", lpProcess ));
lsbInfo.AppendLine(AsMDString("StandardOutput", lpProcess ));
lsbInfo.AppendLine(AsMDString("StartInfo", lpProcess ));
lsbInfo.AppendLine(AsMDString("StartTime", lpProcess ));
lsbInfo.AppendLine(AsMDString("SynchronizingObject", lpProcess ));
lsbInfo.AppendLine(AsMDString("Threads", lpProcess ));
lsbInfo.AppendLine(AsMDString("TotalProcessorTime", lpProcess ));
lsbInfo.AppendLine(AsMDString("UserProcessorTime", lpProcess ));
lsbInfo.AppendLine(AsMDString("VirtualMemorySize", lpProcess ));
lsbInfo.AppendLine(AsMDString("VirtualMemorySize64", lpProcess ));
lsbInfo.AppendLine(AsMDString("WorkingSet", lpProcess ));
lsbInfo.AppendLine(AsMDString("WorkingSet64", lpProcess ));

 */
