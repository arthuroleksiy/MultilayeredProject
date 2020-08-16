using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    /// <summary>
    /// Assortement class with business logic
    /// </summary>
    public class AssortementBLL
    {
        /// <summary>
        ///  Method that returns supermarket assortment
        /// </summary>
        /// <returns>Collection of <see cref="IItem"/></returns>
        public IEnumerable<IItem> GetAssortement()
        {
            NullReferenceException nullReferenceException = new NullReferenceException("Assortement");
            
            if (MockAssortementRepsotory.Assortement is null)
                throw nullReferenceException;
            
            return MockAssortementRepsotory.Assortement;
        }
    }
}
