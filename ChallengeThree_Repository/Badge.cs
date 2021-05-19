using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public enum DoorID{ A1, A2, A3, A4, A5, B1, B2, B3, B4 }
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<DoorID> Doors { get; set; }

        public Badge() { }
        public Badge(int badgeID, List<DoorID> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }
    }
}
