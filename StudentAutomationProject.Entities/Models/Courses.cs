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

        public Guid Uid { get; set; }
        public int Id { get; set; }
        public Guid? DepartmentUid { get; set; }
        public string Name { get; set; }
        public int? Quota { get; set; }

        public virtual Departments DepartmentU { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
    }
}
