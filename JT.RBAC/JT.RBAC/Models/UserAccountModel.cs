using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JT.RBAC.Internal;

namespace JT.RBAC.Models
{
    public class UserAccountModel : BaseClasses.ModelBase, Interfaces.IUserAccountModel
    {
        public override string Type
        {
            get { return TypeList.UserAccount; }
        }

        /// <summary>
        /// Used to create the database key
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// User name used to authenticate the user. This is lowercased automatically.
        /// </summary>
        [Display(Name = "Username")]
        public string UserName { get; set; }

        /// <summary>
        /// Protects casing, used to display the username
        /// </summary>
        public string DisplayName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public DateTimeOffset LastActive { get; set; }
    }
}
