using System;
using System.Collections.Generic;
using DAL;

namespace MultilayerTests.Comparers
{
    class UsersComparer : IEqualityComparer<RegisteredUser>
    {
        public bool Equals(RegisteredUser x, RegisteredUser y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x.TelephoneNumber.Equals(y.TelephoneNumber) && x.Login.Equals(y.Login) && x.Name.Equals(y.Name) && x.Password.Equals(y.Password) && x.RegisteresUserId == y.RegisteresUserId && x.Surname.Equals(y.Surname);
        }

        public int GetHashCode(RegisteredUser obj)
        {
            return obj.GetHashCode();
        }
    }
}
