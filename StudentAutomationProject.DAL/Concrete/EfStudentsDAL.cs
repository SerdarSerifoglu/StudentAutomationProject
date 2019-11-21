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
    public class EfStudentsDAL : EfEntityRepositoryBase<Students, StudentAutoDBContext>, IStudentsDAL
    {
        public List<Students> GetListFullList(Guid? departmentUID)
        {
            using (var context = new StudentAutoDBContext())
            {
                return (List<Students>)(from s in context.Students
                                       join dp in context.DepartmentPerson on s.PersonUid equals dp.PersonUid
                                       where dp.DepartmentUid == departmentUID
                                       select s).Include("PersonU").ToList();
            }
        }
    }
}
