using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.ExamResult
{
    public class ExamResultViewModel
    {
        public decimal? Grade { get; set; }
        public Guid PersonUID { get; set; }
        public Guid ExamUID { get; set; }
        public string PersonName { get; set; }
        public string PersonLastName { get; set; }
    }
}
