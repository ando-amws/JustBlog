using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Objects;

namespace JustBlog.Core
{
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Return true if the user exists
        /// </summary>
        /// <param name="username"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        bool IsUserExist(string username, string password);

        /// <summary>
        /// Return true if the user exists
        /// </summary>
        /// <param name="username"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        bool IsAdminExist(string username, string password);

        /// <summary>
        /// Insert the user in DB
        /// </summary>
        /// <param name="user"> User Object </param>
        /// <returns></returns>
        bool insert(User user);

        User getUser(string username);
    }
}
