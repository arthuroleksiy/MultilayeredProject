using System;
using System.Collections.Generic;
using BLL;
using DAL;


namespace MultilayerProject
{
    /// <summary>
    /// Change item presentation
    /// </summary>
    public class ChangeItemPL
    {
        /// <summary>
        /// Business logic for change item
        /// </summary>
        private readonly ChangeItemBLL changeItemController = new ChangeItemBLL();
        /// <summary>
        /// Main page view
        /// </summary>
        private readonly EnterPagePL enterPagePL = new EnterPagePL();
        /// <summary>
        /// Dictionnary contains actions for every field
        /// </summary>
        private readonly static Dictionary<ItemType, Action<int, string>> dictReports = new Dictionary<ItemType, Action<int, string>>();
        /// <summary>
        /// Check if input value belongs to specific type
        /// </summary>
        private Func<string, bool> isItemType; 
        /// <summary>
        /// Check id correctnes
        /// </summary>
        private Func<string, bool> isCorrectId; 
        /// <summary>
        /// Return integer id
        /// </summary>
        private Func<string, int> parseId;
        /// <summary>
        /// Get value for specific item
        /// </summary>
        private Func<string, ItemType> getItemByValue;
        /// <summary>
        /// Get list for specific item
        /// </summary>
        private Func<int, IEnumerable<IItem>> getItemById;
        /// <summary>
        /// Get whole list
        /// </summary>
        private readonly IEnumerable<IItem> wholeList;
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChangeItemPL()
        {
            wholeList = changeItemController.GetItems();
            dictReports.Add(ItemType.Name, new Action<int, string>(changeItemController.ChangeName));
            dictReports.Add(ItemType.Description, new Action<int, string>(changeItemController.ChangeDescription));
            dictReports.Add(ItemType.Price, new Action<int, string>(changeItemController.ChangePrice));
            dictReports.Add(ItemType.Category, new Action<int, string>(changeItemController.ChangeCategory));
            
        }
        /// <summary>
        /// Writing items
        /// </summary>
        public void ChangeItemMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Id  Name  Price  Category  Description");
            Console.WriteLine();
            foreach (var i in wholeList)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Price + " " + i.Category + " " + i.Description);
            }
            ChangeValue();
        }
        /// <summary>
        /// Change item menu
        /// </summary>
        public void ChangeValue()
        {
            string id = "";
            int resultId;
            string field = "";
            string j = "";
            isItemType += changeItemController.IsItemType;

            parseId += changeItemController.ParseId;

            isCorrectId += changeItemController.IsCorrectId;
            getItemByValue += changeItemController.GetItemValue;
            getItemById += changeItemController.GetItemById;
            Console.WriteLine();
            Console.WriteLine("Choose id of user's field that you want to change(0 to cancel):");
            id = Console.ReadLine();
            if (id.Equals("0"))
                enterPagePL.ChangeView();

            Console.WriteLine();
            Console.WriteLine("Choose field that you want to change(0 to cancel):");
            field = Console.ReadLine();
            
            if (field.Equals("0"))
                enterPagePL.ChangeView();

            Console.WriteLine();
            Console.WriteLine("Enter new value:");
            j = Console.ReadLine();


            if (isItemType(field) && isCorrectId(id))
            {
                resultId = parseId(id);
                dictReports[getItemByValue(field)](resultId, j);

                var result = getItemById(resultId);
                Console.WriteLine();
                Console.WriteLine("Changed value");

                Console.WriteLine();
                Console.WriteLine("Id  Name  Price  Category  Description");
                Console.WriteLine();
                foreach (var i in result)
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + i.Price + " " + i.Category+ " " + i.Description);
                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Wrong data");
            }


            ChangeValue();
         }
    }
}
