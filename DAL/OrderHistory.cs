using System.Collections.Generic;


namespace DAL
{
    /// <summary>
    /// Order history class
    /// </summary>
    public class OrderHistory
    {
        /// <summary>
        /// Collection of <see cref="Order"/>
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }
        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="orders">Collection of <see cref="Order"/></param>
        public OrderHistory(IEnumerable<Order> orders)
        {
            this.Orders = orders;
        }
    }
}
