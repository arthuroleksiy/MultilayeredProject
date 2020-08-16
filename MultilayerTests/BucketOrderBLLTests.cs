using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System;

namespace MultilayerTests
{
    [TestClass]
    public class BucketOrderBLLTests
    {
        private readonly BucketOrderBLL bucketOrderBLL;
        public BucketOrderBLLTests()
        {

            bucketOrderBLL = new BucketOrderBLL();
        }


        [TestMethod]
        public void GetFirstId_IsCorrect()
        {
            int actual = bucketOrderBLL.GetFirstId();
            

            Assert.AreEqual(3, actual);
            
        }
        [TestMethod]
        [DataRow(19)]
        public void GetStatusBefore_IsCorrectly(int intId)
        {
            var actual = bucketOrderBLL.GetStatusBefore(intId);
            Assert.AreEqual(Status.New, actual);
        }

        [TestMethod]
        public void GetLastId_IsCorrect()
        {
            int actual = bucketOrderBLL.GetLastId();
            

            Assert.AreEqual(3, actual);
        }

        public static IEnumerable<Order> expected = new List<Order>
            {
                new Order(1,Status.Finished, new List<IItem> {MockBucketOrderRepository.ChangeItemById<int>(1, 2), MockBucketOrderRepository.ChangeItemById<double>(4, 3.0) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(2)),

                new Order(2,Status.Cancelled_by_user, new List<IItem> { MockBucketOrderRepository.ChangeItemById<double>(3, 2.0), MockBucketOrderRepository.ChangeItemById<int>(15, 3) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(3))
            };

        
        
        [TestMethod]
        public void IsCurrentUserLogined_ResturnsTrue()
        {
            var order = new Order(1, Status.Finished, new List<IItem> { MockBucketOrderRepository.ChangeItemById<int>(1, 2), MockBucketOrderRepository.ChangeItemById<double>(4, 3.0) },
                new DateTime(2020, 01, 12, 12, 12, 12), MockRegisteredUserRepository.GetUserById(2));

            MockActiveUserRepository.Login = "petro79";
            var result = bucketOrderBLL.IsCurrentUserLogined(order);
            Assert.AreEqual(true, result);
        }

        
        [TestMethod]
        public void ChangeStatus_IsStatusChanged()
        {

            Thread.Sleep(400); 
            bucketOrderBLL.ChangeStatus(3, Status.Payment_required);
            var actual = MockBucketOrderRepository.Orders.Where(i => i.Id.Equals(3)).Select(i => i.Status).First();
            
            Assert.AreEqual(Status.Payment_required, actual);
        }
    }
}
