using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class StudentAffairs : IEntity
    {
        public int PersonId { get; set; }

        public virtual Persons Person { get; set; }
    }
}
