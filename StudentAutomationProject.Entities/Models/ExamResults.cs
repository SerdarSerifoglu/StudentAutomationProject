using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class ExamResults : IEntity
    {
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public Guid? ExamUid { get; set; }
        public Guid? PersonUid { get; set; }
        public decimal? Grade { get; set; }
        public int? Status { get; set; }

        public virtual Exams ExamU { get; set; }
        public virtual Students PersonU { get; set; }
    }
}
