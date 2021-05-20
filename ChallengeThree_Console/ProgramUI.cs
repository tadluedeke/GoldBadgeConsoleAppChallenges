using ChallengeThree_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Console
{
    public class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a menu option by number.");
                        break;
                }
                Console.WriteLine("Please press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            newBadge.Doors = new List<DoorID>();
            Console.WriteLine("What is the badge number on the badge?");

            int newBadgeID = Convert.ToInt32(Console.ReadLine());
            newBadge.BadgeID = newBadgeID;

            Console.WriteLine("Would you like to assign door access to this badge (y/n)?");
            string input = Console.ReadLine();

            while (input == "y")
            {
                Console.WriteLine("List a door that it needs access to");
                string newDoor = Console.ReadLine();
                if (newDoor == "A1")
                {
                    DoorID newDoorID = DoorID.A1;
                    newBadge.Doors.Add(newDoorID);
                    
                }
                else if (newDoor == "A2")
                {
                    DoorID newDoorID = DoorID.A2;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "A3")
                {
                    DoorID newDoorID = DoorID.A3;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "A4")
                {
                    DoorID newDoorID = DoorID.A4;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "A5")
                {
                    DoorID newDoorID = DoorID.A5;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "B1")
                {
                    DoorID newDoorID = DoorID.B1;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "B2")
                {
                    DoorID newDoorID = DoorID.B2;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "B3")
                {
                    DoorID newDoorID = DoorID.B3;
                    newBadge.Doors.Add(newDoorID);
                }
                else if (newDoor == "B4")
                {
                    DoorID newDoorID = DoorID.B4;
                    newBadge.Doors.Add(newDoorID);
                }
                Console.WriteLine("Any other doors(y/n)?");
                input = Console.ReadLine();
            }
            if (_repo.CreateNewBadge(newBadgeID, newBadge.Doors))
            {
                Console.WriteLine("New badge successfully created");
            }
            else
            {
                Console.WriteLine("Could not create new badge.");
            }
            Console.Clear();
            Menu();
        }

        public void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<DoorID>> allBadges = _repo.SeeAllBadges();
            foreach (KeyValuePair<int, List<DoorID>> badge in allBadges)
            {
                Console.WriteLine($"Badge Number: {badge.Key}\n" +
                    $"Door Access: ");
                    foreach (DoorID doorID in badge.Value)
                {
                    Console.WriteLine(doorID);
                }
            }
        }

        public void EditBadge()
        {
            Console.Clear();
            ViewAllBadges();
            Console.WriteLine("Enter the badge number that you wish to edit");

            int badgeToEdit = Convert.ToInt32(Console.ReadLine());
            _repo.SeeBadgeByID(badgeToEdit);
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1. REMOVE a Door\n" +
                "2. ADD a door");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input.ToLower())
            {
                case "1":
                case "remove":
                    RemoveDoorFromBadge(badgeToEdit);
                    break;
                case "2":
                case "add":
                    AddDoorToBadge(badgeToEdit);
                    break;
                default:
                    Console.WriteLine("Please choose a number or type a corresponding command");
                    break;

            }
        }

        public void AddDoorToBadge(int badge)
        {
            Badge newBadge = new Badge();
            newBadge.Doors = new List<DoorID>();
            int newBadgeID = badge;
            newBadge.BadgeID = newBadgeID;
            DoorID newDoorID = new DoorID();

            Console.WriteLine("What door would you like to add to this badge?");

            string newDoor = Console.ReadLine();

            Console.WriteLine(newDoor);
            if (newDoor == "A1")
            {
                newDoorID = DoorID.A1;
                newBadge.Doors.Add(newDoorID);

            }
            else if (newDoor == "A2")
            {
                newDoorID = DoorID.A2;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "A3")
            {
                newDoorID = DoorID.A3;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "A4")
            {
                newDoorID = DoorID.A4;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "A5")
            {
                newDoorID = DoorID.A5;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "B1")
            {
                newDoorID = DoorID.B1;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "B2")
            {
                newDoorID = DoorID.B2;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "B3")
            {
                newDoorID = DoorID.B3;
                newBadge.Doors.Add(newDoorID);
            }
            else if (newDoor == "B4")
            {
                newDoorID = DoorID.B4;
                newBadge.Doors.Add(newDoorID);
            }

            bool wasAdded = _repo.AddDoorToBadge(newBadgeID, newDoorID);
            if (wasAdded)
            {
                Console.WriteLine("Door was added to badge");
            }
            else
            {
                Console.WriteLine("No badge corresponds with the provided badge number.");
            }
        }

        public void RemoveDoorFromBadge(int badge)
        {
            Badge newBadge = new Badge();
            newBadge.Doors = new List<DoorID>();
            int newBadgeID = badge;
            newBadge.BadgeID = newBadgeID;
            DoorID newDoorID = new DoorID();

            Console.WriteLine("What door would you like to Remove from this badge?");

            string newDoor = Console.ReadLine();

            Console.WriteLine(newDoor);
            if (newDoor == "A1")
            {
                newDoorID = DoorID.A1;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "A2")
            {
                newDoorID = DoorID.A2;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "A3")
            {
                newDoorID = DoorID.A3;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "A4")
            {
                newDoorID = DoorID.A4;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "A5")
            {
                newDoorID = DoorID.A5;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "B1")
            {
                newDoorID = DoorID.B1;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "B2")
            {
                newDoorID = DoorID.B2;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "B3")
            {
                newDoorID = DoorID.B3;
                newBadge.Doors.Remove(newDoorID);
            }
            else if (newDoor == "B4")
            {
                newDoorID = DoorID.B4;
                newBadge.Doors.Remove(newDoorID);
            }

            bool wasRemoved = _repo.RemoveDoorFromBadge(newBadgeID, newDoorID);
            if (wasRemoved)
            {
                Console.WriteLine("Door was removed from badge");
            }
            else
            {
                Console.WriteLine("Door was not removed from badge.");
            }
        }
    }
}
