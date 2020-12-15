using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomdoClaimsClassLibary
{
    class ClaimRepo
    {
        private List<ClaimsDir> _listOfClaimsData = new List<ClaimsDir>();


        //CRUD

        //CREATE
        public void AddDataToList(ClaimsDir data)
        {
            _listOfClaimsData.Add(data);
        }

        //READ
        public List<ClaimsDir> GetClaimsDir()
        {
            return _listOfClaimsData;
        }

        //UPDATE
        public bool UpdateExistingData(int existingClaimID, ClaimsDir newData)
        {
            //Find the original content
            ClaimsDir currentData = GetDataByClaimID(existingClaimID);

            //Update the content
            if (currentData != null)
            {
                currentData.ClaimID = newData.ClaimID;
                currentData.TypeOfClaim = newData.TypeOfClaim;
                currentData.Description = newData.Description;
                currentData.ClaimSettlement = newData.ClaimsSettlement;
                currentData.IncidentMonth= newData.IncidentMonth;
                currentData.IncidentDay = newData.IncidentDay;
                currentData.IncidentYear = newData.IncidentDay;
                currentData.ClaimMonth = newData.ClaimMonth;
                currentData.ClaimDay = newData.ClaimDay;
                currentData.ClaimYear = newData.ClaimYear;
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
            ClaimDir data = GetDataByClaimID(claimID);

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
        public ClaimDir GetDataByClaimType(int claimType)
        {
            foreach (ClaimDir data in _listOfClaimsData)
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
}
