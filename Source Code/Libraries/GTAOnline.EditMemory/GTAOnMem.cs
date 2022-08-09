using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAOnline.EditMemory
{
    public class GTAOnMem
    {
        public Mem mem;
        public bool EditMem(string find_address, string write_address, string type_of_addresses, int value)
        {
            if (mem.OpenProcess(mem.GetProcIdFromName("GTA5.exe")))
            {
                mem.ReadInt(find_address);
                mem.WriteMemory(write_address, type_of_addresses, value.ToString());
                return true;
            }
            else
            {
                File.WriteAllText(@"C:\GTAOnline\Oops.txt", "Oops... GTAV Process Not Founded... It's Very Bad :(");
            }
            return false;

        }
        public void FindGTAVProcess()
        {
            Process[] gta5 = Process.GetProcessesByName("GTA5.exe");
            foreach(Process mk_gta5 in gta5)
            {
                if(gta5.Length == 1)
                {
                    ProcessModule module = mk_gta5.MainModule;
                    string mod_name = module.FileName;
                    File.WriteAllText(@"C:\GTAOnline\ModuleName.txt", mod_name);
                }
                else
                {
                    throw new Exception("GTA5 Not Founded... It's Very Bad :(");
                }
            }
        }
    }
}
