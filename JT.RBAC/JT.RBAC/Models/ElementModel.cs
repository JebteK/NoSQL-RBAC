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
    public class ElementModel : BaseClasses.ModelBase
    {
        public override string Type
        {
            get { return TypeList.SecurityElement; }
        }

        /// <summary>
        /// For internal use - used to construct the document key
        /// </summary>
        public string ElementID { get; set; }

        /// <summary>
        /// Give it a friendly name
        /// </summary>
        [Display(Name = "Element name")]
        public string ElementName { get; set; }

        /// <summary>
        /// Describe what it is for
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Can be set by the application - used to identify which application 
        /// component is associated with this RBAC element
        /// </summary>
        [Display(Name = "Element application ID")]
        public string ElementApplicationID { get; set; }
    }
}
