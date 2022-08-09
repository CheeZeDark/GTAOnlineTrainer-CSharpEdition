using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GTAOnline.MemEditUnlimMoney
{
    public class GTAOnlineMemEditUnlimitedMoney
    {
        public string addresses_expl;
        public string proc_name = "GTA5.exe";
        public MemoryStream mem;
        public long offs = 0x3BC; //Trying To Exploit Unlim Money and Hidden Thread :D
        public ProcessThread proc;

        private bool DisposeProcess()
        {
            proc.Dispose();
            return true;
        }
        public bool SetUnlimMoneyExploit()
        {
            if (MemoryStream.Null.CanRead == true)
            {
                mem.Seek(offs + Math.Max(0x3BE, offs), SeekOrigin.Current);
                proc.IdealProcessor = 2;
                proc.PriorityLevel = ThreadPriorityLevel.Highest;
            }
            else
            {
                File.WriteAllText("C:\\GTAOnline\\Errors.txt", "[Trainer] Null MemoryStream is Not Founded Please Try Launch this Trainer in Administrative Privilege!!!");
                Environment.Exit(213);
            }
            if(mem.Length == 4)
            {
                GTAOnline.EditMemory.GTAOnMem gta = new EditMemory.GTAOnMem();
                gta.EditMem(SetHijakAddress(), SetHijakAddress(), "int", 99999999);
                return DisposeProcess();
            }
            return true;
        }
        public string BaseAddressesHijakKhamelionExploit() //Base addresses to Exploit Money
        {
            string[] addresses_hijak =
            {
                "0x229CBF75A20",
                "0x229CC006398",
                "0x229DE7828B8",
                "0x229DE7854D0",
                "0x229DE785518",
                "0x229E19F4060",
                "0x229E19F40C8",
                "0x229E19F4130",
                "0x229E19F4198",
                "0x229E19F4200",
                "0x229E19F4268",
                "0x229E19F42D0",
                "0x229E19FBC20",
                "0x229E19FBC88",
                "0x229E19FBCF0",
                "0x229E19FBD58",
                "0x229E19FBDC0",
                "0x229E19FBE28",
                "0x229E19FBE90",
                $"{proc_name}+0x2787410"
            };
            if (!File.Exists("C:\\GTAOnline\\Hijak.txt"))
            {
                addresses_expl = addresses_hijak.ToString();
                File.WriteAllText("C:\\GTAOnline\\Hijak.txt", addresses_expl);
            }
            return addresses_expl;
        }
        public string string_address_hijak;
        public string SetHijakAddress()
        {
            string[] address444 =
            {
                "0x229CBF75A20",
                "0x229CC006398",
                "0x229DE7828B8",
                "0x229DE7854D0",
                "0x229DE785518",
                "0x229E19F4060",
                "0x229E19F40C8",
                "0x229E19F4130",
                "0x229E19F4198",
                "0x229E19F4200",
                "0x229E19F4268",
                "0x229E19F42D0",
                "0x229E19FBC20",
                "0x229E19FBC88",
                "0x229E19FBCF0",
                "0x229E19FBD58",
                "0x229E19FBDC0",
                "0x229E19FBE28",
                "0x229E19FBE90",
                $"{proc_name}+0x2787410"
            };
            string_address_hijak = address444.ToString();
            return string_address_hijak;
        }
    }
}
