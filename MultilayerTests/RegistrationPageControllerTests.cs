using System;
using BLL;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultilayerTests
{
    [TestClass]
    public class RegistrationPageControllerTests
    {
        private readonly RegistratiionPageBLL registrationPageController = new RegistratiionPageBLL();

        [TestMethod]
        public void RegistrationRole_IsCorrect()
        {
            var expected = true;
            var actual = registrationPageController.RegisterRole("a", "b", "c", "z", "e");
            Assert.AreEqual(expected, actual);
        }
    }
}
