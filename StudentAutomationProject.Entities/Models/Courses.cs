using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Courses : IEntity
    {
        public Courses()
        {
            CourseRegistration = new HashSet<CourseRegistration>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? Quota { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
    }
}
