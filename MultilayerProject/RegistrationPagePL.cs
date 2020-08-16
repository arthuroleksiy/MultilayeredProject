using System;
using BLL;

namespace MultilayerProject
{
    /// <summary>
    /// Registration view class
    /// </summary>
    class RegistrationPagePL
    {
        /// <summary>
        /// Delegate that register's new user
        /// </summary>
        public Func<string, string, string , string, string, bool> registerUser;
        /// <summary>
        /// Class that contains registration logic
        /// </summary>
        private readonly RegistratiionPageBLL registrationPageController = new RegistratiionPageBLL();
        /// <summary>
        /// Class of main page view
        /// </summary>
        private readonly EnterPagePL enterPageView = new EnterPagePL();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegistrationPagePL()
        {
            registerUser += registrationPageController.RegisterRole;
        }
        /// <summary>
        /// Process of registration
        /// </summary>
        public void Output()
        {

            Console.WriteLine("User Registartion:");
            Console.WriteLine();

            Console.WriteLine("Name:");
            var Name = Console.ReadLine();
            Console.WriteLine("Surname:");
            var Surname = Console.ReadLine();
            Console.WriteLine("Telephone number:");
            var Telephone = Console.ReadLine();
            Console.WriteLine("Enter login:");
            var Login = Console.ReadLine();
            Console.WriteLine("Password:");
            var Password = Console.ReadLine();
            var result = registerUser(Name,Surname,Telephone,Login, Password);
            RegistrationResult(result);

        }
        /// <summary>
        /// Registration result
        /// </summary>
        /// <param name="result"></param>
        public void RegistrationResult(bool result)
        {
            if (result)
                Console.WriteLine("User have been regitered");
            else
                Console.WriteLine("User haven't been regitered");

            enterPageView.Output();
            enterPageView.Choise();
        }
    }
}
