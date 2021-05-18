using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI_Manager
    {
        private ClaimRepository _repo = new ClaimRepository();
        public bool _keepRunning = true;
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            while (_keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Claims\n" +
                    "2. Update Claim" +
                    "3. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        UpdateClaim();
                        break;
                    case "3":
                        ExitProgram();
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            List<Claim> allClaims = _repo.SeeAllClaimsList();
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Claim Description: {claim.ClaimDescription}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Claim Valid: {claim.IsValid}\n");
            }
        }
        private void UpdateClaim()
        {
            Console.Clear();
            ViewAllClaims();
            Console.WriteLine("Enter the Claim ID number you would like to update");

            int oldID = Convert.ToInt32(Console.ReadLine());

            Claim newClaim = new Claim();

            Console.WriteLine("Please enter the number for the Claim Type.\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = Convert.ToInt32(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Please enter a brief description of the claim.");
            newClaim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Please enter the amount of the claim.");
            newClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("What was the date of the incident (YYYY,MM,DD)?");
            string dateOfIncidentAsString = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(dateOfIncidentAsString);
            newClaim.DateOfIncident = dateOfIncident;

            Console.WriteLine("What is the date of the claim (YYYY,MM,DD)?");
            string dateofClaimAsString = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(dateofClaimAsString);
            newClaim.DateOfClaim = dateOfClaim;

            bool wasUpdated = _repo.UpdateClaim(oldID, newClaim);
            if (wasUpdated)
            {
                Console.WriteLine("The claim has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update claim.");
            }
        }

        private void ExitProgram()
        {
            _keepRunning = false;
        }
    }
}
