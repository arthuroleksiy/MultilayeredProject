using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using MultilayerTests.Comparers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultilayerTests
{
    [TestClass]
    public class ChangeItemControllerTests
    {

        private readonly ChangeItemBLL changeItemController = new ChangeItemBLL();
        private readonly ItemComparer itemComparer = new ItemComparer();

        
        [TestMethod]
        public void IsCorrectId_ReturnTrue()
        {

            var expected = true;
            var result = changeItemController.IsCorrectId("4");
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void IsItemType_ReturnTrue()
        {
            var expected = true;
            var result = changeItemController.IsItemType("Price");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsPriceCorrect_ReturnTrue()
        {
            var expected = true;
            var result = changeItemController.IsPriceCorrect("1000,00");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsCategoryType_ReturnTrue()
        {
            var expected = true;
            var result = changeItemController.IsCategoryType("Sweets");
            Assert.AreEqual(expected, result);
        }



        [TestMethod]
        [DataRow(8, "abc")]
        public void ChangeDescription_returnCorrect(int id, string value)
        {
            IEnumerable<IItem> expected = new List<IItem>
            {

            
            new ItemByNumber(8,1,"Milk", "abc", 23.0m,23.0m, Category.Milk_products),
                       };

            changeItemController.ChangeDescription(id, value);

            var actual = changeItemController.GetItemById(8);

            Assert.IsTrue(expected.SequenceEqual(actual, itemComparer));
        }

        [TestMethod]
        [DataRow(15,"asd")]
        public void ChangeName_isChanged(int id, string value)
        {
            IEnumerable<IItem> expected = new List<IItem>
            {
            new ItemByNumber(15, 1, "asd", "", 20.0m, 20.0m, Category.Packet_cereals)
            };

            changeItemController.ChangeName(id,value);

            var actual = changeItemController.GetItemById(15);

            Assert.AreEqual(expected.Where(i => i.Id == id).Select(i => i.Name).First(), actual.Where(i => i.Id == id).Select(i => i.Name).First());

        }
        [TestMethod]
        [DataRow("Name")]
        public void GetItemValue_ReturnCorrect(string input)
        {
            var expected = ItemType.Name;
            var actual = changeItemController.GetItemValue(input);
            Assert.AreEqual(expected,actual);
        }

        


        [TestMethod]
        [DataRow(7, "110")]
        public void ChangePrice_returnCorrect(int id, string value)
        {
            IEnumerable<IItem> expected = new List<IItem>
            {
            new ItemByWeight(7,1.00,"Potato","",110m,110m, Category.Fruits_and_Vegetables),

            };

            changeItemController.ChangePrice(id, value);

            var actual = changeItemController.GetItemById(7);

            Assert.IsTrue(expected.SequenceEqual(actual, itemComparer));
        }

        [TestMethod]
        [DataRow(11,"Drinks")]
        public void ChangeCategory_returnCorrect(int id, string value)
        {
            IEnumerable<IItem> expected = new List<IItem>
            {
             new ItemByWeight(11,1.00,"Pork","",180.0m,180.0m, Category.Drinks),
            };

            Thread.Sleep(700);
            changeItemController.ChangeCategory(id, value);

            var actual = changeItemController.GetItemById(11);

            Assert.IsTrue(expected.SequenceEqual(actual, itemComparer));
        }

        [TestMethod]
        public void GetItemById_returnValue()
        {
            IEnumerable<IItem> expected = new List<IItem>
            {
                new ItemByNumber(13,1,"Canned vegetables", "", 45.0m,45.0m, Category.Canned_food)
            };

            var actual = changeItemController.GetItemById(13);

            Assert.IsTrue(expected.SequenceEqual(actual, itemComparer));
        }
    }
}
