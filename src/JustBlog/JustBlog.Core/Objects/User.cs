#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#endregion

namespace JustBlog.Core.Objects
{
    public class User
    {
      
        public  int Id
        { get; set; }

        public  int Session
        { get; set; }

        public  int Active
        { get; set; }


        [Required(ErrorMessage = "firstname Required")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        [Display(Name = "Firstname (*)")]
        public string firstName
        {
            get; set;
        }

        [Required(ErrorMessage = "lastname Required")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        [Display(Name = "Lastname (*)")]
        public  string lastName
        {
            get; set;
        }

        [Required(ErrorMessage = "Email Required")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        [Display(Name = "Email (*)")]
        public  string Email
        {
            get; set;
        }

        [Required(ErrorMessage = "Username Required")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        [Display(Name = "Username (*)")]
        public  string Username
        {
            get; set;
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [StringLength(30, ErrorMessage = ":Less than 30 characters")]
        [Display(Name = "Password (*)")]
        public  string Password
        {
            get; set;
        }

    }
}
