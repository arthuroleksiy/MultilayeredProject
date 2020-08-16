using DAL;


namespace BLL
{
    /// <summary>
    /// Login page class with business logic
    /// </summary>
    public class LoginPageBLL
    {
        /// <summary>
        /// Current user value
        /// </summary>
        RegisteredUser currentUser;
        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPageBLL()
        {

        }
        /// <summary>
        /// Contains login value
        /// </summary>
        public string Login
        {
            set { MockActiveUserRepository.Login = value; }
            get { return MockActiveUserRepository.Login; }
        }
        /// <summary>
        /// Checks correcdt login data
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>bool value</returns>
        public bool CheckData(string login, string password)
        {
            if(login == null || password == null)
            {
                return false;
            }
            foreach (var i in MockRegisteredUserRepository.AllUsers)
            {
                if (i.Login == login && i.Password == password) 
                {
                   currentUser = i;
                   return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Changes current user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>bool value</returns>
        public bool ISCorrectLogin(string login, string password)
        {
            if (CheckData(login, password))
            {
                MockActiveUserRepository.CurrentUser = currentUser;
                return true;
            }

            return false;
        }

        
        


    }
}
