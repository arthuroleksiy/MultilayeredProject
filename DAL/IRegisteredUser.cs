using DAL;

namespace DAL
{
    /// <summary>
    /// Define <see cref="IRegisteredUser"/> enum and inherit <see cref="IRole"/> interface.
    /// </summary>
    interface IRegisteredUser : IRole
    {
        public int RegisteresUserId { set; get; }

        public string Name { set; get; }

        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }


        public string Login { get; set; }

        public string Password { get; set; }
    }
}
