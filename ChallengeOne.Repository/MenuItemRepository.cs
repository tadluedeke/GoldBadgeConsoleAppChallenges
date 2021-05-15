using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _menuDirectory = new List<MenuItem>();
        
        //Create
        public bool AddItemToMenu(MenuItem newItem)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(newItem);
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<MenuItem> GetMenu()
        {
            return _menuDirectory;
        }

        //Specific Read
        public MenuItem GetMenuItemByNumber(int mealNumber)
        {
            foreach (MenuItem meal in _menuDirectory)
            {
                if(meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }
            return null;
        }

        //Update
        public bool UpdateMenuItem(int originalMealNumber, MenuItem newMealValue)
        {
            MenuItem oldMenuItem = GetMenuItemByNumber(originalMealNumber);
            if(oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMealValue.MealNumber;
                oldMenuItem.MealName = newMealValue.MealName;
                oldMenuItem.MealDescription = newMealValue.MealDescription;
                oldMenuItem.MealIngredients = newMealValue.MealIngredients;
                oldMenuItem.MealPrice = newMealValue.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteMenuItem(int numberToDelete)
        {
            MenuItem itemToDelete = GetMenuItemByNumber(numberToDelete);
            if(itemToDelete == null)
            {
                return false;
            }
            else
            {
                _menuDirectory.Remove(itemToDelete);
                return true;
            }
        }
    }
}
