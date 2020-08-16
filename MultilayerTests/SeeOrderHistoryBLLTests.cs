using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;

namespace MultilayerTests
{
    [TestClass]
    public class SeeOrderHistoryBLLTests
    {
        private readonly SeeOrderHistoryBLL seeOrderHistoryBLL = new SeeOrderHistoryBLL();

        [TestMethod]
        public void IsUserRole_IsCorrect()
        {
            MockActiveUserRepository.CurrentUser = new User();
            var actual = seeOrderHistoryBLL.IsUserRole();

            MockActiveUserRepository.CurrentUser = new Guest();
            Assert.AreEqual(true, actual);
        }
    }
}
