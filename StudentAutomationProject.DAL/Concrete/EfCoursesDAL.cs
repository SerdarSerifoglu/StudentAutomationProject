using Microsoft.EntityFrameworkCore;
using StudentAutomationProject.Core.DAL.EntityFramework;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.DAL.Concrete
{
    public class EfCoursesDAL : EfEntityRepositoryBase<Courses, StudentAutomationDBContext>, ICoursesDAL
    {
        public Courses GetId(int id)
        {
            using (var context = new StudentAutomationDBContext())
            {
                return context.Courses
                   .Include("Department").Include("CourseRegistration.Person.Person").Where(x=>x.Id==id)
                   .FirstOrDefault<Courses>();
               
            }

        }
    }
}
