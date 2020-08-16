using System;
using DAL;
using BLL;
using System.Collections.Generic;


namespace MultilayerProject
{
    /// <summary>
    /// See order history class
    /// </summary>
    public class SeeOrderHistoryPL
    {
        /// <summary>
        /// Enter page Ciew
        /// </summary>
        private readonly EnterPagePL enterPageView = new EnterPagePL();
        /// <summary>
        /// Business logic for order history
        /// </summary>
        private readonly SeeOrderHistoryBLL seeOrderHistoryBLL = new SeeOrderHistoryBLL();
        /// <summary>
        /// Delegate that returns list of orders
        /// </summary>
        private readonly Func<IEnumerable<Order>> getOrders;
        /// <summary>
        /// Delegate that check user's role
        /// </summary>
        private readonly Func<bool> isUserRole;
        /// <summary>
        /// Delegate to check signed in user
        /// </summary>
        private readonly Func<Order, bool> isUserLogined;
        /// <summary>
        /// Default construcyor
        /// </summary>
        public SeeOrderHistoryPL()
        {
            getOrders += seeOrderHistoryBLL.GetAllOrders;
            isUserRole += seeOrderHistoryBLL.IsUserRole;
            isUserLogined += ((IOrderBLL)seeOrderHistoryBLL).IsCurrentUserLogined;
        }

        /// <summary>
        /// Output result order
        /// </summary>
        /// <param name="i"><see cref="Order"/></param>
        public void OutputUserData(Order i)
        {

            decimal price = 0;

            Console.WriteLine(i.Id + " " + i.Date + " " + i.Status + " " + i.User.Login);

            foreach (var j in i.Items)
            {
                if (j is ItemByNumber)
                    Console.WriteLine(j.Id + " " + j.Name + " " + ((ItemByNumber)j).Number + " " + j.Price);
                else if (j is ItemByWeight)
                    Console.WriteLine(j.Id + " " + j.Name + " " + ((ItemByWeight)j).Weight + " " + j.Price);

                price += j.Price;
            }
            Console.WriteLine();
            Console.WriteLine(price);
        }
        /// <summary>
        /// Input order
        /// </summary>
        public void InputOrder()
        {
            foreach (var i in getOrders())
            {
                if (isUserRole())
                {
                    if (isUserLogined(i))
                    {
                        OutputUserData(i);
                    }
                }
                else
                {
                    OutputUserData(i);
                }


            }

            Console.ReadKey();
            enterPageView.Output();
            enterPageView.Choise();
        }
    }
}

