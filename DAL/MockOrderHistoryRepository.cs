using System;
using System.Collections.Generic;


namespace DAL
{
    /// <summary>
    /// Repository with history of orders
    /// </summary>
    public static class MockOrderHistoryRepository
    {

        /// <summary>
        /// Collection of <see cref="Order"/>
        /// </summary>
            public static IEnumerable<Order> Orders = new List<Order>
            {
                new Order(1,Status.Finished, new List<IItem> {ChangeItemById<int>(1, 2), ChangeItemById<double>(4, 3.0) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(2)),

                new Order(2,Status.Cancelled_by_user, new List<IItem> {ChangeItemById<double>(3, 2.0), ChangeItemById<int>(15, 3) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(3))
            };

        /// <summary>
        /// Add new <see cref="Order"/> by parameters
        /// </summary>
        /// <param name="status"></param>
        /// <param name="items"></param>
        /// <param name="date"></param>
        /// <param name="user"></param>
        public static void AddOrder(Status status, IEnumerable<IItem> items, DateTime date, RegisteredUser user)
        {
            if (date == default || user is null || ((IList<IItem>)items).Equals(null))
            {
                throw new ArgumentNullException("date");
            }
                
            ((IList<Order>)Orders).Add(new Order(GetLastId(), status, items, date, user));
            
        }
        /// <summary>
        /// Add <see cref="Order"/> to orders list
        /// </summary>
        /// <param name="order"></param>
        public static void AddOrderByParameters(Order order)
        {
            ((IList<Order>)Orders).Add(order);
        }
        /// <summary>
        /// Gets last id
        /// </summary>
        /// <returns>Last int id</returns>
        public static int GetLastId()
        {
            NullReferenceException ex = new NullReferenceException("Orders");
            if (((IList<Order>)Orders).Count == 0)
            {
                throw ex;
            }

            int lastId = 0;
            foreach(var i in Orders)
            {
                if(i.Id > lastId)
                {
                    lastId = i.Id;
                }
            }
            return lastId;
        }
        /// <summary>
        /// Change <see cref="IItem"/> by specific id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns><see cref="IItem"/> value</returns>
        public static IItem ChangeItemById<T>(int id, T quantity)
        {
            foreach(var i in MockAssortementRepsotory.Assortement)
            {
                if(i.Id == id)
                {
                    
                    if (typeof(T) == typeof(int) && (i is ItemByNumber))
                    { 
                        int intQuantity = Convert.ToInt32(quantity);
                        ((ItemByNumber)i).Number = intQuantity;
                        ((ItemByNumber)i).TotalPrice = intQuantity * i.Price;
                        
                        return i;
                    } 
                    else if(typeof(T) == typeof(double) && (i is ItemByWeight))
                    {
                        double doubleQuantity = Convert.ToDouble(quantity);
                        ((ItemByWeight)i).Weight = doubleQuantity;
                        ((ItemByWeight)i).TotalPrice = (decimal)doubleQuantity * i.Price;
                        
                        return i;
                    }
                    else
                    {
                        if(typeof(T) == typeof(int))
                        {

                            return new ItemByNumber(0, Convert.ToInt32(quantity), "", "", 0.0m, 0.0m, default);
                        } 
                        else if((typeof(T) == typeof(double))) 
                        {

                            return new ItemByWeight(0, Convert.ToDouble(quantity), "", "", 0.0m, 0.0m, default);
                        }

                    }
                    
                }

            }

            return null;
        }
       


    }
}
