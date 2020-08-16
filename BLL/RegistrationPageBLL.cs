using System.Collections.Generic;
using DAL;

namespace BLL
{
    /// <summary>
    /// Registration Page class with business logic
    /// </summary>
    public class RegistratiionPageBLL
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool RegisterRole(string name, string surname, string telephoneNumber, string login, string password)
        {
            if (name != null && surname != null && telephoneNumber != null && login != null && password != null && !MockRegisteredUserRepository.Contains(login))
            {
                ((IList<RegisteredUser>)MockRegisteredUserRepository.AllUsers).Add(new User(MockRegisteredUserRepository.GetLastId() + 1, name, surname, telephoneNumber, login, password));
                MockActiveUserRepository.CurrentUser = new Guest();
                return true;
            }
           
        return false;
        }
    }
}
