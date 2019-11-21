using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Teachers : IEntity
    {
        public Teachers()
        {
            DepartmentPerson = new HashSet<DepartmentPerson>();
        }

        public Guid PersonUid { get; set; }

        public virtual Persons PersonU { get; set; }
        public virtual ICollection<DepartmentPerson> DepartmentPerson { get; set; }
    }
}
