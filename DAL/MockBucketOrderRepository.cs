using System;
using System.Collections.Generic;
using System.Linq;
using DAL;


namespace DAL
{
    /// <summary>
    /// Create
    /// </summary>
    public static class MockBucketOrderRepository
    {
        /// <summary>
        /// Collectoin of <see cref="Order"/>
        /// </summary>
        public static IEnumerable<Order> Orders = new List<Order>
            {
                new Order(MockOrderHistoryRepository.GetLastId() + 1,Status.New, new List<IItem> {ChangeItemById<int>(15, 3), ChangeItemById<double>(4, 2.0) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(2)),

                new Order(MockOrderHistoryRepository.GetLastId() + 2,Status.Payment_required, new List<IItem> {ChangeItemById<double>(3, 2.0), ChangeItemById<int>(15, 3) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(3))
            };

        /// <summary>
        /// Changes order status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStatus"><see cref="Status"/> value</param>
        public static void ChangeStatus(int id, Status newStatus)
        {
                foreach(var i in Orders)
                {
                    if((i.Id == id) && (MockActiveUserRepository.WhoISLogged() == typeof(User)|| MockActiveUserRepository.WhoISLogged() == typeof(Guest)) && newStatus == Status.Cancelled_by_user &&  i.Status != Status.Recieved) 
                    { 
                            i.Status = newStatus;
                    }


                if (i.Id == id && (MockActiveUserRepository.WhoISLogged() == typeof(Administrator) || MockActiveUserRepository.WhoISLogged() == typeof(Guest)) && newStatus != Status.Cancelled_by_user)
                {
                    i.Status = newStatus;
                }

                if (i.Status == Status.Finished || i.Status == Status.Cancelled_by_user)
                    {
                        MockOrderHistoryRepository.AddOrderByParameters(i);
                        ((IList<Order>)Orders).Remove(i);
                        break;
                    }
                }
        }
        
        /// <summary>
        /// Add new orderr
        /// </summary>
        /// <param name="order"><see cref="Order"/></param>
        public static void AddOrderByParameters(Order order)
        {

            ((IList<Order>)Orders).Add(order);
            
            foreach (var i in Orders)
            {
                foreach(var j in i.Items) {
                    if (j is ItemByNumber)
                        Console.WriteLine(j.Id +" "+ j.Name +" "+ (j as ItemByNumber).Number+ " "+j.TotalPrice);
                    if (j is ItemByWeight)
                        Console.WriteLine(j.Id + " " + j.Name + " " + (j as ItemByWeight).Weight + " "+j.TotalPrice);

                }
            }
        }

       /// <summary>
       /// Change item by id
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="id"></param>
       /// <param name="quantity"></param>
       /// <returns>value of <see cref="IItem"/></returns>
        public static IItem ChangeItemById<T>(int id, T quantity)
        {
            foreach (var i in MockAssortementRepsotory.Assortement)
            {
                if (i.Id == id)
                {

                    if (typeof(T) == typeof(int) && (i is ItemByNumber))
                    {
                        int intQuantity = Convert.ToInt32(quantity);
                        ((ItemByNumber)i).Number = intQuantity;

                        ((ItemByNumber)i).Price = i.Price;
                        ((ItemByNumber)i).TotalPrice = intQuantity * i.Price;

                        return i;
                    }
                    else if (typeof(T) == typeof(double) && (i is ItemByWeight))
                    {
                        double doubleQuantity = Convert.ToDouble(quantity);
                        ((ItemByWeight)i).Weight = doubleQuantity;

                        ((ItemByWeight)i).Price = i.Price;
                        ((ItemByWeight)i).TotalPrice = (decimal)doubleQuantity * i.Price;

                        return i;
                    }
                    else
                    {
                        if (typeof(T) == typeof(int))
                        {

                            return new ItemByNumber(0, Convert.ToInt32(quantity), "", "", 0.0m, 0.0m, default);
                        }
                        else if ((typeof(T) == typeof(double)))
                        {

                            return new ItemByWeight(0, Convert.ToDouble(quantity), "", "", 0.0m, 0.0m, default);
                        }

                    }

                }

            }

            return null;
        }
        /// <summary>
        /// Last Order index
        /// </summary>
        /// <returns>int index</returns>
        public static int GetLastId()
        {
            return Orders.Select(i => i).OrderBy(i => i.Id).Select(i => i.Id).FirstOrDefault();
        }
    }
}
