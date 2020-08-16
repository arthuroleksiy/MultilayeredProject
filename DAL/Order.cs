using System;
using System.Collections.Generic;
using DAL;

namespace DAL
{
    /// <summary>
    /// Enum represents Orsers status
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// New order
        /// </summary>
        New,
        /// <summary>
        /// Order cancelled by administrtor order
        /// </summary>
        Cancelled_by_administrator,
        /// <summary>
        /// Order cancelled by user 
        /// </summary>
        Cancelled_by_user,
        /// <summary>
        /// Payment reuired for order
        /// </summary>
        Payment_required,
        /// <summary>
        /// Order has been sent
        /// </summary>
        Sent,
        /// <summary>
        /// Order has been recieved
        /// </summary>
        Recieved,
        /// <summary>
        /// Order is finished
        /// </summary>
        Finished
    }
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id value
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// <see cref="Status"/> value
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Collection of <see cref="IItem"/>
        /// </summary>
        public IEnumerable<IItem> Items { get; set; }
        /// <summary>
        /// <see cref="DateTime"/> value
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Id value
        /// </summary>
        public int RegisteredUserId { get; set; }
        /// <summary>
        /// <see cref="RegisteredUser"/> value
        /// </summary>
        public RegisteredUser User { get; set; }
        /// <summary>
        /// Paameters constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Status"></param>
        /// <param name="Items"></param>
        /// <param name="Date"></param>
        /// <param name="User"></param>
        public Order(int id, Status Status, IEnumerable<IItem> Items, DateTime Date, RegisteredUser User)
        {
            this.Id = id;
            this.Status = Status;
            this.Items = Items;
            this.Date = Date;
            this.User = User;

        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Order()
        {

        }


    }
}
