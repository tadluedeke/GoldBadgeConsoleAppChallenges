using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
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
    }
}
