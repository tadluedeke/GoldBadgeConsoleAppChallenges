using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, List<DoorID>> _listOfBadges = new Dictionary<int, List<DoorID>>();
        public bool CreateNewBadge(Badge newBadge)
        {
            int startingCount = _listOfBadges.Count;

            _listOfBadges.Add(newBadge.BadgeID, newBadge.Doors);

            bool wasAdded = (_listOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, List<DoorID>> SeeAllBadges()
        {
            return _listOfBadges;
        }
    }

}
