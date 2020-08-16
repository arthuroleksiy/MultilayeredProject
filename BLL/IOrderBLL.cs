using DAL;
using System;
using System.Collections.Generic;


namespace BLL
{
    /// <summary>
    /// Interface for orders logic
    /// </summary>
    public interface IOrderBLL
    {
        /// <summary>
        /// Gets all orders
        /// </summary>
        /// <returns>Collection of <see cref="Order"/></returns>
        /// <exception cref="NullReferenceException">Throws if orders are empty</exception>
        public IEnumerable<Order> GetAllOrders();

        /// <summary>
        /// Check if current user good for order
        /// </summary>
        /// <returns>bool value</returns>
        public bool IsUserRole();

        /// <summary>
        /// Check if current user is signed in
        /// </summary>
        /// <param name="order"><see cref="Order"/> value</param>
        /// <returns>bool value</returns>
        /// <exception cref="NullReferenceException">Throws if order is null</exception>
        public bool IsCurrentUserLogined(Order order)
        {
            NullReferenceException ex = new NullReferenceException("Order is null");
            if (order == null)
                throw ex;

            return order.User.Login == MockActiveUserRepository.Login;
        }
    }
}
