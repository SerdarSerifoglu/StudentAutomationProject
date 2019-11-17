using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Students : IEntity
    {
        public Students()
        {
            CourseRegistration = new HashSet<CourseRegistration>();
            DepartmentPersons = new HashSet<DepartmentPersons>();
            ExamResults = new HashSet<ExamResults>();
        }

        public int PersonId { get; set; }
        public int? Type { get; set; }

        public virtual Persons Person { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
        public virtual ICollection<DepartmentPersons> DepartmentPersons { get; set; }
        public virtual ICollection<ExamResults> ExamResults { get; set; }
    }
}
