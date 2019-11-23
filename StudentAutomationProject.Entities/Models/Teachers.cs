using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Teachers : IEntity
    {
        public Teachers()
        {
        }

        public Guid PersonUid { get; set; }

        public virtual Persons PersonU { get; set; }
    }
}
