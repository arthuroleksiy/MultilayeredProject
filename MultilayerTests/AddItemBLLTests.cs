using System;
using System.Linq;
using System.Collections.Generic;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultilayerTests.Comparers;

namespace MultilayerTests
{
    [TestClass]
    public class AddItemBLLTests
    {
        private readonly AddItemBll addItemBLL = new AddItemBll();

        private readonly ItemComparer itemComparer = new ItemComparer();


        [TestMethod]
        [DataRow("k" ,"1","", "100", "Drinks")]
        public void AddItem_IsAdded(string name, string amount, string description, string price, string category)
        {
            IEnumerable<IItem> expected = new List<IItem> {
                new ItemByNumber(MockAssortementRepsotory.GetLastId() + 1, Int32.Parse(amount), name, description, Decimal.Parse(price), Decimal.Parse(price) * Int32.Parse(amount), Category.Drinks)
             };
            addItemBLL.AddItem(name, amount, description, price, category);
            Assert.IsTrue(expected.SequenceEqual(new List<IItem> { MockAssortementRepsotory.GetItemById(MockAssortementRepsotory.GetLastId()) }, itemComparer));
        }

        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [TestMethod]
        public void ParseChoise_IsCorrect(string input)
        {
            
            var result = addItemBLL.ParseChoise(input, out int _);
            Assert.AreEqual(true,result);
        }



        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [TestMethod]
        public void IsIntResult_IsCorrect(string input)
        {

            var result = addItemBLL.IsIntResult(input, out int _);
            Assert.AreEqual(true, result);
        }

        [DataRow("0,00")]
        [DataRow("1,00")]
        [DataRow("2,00")]
        [TestMethod]
        public void IsDoubleResult_IsCorrect(string input)
        {


            var result = addItemBLL.IsDoubleResult(input, out double _);
            Assert.AreEqual(true, result);
        }

        [DataRow("Bakery")]
        [DataRow("Fruits_and_Vegetables")]
        [DataRow("Milk_products")]
        [TestMethod]
        public void IsCategoryType_IsCorrect(string input)
        {

            var result = addItemBLL.IsCategoryType(input, out Category _);
            Assert.AreEqual(true, result);
        }




        [DataRow("23")]
        [DataRow("23,50")]
        [DataRow("26,9999999")]
        [TestMethod]
        public void IsPrice_IsCorrect(string input)
        {
            var result = addItemBLL.IsPriceCorrect(input, out decimal _);
            Assert.AreEqual(true, result);
        }

    }
}
