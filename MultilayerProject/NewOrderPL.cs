using System;
using System.Collections.Generic;
using DAL;
using BLL;

namespace MultilayerProject
{
    /// <summary>
    /// New order presentation class
    /// </summary>
    public class NewOrderPL
    {
        /// <summary>
        /// Business logic for making new order
        /// </summary>
        private readonly NewOrderBLL newOrderController = new NewOrderBLL();
        /// <summary>
        /// function yhat gets list of items for specific category
        /// </summary>
        private Func<Category, IEnumerable<IItem>> funcCategoty;
        /// <summary>
        /// Action that forms order
        /// </summary>
        private Action<Order, List<IItem>> formOrder;
        /// <summary>
        /// Get item with specific id
        /// </summary>
        private Func<int, IItem> funcId;
        /// <summary>
        /// Main page view
        /// </summary>
        private readonly EnterPagePL enterPageView = new EnterPagePL();
        /// <summary>
        /// Count total price for order
        /// </summary>
        private Func<List<IItem>, decimal> countPrice;
        /// <summary>
        /// Search item view
        /// </summary>
        private readonly SearchItemPL SearchItemView = new SearchItemPL();
        /// <summary>
        /// Chosen items list
        /// </summary>
        private IEnumerable<IItem> ResultedEnumerbale;
        /// <summary>
        /// List of items
        /// </summary>
        private readonly List<IItem> items;
        /// <summary>
        /// Chosen order
        /// </summary>
        private readonly Order order;
        /// <summary>
        /// input integer amount
        /// </summary>
        private int intResult = default;
        /// <summary>
        /// input double amount
        /// </summary>
        private double doubleResult = default;
        /// <summary>
        /// Default constructor
        /// </summary>
        public NewOrderPL()
        {
            items = new List<IItem>();
            order = new Order();
        }
        /// <summary>
        /// Buy item
        /// </summary>
        public void BuyingItems()
        {

            Output();
            Category enm = default;
            UserChoise(ref enm);
            OutputResult(enm);
            ChooseItem(enm);
        }

       
        /// <summary>
        /// Write result
        /// </summary>
        public  void Output()
        {

            Console.Clear();
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. " + Category.Bakery);
            Console.WriteLine("2. " + Category.Fruits_and_Vegetables);
            Console.WriteLine("3. " + Category.Milk_products);
            Console.WriteLine("4. " + Category.Meat_and_fish);
            Console.WriteLine("5. " + Category.Canned_food);
            Console.WriteLine("6. " + Category.Packet_cereals);
            Console.WriteLine("7. " + Category.Drinks);
            Console.WriteLine("8. " + Category.Sweets);
            Console.WriteLine("9. " + Category.Household_Goods);
            Console.WriteLine("10. " + "Show ordered goods");
            Console.WriteLine("11. " + "Show goods name");
            Console.WriteLine("12. " + "End order");
            Console.WriteLine("0. " + "Back");
            Console.WriteLine();

        }
        /// <summary>
        /// User choise
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        public void UserChoise(ref Category enm)
        {

            funcCategoty += newOrderController.ChosenCategory;
            formOrder += newOrderController.FormOrder;
            try
            {

                
                string result = Console.ReadLine();
                
                if(Int32.TryParse(result, out int intResult) && intResult == 10)
                {
                    ShowOrderedGoods(ref enm);
                }
                else if (Int32.TryParse(result, out intResult) && intResult == 11)
                {
                    SearchByName();
                    ResultedEnumerbale = new List<IItem>();
                    Console.WriteLine();

                }
                else if (Int32.TryParse(result, out intResult) && intResult == 12)
                {
                    Console.WriteLine("Your final order:");
                    formOrder(order, items);
                    ShowOrderedGoods(ref enm);
                    Console.WriteLine();

                } 
                else if (Int32.TryParse(result, out intResult) && intResult == 0) 
                {
                    enterPageView.Output();
                    enterPageView.Choise();
                }
                else if (Int32.TryParse(result, out intResult) && intResult > 0 && intResult < 10)
                {
                    ResultedEnumerbale = funcCategoty((Category)(--intResult));
                }
                else
                {

                    Console.WriteLine("Wrong choise");
                    BuyingItems();
                }
            }
            catch
            {
                Console.WriteLine("Wrong choise");
            }
        }
        /// <summary>
        /// Search by name
        /// </summary>
        public void SearchByName()
        {
            Category nameEnm = default;
            SearchItemView.SearchNameResult();
            SearchItemView.OutputResult(nameEnm);
            nameEnm = default;
            UserChoise(ref nameEnm);
        }


        /// <summary>
        /// Write result
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        public void OutputResult(Category enm)
        {

            Console.Clear();
            Console.WriteLine("Category " + enm);
            Console.WriteLine("Choose good:");

            foreach (var i in ResultedEnumerbale)
            {
                if (!((i as ItemByNumber) is null))
                {

                    Console.WriteLine(i.Id + " " + i.Name + " " + ((ItemByNumber)i).Number + " " + i.Price + " ");

                }
                else if (!((i as ItemByWeight) is null))
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + ((ItemByWeight)i).Weight + " " + i.Price + " ");

                }
            }

            Console.WriteLine("0. Back");
            Console.WriteLine("");




        }
        /// <summary>
        /// Choose Item
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        public void ChooseItem(Category enm)
        {
            int id = 0;
            ChooseId(ref enm, ref id);
            ChooseQuantity(ref enm);
            funcId += MockAssortementRepsotory.GetItemById;
            var chosenItem = funcId(id);
            //!!!
            if (chosenItem is ItemByNumber) 
            {
                
                (chosenItem as ItemByNumber).Number = intResult;
                (chosenItem as ItemByNumber).TotalPrice = intResult * chosenItem.Price;
                
                if(intResult != default)
                    items.Add(chosenItem);
            } 
            else if(chosenItem is ItemByWeight)
            {
                (chosenItem as ItemByWeight).Weight = doubleResult;
                (chosenItem as ItemByWeight).TotalPrice = (decimal)doubleResult * chosenItem.Price;

                if (doubleResult != default)
                    items.Add(chosenItem);

            }


            BuyingItems();
            
        } 
        /// <summary>
        /// Show goods
        /// </summary>
        /// <param name="enm"></param>
        public void ShowOrderedGoods(ref Category enm)
        {
            countPrice += newOrderController.CountTotalResult;
            Console.Clear();
            foreach(var i in items)
            {
                if (i is ItemByNumber)
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + (i as ItemByNumber).Number + " "+ i.TotalPrice);
                }
                else if (i is ItemByWeight)
                {
                    Console.WriteLine(i.Id + " " + i.Name + " "+ (i as ItemByWeight).Weight + " "+ i.TotalPrice);
                }
                
            }
            Console.WriteLine("Final amount: " +countPrice(items));
            Console.WriteLine();
            Console.WriteLine("0. Back");

            string j = Console.ReadLine();

            if (Int32.TryParse(j, out int intResult) && intResult == 0)
            {
                enm = default;
                Output();
                UserChoise(ref enm);
            } 
            else
            {
                ShowOrderedGoods(ref enm);
            }
        }
        /// <summary>
        /// Choose Id
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        /// <param name="id"></param>
        public void ChooseId(ref Category enm, ref int id)
        {
            Console.WriteLine("Choose product Id (0 to cancel)");

            if (Int32.TryParse(Console.ReadLine(), out int result) && result != 0) 
            { 
                    id = result;
                    enm = default;
                } 
            }
       
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enm"></param>
        public void ChooseQuantity(ref Category enm)
        {
            Console.WriteLine("Choose product Quantity (0 to cancel)");
            try
            {
                string userChoise = Console.ReadLine();

                
                if (Double.TryParse(userChoise, out double doubleRes) && (enm == Category.Fruits_and_Vegetables || enm == Category.Meat_and_fish)) 
                {
                    doubleResult = doubleRes;
                    enm = default;
                }
                else if (Int32.TryParse(userChoise, out int intRes))
                {
                    intResult = intRes;
                    enm = default;
                }
                else
                {
                    Console.WriteLine("Wrong number!");
                }
            }
            catch
            {
                Console.WriteLine("Wrong choise");
            }
        }

    }
}