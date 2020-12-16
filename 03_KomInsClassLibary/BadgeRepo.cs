using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomInsClassLibary
{
    public class BadgeRepo
    {
        private readonly List<BadgeLibary> _badgeDir = new List<BadgeLibary>();

        //Dirtionary


        
        //CRUD

        //CREATE
        public void AddDataToList(BadgeLibary data)
        {
            _badgeDir.Add(data);
        }

        //READ
        public List<BadgeLibary> GetBadgeLibary()
        {
            return _listOfBadgeDirData;
        }

        //UPDATE
        public bool UpdateExistingData(int existingClaimID, BadgeLibary newData)
        {
            //Find the original content
            Libary currentData = GetDataByClaimID(existingClaimID);

            //Update the content
            if (currentData != null)
            {
                currentData.ClaimID = newData.ClaimID;
                currentData.ClaimType = newData.ClaimType;
                currentData.Description = newData.Description;
                currentData.Settlement = newData.Settlement;
                currentData.IncidentDate = newData.IncidentDate;
                currentData.ClaimDate = newData.ClaimDate;
                currentData.Valid = newData.Valid;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool RemoveDataFromList(int claimID)
        {
            ClaimLibary data = GetDataByClaimID(claimID);

            if (data == null)
            {
                return false;
            }

            int intialCount = _listOfClaimsData.Count;
            _listOfClaimsData.Remove(data);

            if (intialCount > _listOfClaimsData.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //HELPER METHOD
        public ClaimLibary GetDataByClaimType(string claimType)
        {
            foreach (ClaimLibary data in _listOfClaimsData)
            {
                if (data.ClaimType.ToLower() == claimType.ToLower())
                {
                    return data;
                }
                continue;
            }

            return null;
        }
}
