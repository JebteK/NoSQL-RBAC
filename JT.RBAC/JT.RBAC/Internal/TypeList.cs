using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.RBAC.Internal
{
    internal class TypeList
    {
        internal static string UserAccount { get { return "JTC-User-Account"; } }
        internal static string Company { get { return "JTC-Company"; } }
        internal static string Division { get { return "JTC-Division"; } }
        internal static string Department { get { return "JTC-Department"; } }
        internal static string Team { get { return "JTC-Team"; } }
        internal static string SecurityRole { get { return "JTC-Security-Role"; } }
        internal static string SecurityElement { get { return "JTC-Security-Element"; } }
        internal static string SecurityRoleElementAccess { get { return "JTC-Security-Role-Element-Access"; } }
    }
}
