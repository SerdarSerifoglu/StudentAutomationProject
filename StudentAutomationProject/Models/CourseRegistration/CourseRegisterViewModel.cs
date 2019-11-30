using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.CourseRegistration
{
    public class CourseRegisterViewModel
    {
        public Guid CourseUID { get; set; }
        public string CourseName { get; set; }
        public bool Exist { get; set; }
    }
}
