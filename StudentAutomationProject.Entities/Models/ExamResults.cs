using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class ExamResults : IEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public decimal Grade { get; set; }

        public virtual Exams Exam { get; set; }
        public virtual Students User { get; set; }
    }
}
