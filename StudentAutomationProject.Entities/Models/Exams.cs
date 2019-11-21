using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace StudentAutomationProject.Entities.Models
{
    public partial class Exams : IEntity
    {
        public Exams()
        {
            ExamResults = new HashSet<ExamResults>();
        }

        public Guid Uid { get; set; }
        public int Id { get; set; }
        public Guid? CourseUid { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; }
    }
}
