﻿using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.Course
{
    public class CourseListViewModel
    {
        public Guid DepartmentUID { get; set; }
        public List<Courses> Courses { get; set; }
    }
}
