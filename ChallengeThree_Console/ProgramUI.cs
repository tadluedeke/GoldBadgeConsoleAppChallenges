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
                        //EditBadge();
                        break;
                    case "3":
                        //ViewAllBadges();
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
            if (_repo.CreateNewBadge(newBadge))
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
    }
}
