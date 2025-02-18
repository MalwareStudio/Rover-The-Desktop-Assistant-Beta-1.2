using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysPrivileges;

namespace rover
{
    public partial class Force_Reboot : Privileges
    {
        public void Reboot()
        {
            IntPtr handle;
            TOKEN_PRIVILEGES tkp = new TOKEN_PRIVILEGES();
            tkp.Privileges = new LUID_AND_ATTRIBUTES[1];
            OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out handle);
            LookupPrivilegeValue(null, PrivilegeNames.SeShutdownPrivilege.ToString(), ref tkp.Privileges[0].Luid);
            tkp.PrivilegeCount = 1;
            tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
            AdjustTokenPrivileges(handle, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero);
            NtShutdownSystem(SHUTDOWN_ACTION.ShutdownReboot);
        }
    }
}
