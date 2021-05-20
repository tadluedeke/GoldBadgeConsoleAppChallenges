using ChallengeThree_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree_Test
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo = new BadgeRepository();
        private Badge _badge1;
        private Badge _badge2;

        [TestInitialize]
        public void Arrange()
        {
            _badge1 = new Badge();
            _badge1.BadgeID = 1;
            _badge1.Doors = new List<DoorID> { DoorID.A1 };
            _repo.CreateNewBadge(_badge1.BadgeID, _badge1.Doors);
            _badge2 = new Badge();
            _badge2.BadgeID = 2;
            _badge2.Doors = new List<DoorID> { DoorID.A1, DoorID.A2 };
            _repo.CreateNewBadge(_badge2.BadgeID, _badge2.Doors);
        }

        [TestMethod]
        public void CreateNewBadge_ShouldGetCorrectBoolean()
        {
            Badge badge = new Badge();

            bool addBadge = _repo.CreateNewBadge(badge.BadgeID, badge.Doors);

            Assert.IsTrue(addBadge);
        }

        [TestMethod]
        public void SeeAllBadges_ShouldReturnCorrectBoolean()
        {
            Dictionary<int, List<DoorID>> directory = _repo.SeeAllBadges();

            Assert.IsTrue(directory.Count == 2);
        }

        [TestMethod]
        public void SeeBadgeByID_ShouldReturnCorrectBadgeID()
        {
            Badge searchResult = _repo.SeeBadgeByID(1);

            Assert.AreEqual(_badge1.BadgeID, searchResult.BadgeID);
        }

        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            _repo.AddDoorToBadge(_badge1.BadgeID, DoorID.B1);

            Assert.IsTrue(_badge1.Doors.Count == 2);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            _repo.RemoveDoorFromBadge(_badge2.BadgeID, DoorID.A2);

            Assert.IsTrue(_badge2.Doors.Count == 1);
        }

    }
}
