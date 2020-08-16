using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    /// <summary>
    /// Add item class with business logic
    /// </summary>
    public class AddItemBll
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AddItemBll()
        {

        }
        /// <summary>
        /// Add new Item to assortement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        public void AddItem(string name, string amount, string description, string price, string category)
        {

            if (IsIntResult(amount, out int intResult) && IsPriceCorrect(price, out decimal parsedPrice) && IsCategoryType(category, out Category parsedCategory))
            {
                ((IList<IItem>)MockAssortementRepsotory.Assortement).Add(new ItemByNumber(MockAssortementRepsotory.GetLastId() + 1, intResult, name, description, parsedPrice, parsedPrice, parsedCategory));
                Console.WriteLine("New item has been added");
            }
            else if (IsDoubleResult(amount, out double doubleResult) && IsPriceCorrect(price, out parsedPrice) && IsCategoryType(category, out parsedCategory))
            {
                ((IList<IItem>)MockAssortementRepsotory.Assortement).Add(new ItemByWeight(MockAssortementRepsotory.GetLastId() + 1, doubleResult, name, description, parsedPrice, parsedPrice, parsedCategory));
                Console.WriteLine("New item has been added");
            }
            else
                Console.WriteLine("Wrong parameters");

        }
        /// <summary>
        /// Check if choise is correct
        /// </summary>
        /// <param name="choise"></param>
        /// <param name="result"></param>
        /// <returns>bool result</returns>
        public bool ParseChoise(string choise, out int result)
        {
            if (!Int32.TryParse(choise, out result) && result >=0 && result <= 2)
            {
                Console.WriteLine("Wrong intput data");

                return false;
            }

            return true;
        }


        /// <summary>
        /// Check if input type is int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="intResult"></param>
        /// <returns>bool result</returns>
        public bool IsIntResult(string value, out int intResult)
        {

            if (!Int32.TryParse(value, out intResult) && intResult >= 0) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if input type is double
        /// </summary>
        /// <param name="value"></param>
        /// <param name="doubleResult"></param>
        /// <returns>bool result</returns>
        public bool IsDoubleResult(string value, out double doubleResult)
        {

            if (!Double.TryParse(value, out doubleResult) && doubleResult >= 0)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Check if input type is <see cref="Category"/>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outValue"><see cref="Category"/> type</param>
        /// <returns>bool result</returns>
        public bool IsCategoryType(string input, out Category outValue)
        {

            if (!Enum.TryParse(input, out outValue))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if price is correct
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns>bool result</returns>
        public bool IsPriceCorrect(string input, out decimal result)
        {
            
            if (!Decimal.TryParse(input, out result))
            {
                return false;
            }

            return true;
        }


        
    }
}

