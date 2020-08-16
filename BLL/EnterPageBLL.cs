using DAL;
using System;


namespace BLL
{
    /// <summary>
    /// Enter page class with business logic
    /// </summary>
    public class EnterPageBLL
    {
        /// <summary>
        /// Gets logged user type
        /// </summary>
        /// <returns>Type value</returns>
        public Type GetLoggedUser() {
            return MockActiveUserRepository.WhoISLogged();
        }

    }
}
