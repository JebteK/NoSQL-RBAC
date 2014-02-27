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
    public class RoleElementAccessModel : BaseClasses.ModelBase
    {
        public override string Type
        {
            get { return TypeList.SecurityRoleElementAccess; }
        }

        public string RoleID { get; set; }
        public string ElementID { get; set; }

        [Display(Name = "Access Type")]
        public Enums.SecurityAccessLevels AccessLevel { get; set; }
    }
}
