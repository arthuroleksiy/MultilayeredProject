using System;
using System.Collections.Generic;
using DAL;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// Change item class with business logic
    /// </summary>
    public class ChangeItemBLL
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChangeItemBLL() { }

        /// <summary>
        ///  Gets collection of items
        /// </summary>
        /// <returns>Collection of <see cref="IItem"/></returns>
        /// <exception cref="NullReferenceException">Throws if result is null</exception>
        public IEnumerable<IItem> GetItems()
        {
            NullReferenceException ex = new NullReferenceException("Assortement");

            if (MockAssortementRepsotory.Assortement is null)
                throw ex;

            return MockAssortementRepsotory.Assortement;
        }

        
        /// <summary>
        /// Checks number correctness
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool value</returns>
        public bool IsCorrectId(string id)
        {

            if (!Int32.TryParse(id, out int _))
                return false;

            return true;
        }
        /// <summary>
        /// Parses id to int
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int value</returns>
        public int ParseId(string id)
        {
            return Int32.Parse(id);
        }
        /// <summary>
        /// Changes name of item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeName(int id, string value)
        {
                foreach (var i in GetItems())
                {
                    if (i.Id == id)
                    {
                        i.Name = value;
                    }

                }
        }
        /// <summary>
        /// Gets item type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ItemType GetItemValue(string input)
        {
            ItemType outValue;
            outValue = (ItemType)Enum.Parse(typeof(ItemType), input);
            return outValue;
        }
        /// <summary>
        /// Check if value is items type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool value</returns>
        public bool IsItemType(string input)
        {

            if (!Enum.TryParse(input, out ItemType _))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Changes item description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeDescription(int id, string value)
        {
            foreach (var i in GetItems())
            {
                if (i.Id == id)
                {
                    i.Description = value;
                }

            }
        }
        /// <summary>
        /// Check price format correctness
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool value</returns>
        public bool IsPriceCorrect(string input)
        {

            if (!Double.TryParse(input, out double _))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Changes item price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangePrice(int id, string value)
        {
            decimal result = Decimal.Parse(value);

            foreach (var i in GetItems())
            {
                if (i.Id == id)
                {
                    i.Price = result;
                    i.TotalPrice = result;
                }
            }
        }

        /// <summary>
        /// Check if value is category type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool value</returns>
        public bool IsCategoryType(string input)
        {

            if (!Enum.TryParse(input, out Category _))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Changes category of item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeCategory(int id, string value)
        {
            Category result;
            result = (Category)Enum.Parse(typeof(Category),value);

            foreach (var i in GetItems())
            {
                if (i.Id == id)
                {
                    i.Category = result;
                }

            }
        }
        /// <summary>
        /// Returns collection of items
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns>Collection of <see cref="IItem"/></returns>
        public IEnumerable<IItem> GetItemById(int resultId) {
            return GetItems().Where(i => i.Id == resultId).Select(i => i);
        }
    }
}
