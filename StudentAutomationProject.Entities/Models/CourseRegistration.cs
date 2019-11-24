using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class CourseRegistration : IEntity
    {
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public Guid? CourseUid { get; set; }
        public Guid? StudentUid { get; set; }
        public int? Status { get; set; }

        public virtual Courses CourseU { get; set; }
        public virtual Students StudentU { get; set; }
    }
}
