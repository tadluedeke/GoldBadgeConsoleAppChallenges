using ChallengeOne.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleOne.Test
{
    [TestClass]
    public class UnitTest1
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
    }
}
