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

        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; }
    }
}
