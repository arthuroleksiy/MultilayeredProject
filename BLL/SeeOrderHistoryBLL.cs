using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    /// <summary>
    /// See order history class with business logic
    /// </summary>
    public class SeeOrderHistoryBLL : IOrderBLL
    {

        /// <summary>
        /// Gets all orders
        /// </summary>
        /// <returns>Collection of <see cref="Order"/></returns>
        /// <exception cref="NullReferenceException">Throws if orders are empty</exception>
        public IEnumerable<Order> GetAllOrders()
        {
            NullReferenceException ex = new NullReferenceException("Orders");

            if (MockOrderHistoryRepository.Orders == null)
                throw ex;

            return MockOrderHistoryRepository.Orders;
        }

        /// <summary>
        /// Check if current user good for order
        /// </summary>
        /// <returns>bool value</returns>
        public bool IsUserRole()
        {
           return MockActiveUserRepository.WhoISLogged() == typeof(User);
        }
       
    }
}
