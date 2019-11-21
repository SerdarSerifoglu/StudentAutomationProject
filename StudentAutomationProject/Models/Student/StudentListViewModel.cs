using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.Student
{
    public class StudentListViewModel
    {
        public int DepartmentId { get; set; }
        public List<Students> Students { get; set; }
    }
}
