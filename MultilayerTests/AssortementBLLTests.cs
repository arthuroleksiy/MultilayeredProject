using System.Collections.Generic;
using System.Linq;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using MultilayerTests.Comparers;
namespace MultilayerTests
{
    [TestClass]
    class AssortementBLLTests
    {
        public AssortementBLL assortementBLL = new AssortementBLL();
        public ItemComparer itemComparer = new ItemComparer();

        [TestMethod]
        public void GetAssortement_ReturnsCorrect()
        {
            IEnumerable<IItem> expected = new List<IItem> {
              new ItemByNumber(28,1,"Tide", "", 80.0m,80.0m, Category.Household_Goods)
            };
            var actual = assortementBLL.GetAssortement().Where(i => i.Id == 28).Select(i => i);
            Assert.IsTrue(expected.SequenceEqual(actual, itemComparer));
        }
    }
}
