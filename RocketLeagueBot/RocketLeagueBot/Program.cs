using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace RocketLeagueBot
{
    class Program
    {
        const int PROCESS_WM_READ = 0x0010;

        static void Main(string[] args)
        {

            ReadWriteMem mem = new ReadWriteMem("RocketLeague.exe");

           

            /*ReadWriteMem.ReadProcessMemory((int)processHandle, 0xD5369227FC, buffer, buffer.Length, ref bytesRead);

            Console.WriteLine(Encoding.Unicode.GetString(buffer) +
                  " (" + bytesRead.ToString() + "bytes)");
            Console.ReadLine();
            */
        }
    }
}
