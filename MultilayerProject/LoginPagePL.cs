using System;
using BLL;


namespace MultilayerProject
{
    /// <summary>
    /// Login page view
    /// </summary>
    class LoginPagePL
    {
        /// <summary>
        /// Check if users login correct
        /// </summary>
        public Func<string, string, bool> LoginUser;
        /// <summary>
        /// Business logic for login page
        /// </summary>
        public LoginPageBLL LoginPageController = new LoginPageBLL();
        
        /// <summary>
        /// Login property
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Password property
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPagePL()
        {
            LoginUser += LoginPageController.ISCorrectLogin;
        }
        /// <summary>
        /// Login process
        /// </summary>
        public void LoginProcess()
        {
            Output();
            StartSignIn();

            EnterPagePL enterPageView = new EnterPagePL();
            enterPageView.Output();
            enterPageView.Choise();
        }
        /// <summary>
        /// Input property method
        /// </summary>
        public void Output()
        { 
            Console.WriteLine("Enter login:");
            Login = Console.ReadLine();
            Console.WriteLine("Password:");
            Password = Console.ReadLine();
            
        }
        /// <summary>
        /// Process of users authentification
        /// </summary>
        public void StartSignIn()
        {

            if (LoginUser(Login, Password))
            {
                Console.WriteLine("Successfull authentififcation");
                LoginPageController.Login = Login;
            }
            else
                Console.WriteLine("Authentififcation failed");
        }
    }
}
