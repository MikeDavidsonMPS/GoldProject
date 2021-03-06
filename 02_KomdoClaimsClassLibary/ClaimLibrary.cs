﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomdoClaimsClassLibrary
{
       // POCO
    public class ClaimLibrary
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double Settlement { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool Valid{ get; set; }
        

       public ClaimLibrary() { }

       public ClaimLibrary (int claimID, string claimType, string description, double settlement, DateTime incidentDate, DateTime claimDate, bool valid)
       {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Settlement = settlement;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            Valid = valid;
            
       }
        
    }
}
