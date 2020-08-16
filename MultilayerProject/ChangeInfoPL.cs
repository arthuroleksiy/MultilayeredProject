using System;
using System.Collections.Generic;
using BLL;
using DAL;


namespace MultilayerProject
{/// <summary>
/// Change info presentation
/// </summary>
    public class ChangeInfoPL
    {
        /// <summary>
        /// Types of input fields
        /// </summary>
        private enum FieldType
        {
            Name,
            Surname,
            Telephone,
            Login, 
            Password
        }

        /// <summary>
        /// Main page view
        /// </summary>
        private readonly EnterPagePL enterPagePL = new EnterPagePL();
        /// <summary>
        /// Business logic for information change
        /// </summary>
        private readonly ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
        /// <summary>
        /// Dictionnary with delegates for every user's fiels
        /// </summary>
        private static readonly Dictionary<FieldType, Action<int,string>> dictReports = new Dictionary<FieldType, Action<int, string>>();
        /// <summary>
        /// Delegate to get all users list
        /// </summary>
        private readonly Func<IEnumerable<RegisteredUser>> users;
        /// <summary>
        /// Delegate to get id
        /// </summary>
        private readonly Func<int> getId;
        /// <summary>
        /// Delegate to get last user id
        /// </summary>
        private readonly Func<int> getLastId;
        /// <summary>
        /// Delegate to get type of field to change 
        /// </summary>
        private readonly Func<Type> getType;
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChangeInfoPL()
        {
            if (!dictReports.ContainsKey(FieldType.Name))
                dictReports.Add(FieldType.Name, new Action<int, string>(changeInfoController.ChangeName));

            if (!dictReports.ContainsKey(FieldType.Surname))
                dictReports.Add(FieldType.Surname, new Action<int, string>(changeInfoController.ChangeSurame));

            if (!dictReports.ContainsKey(FieldType.Telephone)) 
                dictReports.Add(FieldType.Telephone, new Action<int, string>(changeInfoController.ChangeTelephone));

            if (!dictReports.ContainsKey(FieldType.Login)) 
                dictReports.Add(FieldType.Login, new Action<int, string>(changeInfoController.ChangeLogin));

            if (!dictReports.ContainsKey(FieldType.Password))
                dictReports.Add(FieldType.Password, new Action<int, string>(changeInfoController.ChangePassword));


            getType += MockActiveUserRepository.WhoISLogged;
            getId += MockActiveUserRepository.GetId;
            users += changeInfoController.GetUsers;
            getLastId += MockRegisteredUserRepository.GetLastId;
        }
        /// <summary>
        /// Write values
        /// </summary>
        public void Output()
        {
            ChangeValue();
        }
        /// <summary>
        /// Write Users
        /// </summary>
        public void ShowPersons()
        {
            Console.WriteLine(" id        Name      Surname       TelephoneNumber     Login       Password ");

            Console.WriteLine();
            foreach (var i in users())
            {
                Console.WriteLine(i.RegisteresUserId + " \t" + i.Name + "\t " + i.Surname + "\t" + i.TelephoneNumber + "\t " + i.Login + "\t " + i.Password);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Output fields indexes
        /// </summary>
        public void OutputFields()
        {
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surame");
            Console.WriteLine("3. Telephone");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Password");
        }
        /// <summary>
        /// Chnage info
        /// </summary>
        public void ChangeValue()
        {
            string id = "";
            string field = "";
            string j = "";
            ShowPersons();
            try
            {
                if (getType() == typeof(User))
                    id = getId().ToString();
                else
                {
                    Console.WriteLine("Choose id of user's field that you want to change:");
                    id = Console.ReadLine();
                    if (Int32.TryParse(id, out int resultId))
                    {
                        if (id.Equals("0"))
                            enterPagePL.ChangeView();
                    } else
                    {
                        Console.WriteLine("Wrong choise");

                        enterPagePL.ChangeView();
                    }
                }
            } 
            catch (ArgumentException i)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Choose field that you want to change:");
            OutputFields();
            
            try
            {
                field = Console.ReadLine();
                if (Int32.TryParse(field, out int intField ) && intField >= 1 && intField <=5)
                {
                    if (field.Equals("0"))
                        enterPagePL.ChangeView();
                }
                else 
                {
                    Console.WriteLine("Wrong parameters");
                    enterPagePL.ChangeView();
                }
            }
            catch (ArgumentException i)
            {
                Console.WriteLine(i.Message);
            }

            Console.WriteLine("Enter value");

            try
            {
                 j = Console.ReadLine();
                if (j is null || j == "")
                    Console.WriteLine("Wrong parameter");
            } 
            catch(ArgumentException i)
            {
                Console.WriteLine(i.ToString());
            }

            if (Enum.TryParse(field, out FieldType fieldType)) 
            {

                if (Int32.TryParse(id, out int resultId) && getLastId() >= resultId) 
                {

                    if(resultId == 0 || fieldType == 0)
                    {
                        enterPagePL.ChangeView();

                    }
                    dictReports[--fieldType](resultId,j); 
                } 
                else
                {
                    enterPagePL.ChangeView();
                }
            }

            Output();
        }
    }
}
