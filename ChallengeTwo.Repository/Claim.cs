using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim {get; set;}
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                DateTime dateOfIncident = DateOfIncident;
                DateTime dateOfClaim = DateOfClaim;
                double claimDifference = (dateOfClaim - dateOfIncident).TotalDays;

                if ( claimDifference > 30)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine();
                    return true;
                }
            }
            
        }
        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
