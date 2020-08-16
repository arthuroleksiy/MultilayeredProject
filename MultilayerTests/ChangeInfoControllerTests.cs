using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using System.Threading;

namespace MultilayerTests
{
    [TestClass]
    public class ChangeInfoBLLTests
    {

        

        [TestMethod]
        [DataRow(2,"Tif")]
        public void ChangeName_IsChanged(int id, string value)
        {
            ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
            var expected = "Tif";
            Thread.Sleep(100);
            changeInfoController.ChangeName(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Name;
            Assert.AreEqual(expected, actual);
        
        }


        [TestMethod]
        [DataRow(1, "Fayi")]
        public void ChangeSurname_IsChanged(int id, string value)
        {
            ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
            var expected = "Fayi";
            Thread.Sleep(100);
            changeInfoController.ChangeSurame(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Surname;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(1, "555")]
        public void ChangeTelephone_IsChanged(int id, string value)
        {
            ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
            var expected = "555";
            Thread.Sleep(100);
            changeInfoController.ChangeTelephone(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).TelephoneNumber;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(2, "kitty")]
        public void ChangeLogin_IsChanged(int id, string value)
        {
            ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
            var expected = "kitty";
            Thread.Sleep(100);
            changeInfoController.ChangeLogin(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Login;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(1, "you")]
        public void ChangePassword_IsChanged(int id, string value)
        {
            ChangeInfoBLL changeInfoController = new ChangeInfoBLL();
            var expected = "you";
            Thread.Sleep(100);
            changeInfoController.ChangePassword(id, value);
            var actual = MockRegisteredUserRepository.GetUserById(id).Password;
            Assert.AreEqual(expected, actual);
        }
    }
}
