using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class CourseRegistration : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public int Status { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Students Person { get; set; }
    }
}
