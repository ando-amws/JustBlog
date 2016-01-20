#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;
using System.Linq.Expressions;
#endregion

namespace JustBlog.Core
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// NHibernate's session object required for all db actions.
        /// </summary>
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Return true if the user exists
        /// </summary>
        /// <param name="flags"> Flags </param>
        /// <param name="username"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        public bool IsUserExist(string username, string password)
        {
            // Return number of result if the user already exists
            // and 0 if not
            var countRes = _session.Query<User>()
                             // Active = 1: Account is active (0 if not)
                             // Session = 2: Simple user session (Session = 2 for admin session)
                            .Where(user => user.Username.Equals(username) && (user.Active.Equals(1)) && (user.Session.Equals(2)) )
                            .Count();

            // We convert the result to boolean
            // True if user exists
            bool flags = Convert.ToBoolean(countRes);
            return flags;
        }

        /// <summary>
        /// Return true if the user exists
        /// </summary>
        /// <param name="flags"> Flags </param>
        /// <param name="username"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        public bool IsAdminExist(string username, string password)
        {
            // Return number of result if the user already exists
            // and 0 if not
            var countRes = _session.Query<User>()
                            // Active = 1: Account is active (0 if not)
                            // Session = 2: Simple user session (Session = 1 for admin session)
                            .Where(user => user.Username.Equals(username) && (user.Active.Equals(1)) && (user.Session.Equals(1)))
                            .Count();

            // We convert the result to boolean
            // True if user exists
            bool flags = Convert.ToBoolean(countRes);
            return flags;
        }

        /// <summary>
        /// Insert the user in DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool insert(User user)
        {
            var result = _session.CreateQuery("INSERT INTO User(firstName,lastName,Email,username,password,active,session_code) "
                + "VALUES (" + user.firstName + "," + user.lastName + "," + user.Email + "," + user.Username + ","
                        + user.Password + "," + user.Active + "," + user.Session + ")");

            var flags = Convert.ToBoolean(result);
            return flags;
        }

        // Method to get user from sgbd by his username
        public User getUser(string username)
        {
            //User user = new User();
            var data = _session.Query<User>()
                        .Where(user => user.Username.Equals(username))
                        .ToList();

            var id = data.Select(u => u.Username).ToList();

            return _session.Get<User>(username);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
