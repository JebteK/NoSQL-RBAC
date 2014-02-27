using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.RBAC.Interfaces
{
    public interface IModel
    {
        string Id { get; set; }
        string Type { get; }

        DateTimeOffset LastModified { get; set; }
        DateTimeOffset Created { get; set; }
    }
}
