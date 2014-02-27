using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.RBAC.Models.Pieces
{
    /// <summary>
    /// This class contains the resultant user access level for each element. 
    /// The role from which the access level was derived is also stored for 
    /// reference.
    /// </summary>
    public class ResultantUserAccess
    {
        public string ElementID { get; set; }
        public string ElementApplicationID { get; set; }
        public string SelectedRoleID { get; set; }
        public Enums.SecurityAccessLevels AccessLevel { get; set; }
    }
}
