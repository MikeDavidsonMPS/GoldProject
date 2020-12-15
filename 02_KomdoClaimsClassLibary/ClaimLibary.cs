using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomdoClaimsClassLibary
{
    public enum ClaimTypes
    {
        Car = 1,
        Home,
        Theft
    }
    
       // POCO
    public class ClaimLibary
    {
        public int ClaimID { get; set; }
        public ClaimTypes TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimSettlement { get; set; }
        public double IncidentMonth { get; set; }
        public double IncidentDay { get; set; }
        public double IncidentYear { get; set; }
        public double ClaimMouth { get; set; }
        public double ClaimDay { get; set; }
        public double ClaimYear { get; set; }
        public bool Valid{ get; set; }
        

       public ClaimLibary() { }

       public ClaimLibary (int claimID, ClaimTypes claimType, string description, double settlement, double incidentMonth, double incidentDay, double incidentYear, double claimMonth, double claimDay, double claimYear, bool valid)
       {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = description;
            ClaimSettlement = settlement;
            IncidentMonth = incidentMonth;
            IncidentDay = incidentDay;
            IncidentYear = incidentYear;
            ClaimMouth = claimMonth;
            ClaimDay = claimDay;
            ClaimYear = claimYear;
            Valid = valid;
            
       }
        
    }
}
