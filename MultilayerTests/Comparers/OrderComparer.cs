using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MultilayerTests.Comparers
{
    public class OrderComparer: IEqualityComparer<Order>
    {
        private readonly ItemComparer itemComparer = new ItemComparer();

        public bool Equals(Order x, Order y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x.Id == y.Id && x.Date.Equals(y.Date) && x.Items.SequenceEqual(y.Items, itemComparer) && x.Status == y.Status && x.User.Login == y.User.Login;
        }

        

        public int GetHashCode(Order obj)
        {

            return obj.GetHashCode();
        }
    }
}
