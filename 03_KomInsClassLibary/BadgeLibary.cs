using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomInsClassLibary
{
      // POCO
    public class BadgeLibary
    {
        public int BadgeID { get; set; }
        public string DoorAccess{ get; set; }

        public BadgeLibary() { }

        public BadgeLibary(int badgeID, string doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess= doorAccess;
        }

    }
}
