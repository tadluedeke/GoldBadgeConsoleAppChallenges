using ChallengeOne.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleOne.Test
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        [TestMethod]
        public void AddItemToMenu_ShouldReturnCorrectBool()
        {
            //Arrange
            MenuItem item = new MenuItem();
            MenuItemRepository repository = new MenuItemRepository();

            //Act
            bool addResult = repository.AddItemToMenu(item);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldGetCorrectBool()
        {
            MenuItem menuItem = new MenuItem();
            MenuItemRepository repository = new MenuItemRepository();
            repository.AddItemToMenu(menuItem);

            List<MenuItem> directory = repository.GetMenu();

            bool directoryHasMenuItem = directory.Contains(menuItem);
            Assert.IsTrue(directoryHasMenuItem);
        }

        private MenuItem _menuItem;
        private MenuItemRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _menuItem = new MenuItem(1, "Beef Ramen", "A hot bowl of beef ramen, garnished with half a soft-boiled egg", "egg noodles, beef, cabbage, leek, carrots, soy broth, herbs and spices, one half softboiled egg, black sesame seeds", 8.99m);
            _repo.AddItemToMenu(_menuItem);
        }

        [TestMethod]
        public void GetByNumber_ShouldReturnCorrectContent()
        {
            MenuItem searchResult = _repo.GetMenuItemByNumber(1);
            Assert.AreEqual(_menuItem, searchResult);
        }

        [TestMethod]
        public void UpdateExistingMeal_ShouldReturnUpdatedValue()
        {
            _repo.UpdateMenuItem(1, new MenuItem(2, "Pork Ramen", "A hot bowl of pork ramen, garnished with half a soft-boiled egg", "egg noodles, pork, cabbage, leek, carrots, soy broth, herbs and spices, one half softboiled egg, black sesame seeds", 7.99m));
            Assert.AreEqual(_menuItem.MealNumber, 2);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteMenuItem(1);
            Assert.IsTrue(wasDeleted);
        }
    }
}
