using ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo.Test
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddClaimToQueue_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();

            bool addResult = repository.AddClaimToQueue(claim);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void SeeAllClaims_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToQueue(claim);

            Queue<Claim> directory = repository.SeeAllClaims();
            bool directoryHasClaim = directory.Contains(claim);

            Assert.IsTrue(directoryHasClaim);
        }

        [TestMethod]
        public void SeeAllClaimsList_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToList(claim);

            List<Claim> directory = repository.SeeAllClaimsList();
            bool directoryHasClaim = directory.Contains(claim);

            Assert.IsTrue(directoryHasClaim);
        }

        [TestMethod]
        public void AddClaimToList_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();

            bool addResult = repository.AddClaimToList(claim);

            Assert.IsTrue(addResult);
        }


        private Claim _claim;
        private ClaimRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(77, ClaimType.Car, "Hit a deer. He hit me back.", 1500m, new DateTime(2019, 12, 25), new DateTime(2019, 12, 30));
            _repo.AddClaimToQueue(_claim);
            _repo.AddClaimToList(_claim);
        }

        [TestMethod]
        public void PeekNextClaim_ShouldReturnCorrectInfo()
        {
            Claim nextClaim = _repo.SeeNextClaim();

            Assert.AreEqual(nextClaim, _claim);
        }

        [TestMethod]
        public void DequeueNextClaim_ShouldReturnEqual()
        {
            Claim nextClaim = _repo.ProcessClaim();

            Assert.AreEqual(nextClaim, _claim);
        }

        [TestMethod]
        public void SeeClaimByID_ShouldReturnEqual()
        {
            Claim claimByID = _repo.SeeClaimByID(77);

            Assert.AreEqual(claimByID, _claim);
        }

        [TestMethod]
        public void UpdateClaim_ShouldReturnUpdatedValue()
        {
            _repo.UpdateClaim(77, new Claim (77, ClaimType.Home, "Juvenile human female squatting in bear's home", 100000m, new DateTime(1876, 4, 18), new DateTime(1876, 6, 24)));

            Assert.AreEqual(100000m, _claim.ClaimAmount);
        }

    }
}
