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
            DepartmentPersons = new HashSet<DepartmentPersons>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<DepartmentPersons> DepartmentPersons { get; set; }
    }
}
