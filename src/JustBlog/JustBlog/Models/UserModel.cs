using JustBlog.Core;
using JustBlog.Core.Objects;
using System.ComponentModel.DataAnnotations;

namespace JustBlog.Models
{

   public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    } 

   public class UserModel
  {
        public User user;

        // Constructor
        public UserModel(User USER)
        {
            this.user = USER;
            user = new User();
        }
        
        // Function that verify if user exist
        public bool IsUserExist(IUserRepository userRepository, User user)
        {
            this.user = user;

            // Get Result
            bool flags = userRepository.IsUserExist(user.Username,user.Password);

            return flags;
        }

        // Function that verify if admin exist
        public bool IsAdminExist(IUserRepository userRepository, User user)
        {
            this.user = user;

            // Get Result
            bool flags = userRepository.IsAdminExist(user.Username, user.Password);

            return flags;
        }

        // Function that insert user in DB
        public bool registration(IUserRepository userRepository, User user)
        {
            this.user = user;

            // We verify that user exist or not in our DB
            if ((!IsUserExist(userRepository, user)) || (!IsAdminExist(userRepository, user)))
            {
                bool flags = userRepository.insert(user);
                return flags;
            }
            return false;
        }

    }
}