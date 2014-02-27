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
    public class RoleModel : BaseClasses.ModelBase
    {
        public override string Type
        {
            get { return TypeList.SecurityRole; }
        }

        public string RoleID { get; set; }

        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
