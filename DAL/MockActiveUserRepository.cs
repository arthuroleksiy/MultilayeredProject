using System;
using System.Linq;
using DAL;

namespace DAL
{
    /// <summary>
    /// Represents current user
    /// </summary>
    public static class MockActiveUserRepository
    {
        /// <summary>
        /// <see cref="IRole"/> value
        /// </summary>
        public static IRole CurrentUser { get; set; } = new Guest();
        /// <summary>
        /// Login value
        /// </summary>
        public static string Login { get; set; } = "";

        /// <summary>
        /// Returns type of current 
        /// </summary>
        /// <returns></returns>
        public static Type WhoISLogged()
        {
            return CurrentUser.GetType();    
        }
        /// <summary>
        /// Gets id of current user
        /// </summary>
        /// <returns></returns>
        public static int GetId()
        {
           return MockRegisteredUserRepository.AllUsers.Where(i => i.Login == Login).Select(i => i.RegisteresUserId).FirstOrDefault();
        }
    }
}
