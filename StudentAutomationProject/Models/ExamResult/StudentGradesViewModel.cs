using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.ExamResult
{
    public class StudentGradesViewModel
    {
        public Persons Student { get; set; }
        public List<ExamResults> ExamResults { get; set; }
    }
}
