using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT.RBAC.BaseClasses
{
    public abstract class ModelBase
    {
        public virtual string Id { get; set; }
        public abstract string Type { get; }

        [Display(Name = "Last Modified")]
        public DateTimeOffset LastModified { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset Created { get; set; }
    }
}
