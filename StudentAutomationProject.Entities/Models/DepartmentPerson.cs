using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class DepartmentPerson : IEntity
    {
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public Guid? PersonUid { get; set; }
        public Guid? DepartmentUid { get; set; }

        public virtual Departments DepartmentU { get; set; }
        public virtual Students PersonU { get; set; }
    }
}
