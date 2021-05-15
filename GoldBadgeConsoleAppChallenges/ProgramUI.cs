using ChallengeOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    class ProgramUI
    {
        private MenuItemRepository _repo = new MenuItemRepository();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option by number:\n" +
                    "1. Add Meal to Menu\n" +
                    "2. View all Meals\n" +
                    "3. View Meal by Number\n" +
                    "4. Update Existing Meal\n" +
                    "5. Delete Meal from Menu\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMeal();
                        break;
                    case "2":
                        //ViewAllMeals
                        break;
                    case "3":
                        //ViewMealByNumber
                        break;
                    case "4":
                        //UpdateExistingMeal
                        break;
                    case "5":
                        //DeleteMeal
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a number from the menu");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewMeal()
        {
            Console.Clear();
            MenuItem newMeal = new MenuItem();

            Console.WriteLine("Please assign this meal an unused meal number.");
            newMeal.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like this meal to be named?");

        }
    }
}
