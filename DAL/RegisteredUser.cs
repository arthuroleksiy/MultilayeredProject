

namespace DAL
{
    /// <summary>
    /// Derivered class from <see cref="IRegisteredUser"/>
    /// </summary>
    public class RegisteredUser: IRegisteredUser
    {
        /// <summary>
        /// RegisteresUserId value
        /// </summary>
        public int RegisteresUserId { get; set; }
        /// <summary>
        /// Name value
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname value
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Telephone number value 
        /// </summary>
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Login value
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Password value
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public RegisteredUser(int id, string name, string surname, string telephoneNumber, string login, string password)
        {
            this.RegisteresUserId = id;
            this.Name = name;
            this.Surname = surname;
            this.TelephoneNumber = telephoneNumber;
            this.Login = login;
            this.Password = password;
        }
    }
}
