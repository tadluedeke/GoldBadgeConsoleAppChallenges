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
                        ViewAllMeals();
                        break;
                    case "3":
                        ViewMealByNumber();
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
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter a description for this meal");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("List this meal's ingredients");
            newMeal.MealIngredients = Console.ReadLine();

            Console.WriteLine("Enter the price of this meal?");
            newMeal.MealPrice = Convert.ToDecimal(Console.ReadLine());

            bool wasAddedToMenu = _repo.AddItemToMenu(newMeal);
            if (wasAddedToMenu)
            {
                Console.WriteLine("The new menu item was successfully added");
            }
            else
            {
                Console.WriteLine("The new menu item was not added.");
            }
        }
        private void ViewAllMeals()
        {
            Console.Clear();
            List<MenuItem> allMenuItems = _repo.GetMenu();
            foreach (MenuItem meal in allMenuItems)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Price: {meal.MealPrice}");
            }
        }
        private void ViewMealByNumber()
        {
            Console.Clear();
            ViewAllMeals();
            Console.WriteLine("Enter the Meal Number for details on that meal");
            MenuItem meal = _repo.GetMenuItemByNumber(Convert.ToInt32(Console.ReadLine()));
            if(meal != null)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Meal Description: {meal.MealDescription}\n" +
                    $"Meal Ingredients: {meal.MealIngredients}\n" +
                    $"Meal Price: {meal.MealPrice}");
            }
            else
            {
                Console.WriteLine("There is no meal by that number");
            }
        }
    }
}
