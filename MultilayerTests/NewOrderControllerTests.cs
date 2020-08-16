using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using System.Collections.Generic;
using MultilayerTests.Comparers;
using System.Linq;
using System;

namespace MultilayerTests
{
   [TestClass]
    public class NewOrderControllerTests
    {



        private readonly NewOrderBLL newOrderBLL = new NewOrderBLL();

        private readonly OrderComparer orderComparer = new OrderComparer();
        private readonly ItemComparer itemComparer = new ItemComparer();

        private readonly IEnumerable<IItem> expected1 = new List<IItem> {
            new ItemByNumber(13, 1, "Canned vegetables", "", 45.0m, 45.0m, Category.Canned_food),
            new ItemByNumber(14, 1, "Canned olives", "", 60m, 60m, Category.Canned_food)
        };
        
        public NewOrderControllerTests()
        {
        }
        [TestMethod]
        public void ChosenCategory_ReturnsCorrectList()
        {
            var category = Category.Canned_food;
            var expected = new List<IItem> {
            new ItemByNumber(13, 1, "Canned vegetables", "", 45.0m, 45.0m, Category.Canned_food),
            new ItemByNumber(14, 1, "Canned olives", "", 60m, 60m, Category.Canned_food)};
            var actual = newOrderBLL.ChosenCategory(category);
            Assert.IsTrue(expected.SequenceEqual(actual,itemComparer));

        }
        
        [TestMethod]
        public void GetDataForOrder_ReturnsCorrectData()
        {
        
            var result = newOrderBLL.GetDataForOrder();
            var id = MockBucketOrderRepository.GetLastId() + 1;
            var date = DateTime.Today;
            var user = MockActiveUserRepository.CurrentUser;
            Assert.AreEqual(result.Item1, id);
            Assert.AreEqual(result.Item2.Date, date);
            Assert.AreEqual(user.GetType(), result.Item3);
        }
        [TestMethod]
        public void FormOrder_NewOrderAdded()
        {
            var input = new Order(MockOrderHistoryRepository.GetLastId() + 1, Status.New, new List<IItem> {  },
                 new DateTime(2020, 01, 12, 12, 12, 12), MockRegisteredUserRepository.GetUserById(2));
           
            newOrderBLL.FormOrder(input, new List<IItem> { MockBucketOrderRepository.ChangeItemById<int>(15, 3), MockBucketOrderRepository.ChangeItemById<double>(4, 2.0) });
            IEnumerable<IItem> items = new List<IItem> { MockBucketOrderRepository.ChangeItemById<int>(15, 3), MockBucketOrderRepository.ChangeItemById<double>(4, 2.0) };
            input.Items = items;
            var actual = MockBucketOrderRepository.Orders.OrderBy(i => i.Id).Last();
            Assert.IsTrue(orderComparer.Equals(input, actual));

        }
        
        [TestMethod]
        public void CountTotalResult_IsCorrect()
        {
            var expected = 105.0m;
            var actual = newOrderBLL.CountTotalResult(expected1.ToList());
            Assert.AreEqual(expected, actual);
        }
    }
}
