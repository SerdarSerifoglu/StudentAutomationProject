using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Teachers : IEntity
    {
        public Teachers()
        {
            DepartmentPersons = new HashSet<DepartmentPersons>();
        }

        public int PersonId { get; set; }

        public virtual Persons Person { get; set; }
        public virtual ICollection<DepartmentPersons> DepartmentPersons { get; set; }
    }
}
