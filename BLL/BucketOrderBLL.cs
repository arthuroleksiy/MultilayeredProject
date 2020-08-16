
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// Bucket order class with business logic
    /// </summary>
    public class BucketOrderBLL : IOrderBLL
    {
        /// <summary>
        /// Change status of bucket order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"><see cref="Status"/> type</param>
        /// <exception cref="IndexOutOfRangeException">return where id is out of range</exception>
        public void ChangeStatus(int id, Status status)
        {
            IndexOutOfRangeException ex = new IndexOutOfRangeException("id");
            if (id == 0 || id > GetLastId())
                throw ex;

            MockBucketOrderRepository.ChangeStatus(id, status);
        }
        
        /// <summary>
        /// Method gets first id
        /// </summary>
        /// <returns>int value of the first id</returns>
        /// <exception cref="IndexOutOfRangeException">Returns if index not in acceptable range</exception>
        public int GetFirstId()
        {
            IndexOutOfRangeException ex = new IndexOutOfRangeException("id");

            var result = MockBucketOrderRepository.Orders.Select(i => i).OrderBy(i => i.Id).Select(i => i.Id).FirstOrDefault();

            if (result == default)
                throw ex;

            return result;
        }
       /// <summary>
       /// Method get <see cref="Status"/> before changes
       /// </summary>
       /// <param name="intId"></param>
       /// <returns>Status</returns>
        public Status GetStatusBefore(int intId)
        {
            return MockBucketOrderRepository.Orders.Select(i => i).OrderBy(i => i.Id).Where(i => i.Id == intId).Select(j => j.Status).FirstOrDefault();
        }
        /// <summary>
        /// Get last id from bucket orders
        /// </summary>
        /// <returns>int value of id</returns>
        /// <exception cref="NullReferenceException">Returns if id not in range</exception>
        public int GetLastId()
        {
            NullReferenceException ex = new NullReferenceException("Orders");

            

            int lastId = MockBucketOrderRepository.GetLastId();

            if (lastId == 0)
                throw ex;

            if (MockOrderHistoryRepository.GetLastId() >= lastId)
                return MockOrderHistoryRepository.GetLastId();
            else
                return lastId;
        }
        /// <summary>
        /// Method returns all Orders
        /// </summary>
        /// <returns>Collection of <see cref="Order"/></returns>
        /// <exception cref="NullReferenceException">Resturns if collection is empty</exception>
        public IEnumerable<Order> GetAllOrders()
        {
            NullReferenceException ex = new NullReferenceException("Orders");

            if (MockBucketOrderRepository.Orders == null)
                throw ex;

            return MockBucketOrderRepository.Orders;
        }
        /// <summary>
        /// Get user role
        /// </summary>
        /// <returns>bool value</returns>
        public bool IsUserRole()
        {
            return MockActiveUserRepository.WhoISLogged() == typeof(User);
        }
        /// <summary>
        /// Check if current user is signed id
        /// </summary>
        /// <param name="order"></param>
        /// <returns>bool value</returns>
        /// <exception cref="NullReferenceException">Throw if any of orders do not belong to user</exception>
        public bool IsCurrentUserLogined(Order order)
        {

            NullReferenceException ex = new NullReferenceException("Order is null");
            if (order == null)
                throw ex;

            return order.User.Login == MockActiveUserRepository.Login;
        }
    }
}
