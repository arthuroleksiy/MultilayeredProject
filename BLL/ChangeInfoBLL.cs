
using System.Collections.Generic;
using DAL;

namespace BLL
{
    /// <summary>
    /// Change info class with business logic
    /// </summary>
    public class ChangeInfoBLL
    {
        /// <summary>
        /// Collection of <see cref="RegisteredUser"/>
        /// </summary>
        private readonly List<RegisteredUser> registeredUsers = new List<RegisteredUser>();

        /// <summary>
        /// Gets collection of <see cref="RegisteredUser"/>
        /// </summary>
        /// <returns>Collection of <see cref="RegisteredUser"/></returns>
        
        public IEnumerable<RegisteredUser> GetUsers()
        {
            registeredUsers.Clear();
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                registeredUsers.Add((User)MockActiveUserRepository.CurrentUser);
            }
            else if (MockActiveUserRepository.CurrentUser.GetType() == typeof(Administrator))
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.GetType() == typeof(User))
                    {
                        registeredUsers.Add((User)i);
                        
                    }
                    else if (i.GetType() == typeof(Administrator))
                    {
                        registeredUsers.Add((Administrator)i);
                    }
                }
            } 
            else
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.GetType() == typeof(User))
                    {
                        registeredUsers.Add((User)i);

                    }
                    else if (i.GetType() == typeof(Administrator))
                    {
                        registeredUsers.Add((Administrator)i);
                    }
                }
            }

            return registeredUsers;

        }
        /// <summary>
        /// Changes name of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeName(int id, string value)
        {
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                ((User)MockActiveUserRepository.CurrentUser).Name = value;
            }
            else
            {
                foreach(var i in MockRegisteredUserRepository.AllUsers)
                {
                    if(i.RegisteresUserId == id)
                    {
                        i.Name = value;
                    }
                }
            }

            GetUsers();
        }
        /// <summary>
        /// Changes surname of user 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeSurame(int id, string value)
        {
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                ((User)MockActiveUserRepository.CurrentUser).Surname = value;
            }
            else
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.RegisteresUserId == id)
                    {
                        i.Surname = value;
                    }
                }
            }
            GetUsers();
        }
        /// <summary>
        /// Changes telephone of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeTelephone(int id, string value)
        {
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                ((User)MockActiveUserRepository.CurrentUser).TelephoneNumber = value;
            }
            else
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.RegisteresUserId == id)
                    {
                        i.TelephoneNumber = value;
                    }
                }
            }
            GetUsers();
        }
        /// <summary>
        /// Changes login of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangeLogin(int id, string value)
        {
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                ((User)MockActiveUserRepository.CurrentUser).Login = value;
            }
            else
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.RegisteresUserId == id)
                    {
                        i.Login = value;
                    }
                }
            }
            GetUsers();
        }
        /// <summary>
        /// Changes password of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void ChangePassword(int id, string value)
        {
            if (MockActiveUserRepository.CurrentUser.GetType() == typeof(User))
            {
                ((User)MockActiveUserRepository.CurrentUser).Password = value;
            }
            else
            {
                foreach (var i in MockRegisteredUserRepository.AllUsers)
                {
                    if (i.RegisteresUserId == id)
                    {
                        i.Password = value;
                    }
                }
            }
            GetUsers();
        }

    }
}
