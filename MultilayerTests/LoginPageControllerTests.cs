using Microsoft.VisualStudio.TestTools.UnitTesting;

using BLL;
using System.Threading;

namespace MultilayerTests
{
    [TestClass]
    public class LoginPageControllerTests
    {
        private readonly LoginPageBLL loginPageController = new LoginPageBLL();

        public LoginPageControllerTests()
        {

        }
        
        [TestMethod]
        public void CheckData_Resturn_is_Correect()
        {

            Thread.Sleep(400);
            var result = loginPageController.CheckData("kitty87", "youw");
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void Login_IsAssert()
        {
            var expected = true;
            Thread.Sleep(400);
            var actual = loginPageController.ISCorrectLogin("kitty87", "youw");
            Assert.AreEqual(expected, actual);
        }

    }
}
