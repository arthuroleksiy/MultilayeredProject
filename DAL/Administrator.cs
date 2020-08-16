using DAL;

namespace DAL
{
    /// <summary>
    /// Administrator class
    /// </summary>
    public class Administrator : RegisteredUser
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public Administrator(int id, string name, string surname, string telephoneNumber, string login, string password) : base(id, name, surname, telephoneNumber, login, password)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class that initialize base instace of the <see cref="RegisteredUser"/> class .
        /// </summary>
        public Administrator(): base(0, "", "", "", "", "")
        {

        }
    }
}
