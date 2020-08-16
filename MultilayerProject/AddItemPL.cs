using System;
using System.Collections.Generic;
using BLL;
using DAL;

namespace MultilayerProject
{
    /// <summary>
    /// Adding item class
    /// </summary>
    public class AddItemPL
    {
        /// <summary>
        /// Adding item class
        /// </summary>
        private readonly AddItemBll addItemController = new AddItemBll();
        
        /// <summary>
        /// Business logic to work with supermarket assortment data
        /// </summary>
        private readonly AssortementBLL mockAssortementBLL = new AssortementBLL();
        
        /// <summary>
        /// Class that represents main menu page
        /// </summary>
        private readonly EnterPagePL enterPageView = new EnterPagePL();

        /// <summary>
        /// Delegate for adding item logic
        /// </summary>
        private readonly Action<string, string, string, string, string> addItem;
        
        /// <summary>
        /// Delegate for getting supermarket assortment
        /// </summary>
        private readonly Func<IEnumerable<IItem>> getAssortement;
        
        /// <summary>
        /// Delegate of users choise
        /// </summary>
        /// <param name="chose"></param>
        /// <param name="parsedChoise"></param>
        /// <returns>bool value</returns>
        public delegate bool GetChoise(string chose, out int parsedChoise);
        
        /// <summary>
        /// Declaring of GetChoise delegate
        /// </summary>
        private readonly GetChoise getChoise;
        
        /// <summary>
        /// Default constructor Initialize values
        /// </summary>
        public AddItemPL()
        {
            getChoise = addItemController.ParseChoise;
            addItem += addItemController.AddItem;
            getAssortement += mockAssortementBLL.GetAssortement;
        }
        /// <summary>
        /// Users choise
        /// </summary>
        public void StartAdding() 
        {
            string choise;
            Console.WriteLine();
            Console.WriteLine("Choose option");
            Console.WriteLine();
            Console.WriteLine("1. Add new item ");
            Console.WriteLine("2. Show items list");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            choise = Console.ReadLine();
            if (getChoise(choise, out int parsedChoise))
            {

                if (parsedChoise == 0)
                {
                    enterPageView.Choise();
                }
                else if (parsedChoise == 1)
                {
                    NewItem();
                    StartAdding();
                }
                else if (parsedChoise == 2)
                {
                    ShowAssortement();
                    StartAdding();
                }
            }
            else
            {
                Console.WriteLine("Wrong choise");
            }

        }

        /// <summary>
        /// User entering data and creating new <see cref="IItem"/>
        /// </summary>
        public void NewItem()
        {
            Console.Clear();
            Console.WriteLine("Enter name of new item");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter amount of new item (in format 0 or 0,00)");
            string number = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter description of new item");
            string description = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter price of new item  (in format 0 or 0,00)");
            string price = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter category of new item:");
            int j = 0;

            foreach(var i in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{j++} {i}");
            }
            Console.WriteLine();

            string category = Console.ReadLine();
            Console.WriteLine();

            addItem(name, number, description, price, category);
            StartAdding();

        }
        /// <summary>
        /// Show assortement
        /// </summary>
        public void ShowAssortement()
        {
            Console.WriteLine();
            foreach (var i in getAssortement())
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Description + " " + i.Price + " " + i.Category);
            }
            Console.WriteLine();

        }




    }
}
