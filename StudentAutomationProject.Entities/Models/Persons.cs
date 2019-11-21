using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Persons : IEntity
    {
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public int? Status { get; set; }

        public virtual StudentAffairs StudentAffairs { get; set; }
        public virtual Students Students { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
