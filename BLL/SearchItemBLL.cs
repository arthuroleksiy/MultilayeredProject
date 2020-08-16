using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// Search item class with business logic
    /// </summary>
    public class SearchItemBLL
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchItemBLL()
        {

        }

        /// <summary>
        /// Gets items by chosen category
        /// </summary>
        /// <param name="category"><see cref="Category"/> value</param>
        /// <returns>Collection of <see cref="IItem"/></returns>
        public IEnumerable<IItem> ChosenCategory(Category category)
        {

            foreach (var i in MockAssortementRepsotory.Assortement)
            {
                if (i.Category == category)
                {
                    yield return i;
                }
            }

        }
        /// <summary>
        /// Check if assortement contains specific name
        /// </summary>
        /// <param name="result"></param>
        /// <returns>bool value</returns>
        /// <exception cref="NullReferenceException">Throws if result is empty</exception>
        public bool ContainsName(string result) 
        {
            NullReferenceException ex = new NullReferenceException("result");

            if (string.IsNullOrEmpty(result))
                throw ex;

            return MockAssortementRepsotory.Assortement.Select(i => i.Name).Contains(result);
        }
        /// <summary>
        /// Search collection of items bu specific name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Collection of <see cref="IItem"/></returns>
        /// <exception cref="NullReferenceException">Throws if input name is empty</exception>
        public IEnumerable<IItem> SearchByName(string name)
        {
            NullReferenceException ex = new NullReferenceException("name");

            if (string.IsNullOrEmpty(name))
                throw ex;

            foreach (var i in MockAssortementRepsotory.Assortement)
            {
                if (i.Name.Equals(name))
                {
                    yield return i;
                }
            }
        }
    }
}
