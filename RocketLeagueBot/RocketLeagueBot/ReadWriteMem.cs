using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace RocketLeagueBot
{
    public class ReadWriteMem
    {
        public ReadWriteMem(string exeName)
        {
            PROCESS_ALL_ACCESS_FINAL = STANDARD_RIGHTS_REQUIRED + SYNCHRONIZE + "0xFFF";
            rocketLeagueP = Process.GetProcessesByName(exeName)[0];
            processHandle = ReadWriteMem.OpenProcess(PROCESS_WM_READ, false, rocketLeagueP.Id);
        }

        const int PROCESS_WM_READ = 0x0010;

        public string PROCESS_ALL_ACCESS = "0x1F0FFF";
        public string TH32CS_SNAPPROCESS = "2";
        public string STANDARD_RIGHTS_REQUIRED = "0x000F0000";
        public string SYNCHRONIZE = "0x00100000";
        public string PROCESS_ALL_ACCESS_FINAL { get; set; }
        public int MAX_PATH = 260;
        public string TH32CS_SNAPMODULE = "0x00000008";
        public string TH32CS_SNAPTHREAD = "0x00000004";
        private Process rocketLeagueP { get; set; }
        private IntPtr processHandle { get; set; }


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public Process GetProcessByName(string pName)
        {
            if (!pName.EndsWith(".exe"))
                pName = pName + ".exe";
            return Process.GetProcessesByName(pName).FirstOrDefault();
        }


        /*CreateToolhelp32Snapshot= windll.kernel32.CreateToolhelp32Snapshot
        Process32First = windll.kernel32.Process32First
        Process32Next = windll.kernel32.Process32Next
        Module32First = windll.kernel32.Module32First
        Module32Next = windll.kernel32.Module32Next
        GetLastError = windll.kernel32.GetLastError
        OpenProcess = windll.kernel32.OpenProcess
        GetPriorityClass = windll.kernel32.GetPriorityClass
        CloseHandle = windll.kernel32.CloseHandle
        */

        public int GetFinalAddress(IntPtr hProcess,  int[] offsets)
        {
            byte[] buffer = new byte[24];
            uint convert = new uint();
            int bufferSize = 4;
            IntPtr address = GetBaseAddress();
            foreach(int offset in offsets)
            {
                address = address + offset;
                int bytesRead = 0;
                ReadProcessMemory((int)hProcess, (int)address, buffer, bufferSize, ref bytesRead);
            }
            return (int)address + offsets.Last();
        }

        public IntPtr GetBaseAddress()
        {
            return rocketLeagueP.MainModule.BaseAddress;
            
        }
    }
}

