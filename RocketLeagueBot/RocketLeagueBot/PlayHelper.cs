using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueBot
{
    public class PlayHelper
    {
        public PlayHelper(string xname)
        {
            exeName = xname;
            rwm = new ReadWriteMem(exeName);
        }

        public string exeName { get; set; }
        ReadWriteMem rwm { get; set; }

        public int[] GetAddressVector(IntPtr processHandle, IntPtr rocketLeagueProc)
        {
            int[] addressList = new int[41];

            addressList[0] = rwm.GetFinalAddress(processHandle, new int[] { 0x019FCF34, 0xCC, 0x30, 0x54 });  // Blue Boost address (Updated August 5, 2017)
            addressList[1] = rwm.GetFinalAddress(processHandle, new int[] { 0x018DB9C4, 0x4, 0x20, 0x44 });  // Player z address
            addressList[2] = rwm.GetFinalAddress(processHandle, new int[] { 0x018DB9C4, 0x8, 0x20, 0x44 }); // Ball z address
            addressList[3] = rwm.GetFinalAddress(processHandle, new int[] { 0x018DB9C4, 0x0, 0x20, 0x44 }); // Bot (orange) z address

            //verifyPlayerPointers(processHandle, addressList) ; // Still need to deal with demolitions being wacky pointers but that can be done later if possible

            addressList[4] = addressList[1] + 4; // Player y address
            addressList[5] = addressList[1] - 4; // Player x address
            addressList[6] = addressList[2] + 4; // Ball y address
            addressList[7] = addressList[2] - 4; // Ball x address
            addressList[8] = addressList[4] + 8; // Player rot1
            addressList[9] = addressList[8] + 4; // Player rot2
            addressList[10] = addressList[9] + 4; // Player rot3
            addressList[11] = addressList[10] + 8; // Player rot4
            addressList[12] = addressList[11] + 4; // Player rot5
            addressList[13] = addressList[12] + 4; // Player rot6
            addressList[14] = addressList[13] + 8; // Player rot7
            addressList[15] = addressList[14] + 4; // Player rot8
            addressList[16] = addressList[15] + 4; // Player rot9
            addressList[17] = addressList[3] + 4; // Bot y address (orange)
            addressList[18] = addressList[3] - 4; // Bot x address
            addressList[19] = addressList[17] + 8; // Bot rot1
            addressList[20] = addressList[19] + 4; // Bot rot2
            addressList[21] = addressList[20] + 4; // Bot rot3
            addressList[22] = addressList[21] + 8; // Bot rot4
            addressList[23] = addressList[22] + 4; // Bot rot5
            addressList[24] = addressList[23] + 4; // Bot rot6
            addressList[25] = addressList[24] + 8; // Bot rot7
            addressList[26] = addressList[25] + 4; // Bot rot8
            addressList[27] = addressList[26] + 4; // Bot rot9
            addressList[28] = rwm.GetFinalAddress(processHandle, new int[] { 0x019A3BA0, 0x8, 0x228, 0x20C }); // Blue score address
            addressList[29] = rwm.GetFinalAddress(processHandle, new int[] { 0x019A3BA0, 0x10, 0x228, 0x20C }); // Orange score address
            addressList[30] = rwm.GetFinalAddress(processHandle, new int[] { 0x019A3BA0, 0x8, 0x310 }); // Blue "Score" address
            addressList[31] = rwm.GetFinalAddress(processHandle, new int[] { 0x019A3BA0, 0x10, 0x310 }); // Orange "Score" address
            addressList[32] = addressList[30] + 4; // Blue goals
            addressList[33] = addressList[32] + 12; // Blue saves
            addressList[34] = addressList[32] + 16; // Blue shots
            addressList[35] = addressList[31] + 4; // Orange goals
            addressList[36] = addressList[35] + 12; // Orange saves
            addressList[37] = addressList[35] + 16; // Orange shots
            addressList[38] = addressList[37] + 4; // Demos by orange
            addressList[39] = addressList[34] + 4; // Demos by blue
            addressList[40] = rwm.GetFinalAddress(processHandle, new int[] { 0x0192F0A4, 0x688, 0x8, 0x30C }); // Orange Boost address

            return addressList;
        }
    }
}

