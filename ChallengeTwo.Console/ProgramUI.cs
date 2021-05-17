using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "see all claims":
                        SeeAllClaims();
                        break;
                    case "2":
                    case "take care of next claim":
                        ProcessNextClaim();
                        break;
                    case "3":
                    case "enter a new claim":
                        EnterNewClaim();
                        break;
                    case "4":
                    case "exit":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid menu option");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            
            Console.WriteLine("Please assign this claim an unused claim ID number");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

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

            bool wasAddedToQueue = _repo.AddClaimToQueue(newClaim);
            if (wasAddedToQueue)
            {
                Console.WriteLine("The claim has been added to the queue.");
            }
            else
            {
                Console.WriteLine("Could not add claim to queue.");
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> allClaims = _repo.SeeAllClaims();
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Claim Description: {claim.ClaimDescription}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Claim Valid: {claim.IsValid}");
            }
        }

        private void ProcessNextClaim()
        {
            Console.Clear();
            Claim nextClaim = _repo.SeeNextClaim();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                    $"Claim Description: {nextClaim.ClaimDescription}\n" +
                    $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Is Claim Valid: {nextClaim.IsValid}\n" +
                    $"\n" +
                    $"Do you want to deal with this claim now(Y/N?)");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "y":
                    _repo.ProcessClaim();
                    break;
                case "n":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter Y or N");
                    break;
            }
        }
        
        private void SeedContentList()
        {
            Claim burstPipe = new Claim(1, ClaimType.Home, "A pipe burst in the kitchen, flooding the kitchen and finished basement.", 15000m, new DateTime(2012,02,08),new DateTime(2012,03,02));
            Claim carCrash = new Claim(1, ClaimType.Car, "One car ran into another during a funeral procession.", 1200m, new DateTime(2016, 04, 22), new DateTime(2016, 07, 05));
            Claim jewelHeist = new Claim(1, ClaimType.Theft, "Jewel thieves broke in, attacked Jared, and stole all of his jewels.", 200000m, new DateTime(2021,07,04), new DateTime(2021,07,06));
            _repo.AddClaimToQueue(burstPipe);
            _repo.AddClaimToQueue(carCrash);
            _repo.AddClaimToQueue(jewelHeist);
        }
    }
}
