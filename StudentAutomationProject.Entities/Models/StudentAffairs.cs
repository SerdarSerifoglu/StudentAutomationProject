﻿using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class StudentAffairs : IEntity
    {
        public Guid PersonUid { get; set; }

        public virtual Persons PersonU { get; set; }
    }
}
