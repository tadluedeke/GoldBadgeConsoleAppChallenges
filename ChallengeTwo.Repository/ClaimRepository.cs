using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();

        public bool AddClaimToQueue(Claim newClaim)
        {
            int startingCount = _claimQueue.Count;
            _claimQueue.Enqueue(newClaim);
            bool wasAdded = (_claimQueue.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<Claim> SeeAllClaims()
        {
            return _claimQueue;
        }

        public Claim SeeNextClaim()
        {
            return _claimQueue.Peek();
        }

        public Claim ProcessClaim()
        {
            return _claimQueue.Dequeue();
        }

        private readonly List<Claim> _claimList = new List<Claim>();

        public bool AddClaimToList(Claim newClaim)
        {
            int startingCount = _claimList.Count;
            _claimList.Add(newClaim);
            bool wasAdded = (_claimList.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Claim> SeeAllClaimsList()
        {
            return _claimList;
        }

        public Claim SeeClaimByID(int claimNumber)
        {
            foreach (Claim claim in _claimList)
            {
                if(claim.ClaimID == claimNumber)
                {
                    return claim;
                }
            }
            return null;
        }

        public bool UpdateClaim(int originalClaimID, Claim newClaimValues)
        {
            Claim oldClaim = SeeClaimByID(originalClaimID);
            if(oldClaim != null)
            {
                oldClaim.TypeOfClaim = newClaimValues.TypeOfClaim;
                oldClaim.ClaimDescription = newClaimValues.ClaimDescription;
                oldClaim.ClaimAmount = newClaimValues.ClaimAmount;
                oldClaim.DateOfIncident = newClaimValues.DateOfIncident;
                oldClaim.DateOfClaim = newClaimValues.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
