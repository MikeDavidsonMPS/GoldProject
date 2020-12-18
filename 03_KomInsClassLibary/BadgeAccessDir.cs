using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomInsClassLibary
{
      // POCO
    public class BadgeAccessDir
    {
        public int BadgeID { get; set; }
        public string DoorAccess{ get; set; }

        public BadgeAccessDir() { }

        public BadgeAccessDir(int badgeID, string doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess= doorAccess;
        }

    }
}
