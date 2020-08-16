using DAL;

namespace DAL
{
    /// <summary>
    /// Derived class from <see cref="RegisteredUser"/> class
    /// </summary>
    public class User: RegisteredUser
    {
        /// <summary>
        /// Parametrized constructor, which initialize constructor of <see cref="RegisteredUser"/> entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public User(int id, string name, string surname, string telephoneNumber, string login, string password) :base(id, name,surname,telephoneNumber,login,password)
        {
        }
        /// <summary>
        /// Default constructor, which initialize constructor of <see cref="RegisteredUser"/> entity
        /// </summary>
        public User() :base(0, "", "", "", "", "")
        {

        }
    }
}
