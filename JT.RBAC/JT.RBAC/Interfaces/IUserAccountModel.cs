using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.RBAC.Interfaces
{
    public interface IUserAccountModel
    {
        string Type { get; }
        string UserID { get; set; }
        string UserName { get; set; }
        string DisplayName { get; set; }
        string ConfirmPassword { get; set; }
        string OldPassword { get; set; }
        string Password { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }

        DateTimeOffset LastActive { get; set; }
        DateTimeOffset LastModified { get; set; }
        DateTimeOffset Created { get; set; }
    }
}
