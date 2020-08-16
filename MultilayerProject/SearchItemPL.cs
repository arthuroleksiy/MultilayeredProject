
using DAL;
using System;
using System.Collections.Generic;
using BLL;


namespace MultilayerProject
{
    /// <summary>
    /// Search item
    /// </summary>
    public class SearchItemPL
    {
        /// <summary>
        /// Delegate that gets item list for specific category
        /// </summary>
        private readonly Func<Category, IEnumerable<IItem>> funcCategoty;
        /// <summary>
        /// Delegate check if items list contains name
        /// </summary>
        private readonly Func<string, bool> contains;
        /// <summary>
        /// Gets list of items for specific string
        /// </summary>
        private readonly Func<string, IEnumerable<IItem>> funcName;
        /// <summary>
        /// Search item logic
        /// </summary>
        private readonly SearchItemBLL SearchItemController = new SearchItemBLL();
        /// <summary>
        /// Main page view
        /// </summary>
        private readonly EnterPagePL enterPagePL = new EnterPagePL();
        /// <summary>
        /// Contains list of recieved items
        /// </summary>
        private IEnumerable<IItem> ResultedEnumerbale;
        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchItemPL()
        {

            funcCategoty += SearchItemController.ChosenCategory;
            funcName += SearchItemController.SearchByName;
            contains += SearchItemController.ContainsName;
        }
        /// <summary>
        /// Write choise
        /// </summary>
        public virtual void Output()
        {
            Console.Clear();
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. "+ Category.Bakery);
            Console.WriteLine("2. " + Category.Fruits_and_Vegetables);
            Console.WriteLine("3. " + Category.Milk_products);
            Console.WriteLine("4. " + Category.Meat_and_fish);
            Console.WriteLine("5. " + Category.Canned_food);
            Console.WriteLine("6. " + Category.Packet_cereals);
            Console.WriteLine("7. " + Category.Drinks);
            Console.WriteLine("8. " + Category.Sweets);
            Console.WriteLine("9. " + Category.Household_Goods);
            Console.WriteLine("10. Search by name");
            Console.WriteLine("0. " + "Back");
            Console.WriteLine();
            
        }
        /// <summary>
        /// Serfing In List
        /// </summary>
        public void SerfingInList()
        {
            Category enm = default;
            Output();
            UserChoise(ref enm);
            OutputResult(enm);
            ChooseNextStep();
        }
        /// <summary>
        /// User choise
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        public virtual void UserChoise(ref Category enm)
        {

            try
            {
                string result = Console.ReadLine();

                if (Int32.TryParse(result, out int intResult) && intResult == 10)
                {
                    SearchName();

                }
                else if (Int32.TryParse(result, out intResult) && intResult == 0)
                {
                    enterPagePL.Output();
                    enterPagePL.Choise();

                }
                else if (Int32.TryParse(result, out intResult) && intResult > 0 && intResult < 11)
                {

                    ResultedEnumerbale = funcCategoty((Category)(--intResult));
                }
                else
                {
                    UserChoise(ref enm);
                }
            }
            catch 
            {
                Console.WriteLine("Wrong choise");
            }
        }
        /// <summary>
        /// Search Name
        /// </summary>
        public void SearchName()
        {
            Category nameEnm = default;
            SearchNameResult();
            OutputResult(nameEnm);
        }
        /// <summary>
        /// Search name result
        /// </summary>
        public void SearchNameResult()
        {
            
            try
            {
                Console.Clear();
                Console.WriteLine("Enter product name");
                string result = Console.ReadLine();
                if (contains(result))
                    ResultedEnumerbale = funcName(result);
                else
                {
                    ResultedEnumerbale = new List<IItem>();
                    Console.WriteLine("Wrong input");
                }
            }
            catch
            {
                Console.WriteLine("Wrong input");
            }
        }
        
        /// <summary>
        /// Write result
        /// </summary>
        /// <param name="enm"><see cref="Category"/></param>
        public void OutputResult(Category enm)
        {
            if (ResultedEnumerbale is null)
            {
                NullReferenceException exception = new NullReferenceException("ResultedEnumerable is null");
                throw exception;
            }

            Console.Clear();
            Console.WriteLine("Choose good:");
            Console.WriteLine("Category " + enm);

            foreach (var i in ResultedEnumerbale) 
            {

                if (!((i as ItemByNumber) is null))
                {

                    Console.WriteLine(i.Id + " " + i.Name + " " + ((ItemByNumber)i).Number + " " + i.Price + " ");

                } 
                else if(!((i as ItemByWeight) is null))
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + ((ItemByWeight)i).Weight + " " + i.Price + " ");

                }
            }

            Console.WriteLine("0. Back");
            Console.WriteLine("");
        }
        /// <summary>
        /// Choose next step
        /// </summary>
        public void ChooseNextStep()
        {
            try
            {
                string result = Console.ReadLine();
                if (Int32.TryParse(result, out int intResult) && intResult == 0)
                {
                    Console.Clear();
                    SerfingInList();
                }
                else
                {
                    ChooseNextStep();
                }
            }
            catch
            {
                Console.WriteLine(" ");
                
            }
        }   
    }
}
