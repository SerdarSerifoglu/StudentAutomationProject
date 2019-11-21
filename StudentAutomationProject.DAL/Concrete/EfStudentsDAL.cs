using Microsoft.EntityFrameworkCore;
using StudentAutomationProject.Core.DAL.EntityFramework;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.DAL.Concrete
{
    public class EfStudentsDAL : EfEntityRepositoryBase<Students, StudentAutomationDBContext>, IStudentsDAL
    {
        public List<Students> GetListFullList(int? departmentId)
        {
            using (var context = new StudentAutomationDBContext())
            {
                return (List<Students>)(from s in context.Students
                                       join dp in context.DepartmentPersons on s.PersonId equals dp.PersonId
                                       where dp.DepartmentId == departmentId
                                       select s).Include("Person").ToList();
            }
        }
    }
}
