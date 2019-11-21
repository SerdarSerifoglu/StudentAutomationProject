using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.Student
{
    public class StudentAddViewModel
    {
        public Students Student { get; set; }
        public DepartmentPersons DepartmentPerson { get; set; }
    }
}
