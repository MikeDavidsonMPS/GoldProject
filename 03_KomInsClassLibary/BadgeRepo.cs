using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomInsClassLibrary
{
    public class BadgeRepo
    {
        private readonly List<BadgeAccessDir> _badgeDir = new List<BadgeAccessDir>();

        //Dirtionary



        //CRUD

        //CREATE
        public void AddDataToList(BadgeAccessDir data)
        {
            _badgeDir.Add(data);
        }

        //READ
        public List<BadgeAccessDir> GetBadgeAccessDir()
        {
            return _badgeDir;
        }

        //UPDATE
        public bool UpdateExistingBadgeDir(int existingBadgeID, BadgeAccessDir newData)
        {
            //Find the original content
            BadgeAccessDir currentData = GetDataByBadgeID(existingBadgeID);

            //Update the content
            if (currentData != null)
            {
                currentData.BadgeID = newData.BadgeID;
                currentData.DoorAccess = newData.DoorAccess;


                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool RemoveDataFromBadgeDir(double badgeID)
        {
            BadgeAccessDir data = GetDataByBadgeID(badgeID);

            if (data == null)
            {
                return false;
            }

            int intialCount = _badgeDir.Count;
            _badgeDir.Remove(data);

            if (intialCount > _badgeDir.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //HELPER METHOD
        public BadgeAccessDir GetDataByBadgeID(double badgeID)
        {
            foreach (BadgeAccessDir data in _badgeDir)
            {
                if (data.BadgeID == badgeID)
                {
                    return data;
                }
                continue;
            }

            return null;
        }
    }
}

