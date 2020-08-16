using System.Collections.Generic;
using DAL;

namespace MultilayerTests.Comparers
{
    class ItemComparer: IEqualityComparer<IItem>
    {
        public bool Equals(IItem x, IItem y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;
            
            if (x is ItemByNumber && y is ItemByNumber)
                return x.Id == y.Id && x.Name.Equals(y.Name) && x.Price == y.Price && x.TotalPrice == y.TotalPrice && x.Description.Equals(y.Description) && x.Category == y.Category && (x as ItemByNumber).Number == (y as ItemByNumber).Number;
            else if (x is ItemByWeight && y is ItemByWeight)

                return x.Id == y.Id && x.Name.Equals(y.Name) && x.Price == y.Price && x.TotalPrice == y.TotalPrice && x.Description.Equals(y.Description) && x.Category == y.Category && (x as ItemByWeight).Weight == (y as ItemByWeight).Weight;
            else

                return false;
        }

        



        public int GetHashCode(IItem obj)
        {
            return obj.GetHashCode();
        }
    }
}
