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
        public bool CreateNewBadge(int newBadge, List<DoorID> doorIDs)
        {
            int startingCount = _listOfBadges.Count;

            _listOfBadges.Add(newBadge, doorIDs);

            bool wasAdded = (_listOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, List<DoorID>> SeeAllBadges()
        {
            return _listOfBadges;
        }

        public Badge SeeBadgeByID(int badgeID)
        {
            Badge badge = new Badge(badgeID, _listOfBadges[badgeID]);

            if (_listOfBadges.ContainsKey(badgeID))
            {
                return badge;
            }
            else
            {
                return null;
            }
        }

        public void AddDoorToBadge(int badgeID, DoorID newDoorID)
        {
                _listOfBadges[badgeID].Add(newDoorID);
        }

        public bool RemoveDoorFromBadge()
        {
            return true;
        }
    }
}

