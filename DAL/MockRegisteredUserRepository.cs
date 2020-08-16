using System.Collections.Generic;


namespace DAL
{
    /// <summary>
    /// Create repository with registered users
    /// </summary>
    public static class MockRegisteredUserRepository
    {
        /// <summary>
        /// Collection of <see cref="RegisteredUser"/>
        /// </summary>
        public static IEnumerable<RegisteredUser> AllUsers { get; set; } =
            new List<RegisteredUser>
            {
                new Administrator(1,"Bogdan","Oliynik","+380674567890","bogdan","abcd"),
                new User(2, "Peter", "Dinklaidge", "+380983214576", "petro79", "ukr234"),
                new User(3, "Tiffany", "Fail", "+380983214575", "kitty87", "youw"),

                //new User(4, "a", "b", "+c", "d", "e"),


                //new User(5, "f", "g", "+h", "i", "g")

            };

        /// <summary>
        /// Do system contains login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>bool value</returns>
        public static bool Contains(string login)
        {
            foreach(var i in AllUsers)
            {
                if (i.Login == login)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Get <see cref="RegisteredUser"/> bu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="RegisteredUser"/> object</returns>
        public static RegisteredUser GetUserById(int id)
        {
            foreach(var i in AllUsers)
            {
                if (i.RegisteresUserId == id)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Get last id
        /// </summary>
        /// <returns>int id</returns>
        public static int GetLastId()
        {
            if (((IList<RegisteredUser>)AllUsers).Count == 0)
            {
                return 1;
            }

            int lastId = 0;
            foreach (var i in AllUsers)
            {
                if (i.RegisteresUserId > lastId)
                {
                    lastId = i.RegisteresUserId;
                }
            }
            return lastId;
        }

    }
}
