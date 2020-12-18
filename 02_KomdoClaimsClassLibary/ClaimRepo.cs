using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomdoClaimsClassLibrary
{
    public class ClaimRepo
    {
        private readonly Queue<ClaimLibrary> _claimsDir = new Queue<ClaimLibrary>();


        //CRUD

        //CREATE
        public void AddDataToList(ClaimLibrary data)
        {
            _claimsDir.Enqueue(data);
        }

        //READ
        public Queue<ClaimLibrary> GetClaimsLibary()
        {
            return _claimsDir;
        }

        //UPDATE
        public bool UpdateDataFromDir(int existingClaimID, ClaimLibrary newData)
        {
            //Find the original content
            ClaimLibrary existingData = GetDataByClaimID(existingClaimID);

            //Update the content
            if (existingData != null)
            {
                existingData.ClaimID = newData.ClaimID;
                existingData.ClaimType = newData.ClaimType;
                existingData.Description = newData.Description;
                existingData.Settlement = newData.Settlement;
                existingData.IncidentDate = newData.IncidentDate;
                existingData.ClaimDate = newData.ClaimDate;
                existingData.Valid = newData.Valid;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool RemoveDataFromDir(double claimID)
        {
            ClaimLibrary data = GetDataByClaimID(claimID);

            if (data == null)
            {
                return false;
            }

            int intialCount = _claimsDir.Count;
            _claimsDir.Dequeue();

            if (intialCount > _claimsDir.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //HELPER METHOD
        public ClaimLibrary GetDataByClaimID(double claimType)
        {
            foreach (ClaimLibrary data in _claimsDir)
            {
                if (data.ClaimID == claimType) 
                {
                    return data;
                }
                continue;
            }

            return null;

        }
    }
}
