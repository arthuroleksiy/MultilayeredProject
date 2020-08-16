
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using System.Linq;
using MultilayerTests.Comparers;
using System;

namespace MultilayerTests
{
    [TestClass]
    public class SearchItemControllerTests
    {
        private readonly ItemComparer itemComparer = new ItemComparer();

        private readonly SearchItemBLL _searchItemController;

        public SearchItemControllerTests()
        {
            _searchItemController = new SearchItemBLL();
        }

        [TestMethod]
        public void Search_ReturnCorrectForName()
        {
            string inputArgument = "Chicken";
            var actualResult = _searchItemController.SearchByName(inputArgument);
            IEnumerable<IItem> expectedResult = new List<IItem>
            {
                new ItemByWeight(10,1.00,"Chicken","",65.0m,65.0m, Category.Meat_and_fish)
            };


            Assert.AreEqual(expectedResult.Select(i => i.Id).Single(), actualResult.Select(i => i.Id).Single());
            Assert.AreEqual(expectedResult.Select(i => i.Name).Single(), actualResult.Select(i => i.Name).Single());
            Assert.AreEqual(expectedResult.Select(i => i.Price).Single(), actualResult.Select(i => i.Price).Single());
            Assert.AreEqual(expectedResult.Select(i => i.TotalPrice).Single(), actualResult.Select(i => i.TotalPrice).Single());
        }

        [TestMethod]
        [DataRow("Milk")]
        [DataRow("White bread")]
        public void ContainsName_True(string name)
        {
            var expected = true;
            var actual = _searchItemController.ContainsName(name);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsName_ReturnNullForName()
        {
            string inputArgument = null;
             _searchItemController.ContainsName(inputArgument);
        }
        
        [TestMethod]
        public void Search_ReturnCorrectForEnum()
        {
            Category inputArgument = Category.Household_Goods;
            var actualResult = _searchItemController.ChosenCategory(inputArgument);
            IEnumerable<IItem> expectedResult = new List<IItem>
            {
            new ItemByNumber(25,1,"Mr.Muscle", "", 65.0m,65.0m, Category.Household_Goods),
            new ItemByNumber(26,1,"Fairy", "", 45.50m,45.50m, Category.Household_Goods),
            new ItemByNumber(27,1,"Colgate", "", 50.0m,50.0m, Category.Household_Goods),
            new ItemByNumber(28,1,"Tide", "", 80.0m,80.0m, Category.Household_Goods)
            };
            


            Assert.IsTrue(expectedResult.SequenceEqual(actualResult, itemComparer), "Result is not as expected");
        }
    }

    
}
