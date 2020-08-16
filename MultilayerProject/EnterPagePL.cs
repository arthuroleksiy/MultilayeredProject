using System;
using System.Threading.Tasks;
using DAL;
using BLL;


namespace MultilayerProject
{
    /// <summary>
    /// Starting page
    /// </summary>
    public class EnterPagePL
    {
        /// <summary>
        /// Business logic for main page
        /// </summary>
        private readonly EnterPageBLL enterPageBLL = new EnterPageBLL();
        /// <summary>
        /// Default constructor
        /// </summary>
        public EnterPagePL()
        {

        }
        /// <summary>
        /// Output procedure
        /// </summary>
        public void Output()
        {
            Console.Clear();

            if (enterPageBLL.GetLoggedUser() == typeof(Administrator))
            {
                Console.WriteLine("1. See goods list");
                Console.WriteLine("2. Make new order");
                Console.WriteLine("3. See basket orders");
                Console.WriteLine("4. Change personal info");
                Console.WriteLine("5. See order history");
                Console.WriteLine("6. Change item");
                Console.WriteLine("7. Add item");
                Console.WriteLine("8. Sign out");
                Console.WriteLine();
            }
            else if (enterPageBLL.GetLoggedUser() == typeof(User))
            {
                Console.WriteLine("1. See goods list");
                Console.WriteLine("2. Make new order");
                Console.WriteLine("3. See basket orders");
                Console.WriteLine("4. See order history");
                Console.WriteLine("5. Change personal info");
                Console.WriteLine("6. Sign out");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("1. See goods list");
                Console.WriteLine("2. Sign in");
                Console.WriteLine("3. Sign up");
                Console.WriteLine();
            }
        }

       
        /// <summary>
        /// Make choise
        /// </summary>
        public void Choise()
        {
            Output();
            Console.WriteLine("Choose option:");
            if (enterPageBLL.GetLoggedUser() == typeof(Administrator))
            {
               
                var yourChoise = Console.ReadLine();


                if (Int32.TryParse(yourChoise, out int intChoise))
                {
                    switch (intChoise)
                    {
                        case 1:
                            SearchItemPL searchItemView = new SearchItemPL();
                            searchItemView.SerfingInList();
                            break;
                        case 2:
                            NewOrderPL newOrderView = new NewOrderPL();
                            newOrderView.BuyingItems();
                            break;
                        case 3:
                            BucketOrderPL bucketOrderView = new BucketOrderPL();
                            bucketOrderView.ChangeBucketOrderStatus();
                            break;
                        case 4:
                            ChangeInfoPL changeInfoView = new ChangeInfoPL();
                            changeInfoView.ChangeValue();
                            break;
                        case 5:
                            SeeOrderHistoryPL seeOrderHistoryView = new SeeOrderHistoryPL();
                            seeOrderHistoryView.InputOrder();
                            break;
                        case 6:
                            ChangeItemPL changeItemView = new ChangeItemPL();
                            changeItemView.ChangeItemMenu();
                            break;
                        case 7:
                            AddItemPL addItemView = new AddItemPL();
                            addItemView.StartAdding();
                            break;
                        case 8:
                            MockActiveUserRepository.CurrentUser = new Guest();
                            Output();
                            Choise();
                            break;
                        default:
                            Console.WriteLine("Wrong choise");
                            Choise();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choise");
                    Task.Delay(2000);
                    Choise();
                }
            }
            else if (enterPageBLL.GetLoggedUser() == typeof(User))
            {
                
                
                var yourChoise = Console.ReadLine();

                if (Int32.TryParse(yourChoise, out int intChoise))
                {
                    switch (intChoise)
                    {
                        case 1:
                            SearchItemPL searchItemView = new SearchItemPL();
                            searchItemView.SerfingInList();
                            break;
                        case 2:
                            NewOrderPL newOrderView = new NewOrderPL();
                            newOrderView.BuyingItems();
                            break;
                        case 3:
                            BucketOrderPL bucketOrderView = new BucketOrderPL();
                            bucketOrderView.ChangeBucketOrderStatus();
                            break;
                        case 4:
                            SeeOrderHistoryPL orderHistoryView = new SeeOrderHistoryPL();
                            orderHistoryView.InputOrder();
                            break;
                        case 5:
                            ChangeInfoPL changeInfoView = new ChangeInfoPL();
                            changeInfoView.ChangeValue();
                            break;
                        case 6:
                            MockActiveUserRepository.CurrentUser = new Guest();
                            Output();
                            Choise();
                            break;
                        default:
                            Console.WriteLine("Wrong choise");
                            Choise();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choise");
                    Task.Delay(2000);
                    Choise();
                }
            }
            else
            {
                
                var yourChoise = Console.ReadLine();
                if (Int32.TryParse(yourChoise, out int intChoise))
                {
                    switch (intChoise)
                    {
                        case 1:
                            SearchItemPL searchItemPL = new SearchItemPL();
                            searchItemPL.SerfingInList();
                            break;
                        case 2:
                            LoginPagePL loginPagePL = new LoginPagePL();
                            loginPagePL.LoginProcess();
                            break;
                        case 3:
                            RegistrationPagePL reg = new RegistrationPagePL();
                            reg.Output();
                            break;
                        default:
                            Console.WriteLine("Wrong choise");
                            Choise();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choise");
                    Task.Delay(2000);
                    Choise();
                }
            }
        }
        /// <summary>
        /// Change view
        /// </summary>
        public void ChangeView()
        {
            Output();
            Choise();
        }
        

    }
}
