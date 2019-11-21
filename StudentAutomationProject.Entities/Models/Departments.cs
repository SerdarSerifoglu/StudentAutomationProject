using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Departments : IEntity
    {
        public Departments()
        {
            Courses = new HashSet<Courses>();
            DepartmentPerson = new HashSet<DepartmentPerson>();
        }

        public Guid Uid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<DepartmentPerson> DepartmentPerson { get; set; }
    }
}
