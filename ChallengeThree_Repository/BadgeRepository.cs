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

        public bool AddDoorToBadge(int badgeID, DoorID newDoorID)
        {
            int countBefore = _listOfBadges[badgeID].Count;
                _listOfBadges[badgeID].Add(newDoorID);
            int countAfter = _listOfBadges[badgeID].Count;

            if (countAfter > countBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDoorFromBadge(int badgeID, DoorID doorID)
        {
            int countBefore = _listOfBadges[badgeID].Count;
            _listOfBadges[badgeID].Remove(doorID);
            int countAfter = _listOfBadges[badgeID].Count;
            
            if (countAfter < countBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

