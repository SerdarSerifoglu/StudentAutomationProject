using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Students : IEntity
    {
        public Students()
        {
            DepartmentPerson = new HashSet<DepartmentPerson>();
            ExamResults = new HashSet<ExamResults>();
        }

        public Guid PersonUid { get; set; }

        public virtual Persons PersonU { get; set; }
        public virtual ICollection<DepartmentPerson> DepartmentPerson { get; set; }
        public virtual ICollection<ExamResults> ExamResults { get; set; }
    }
}
