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
                                        select s).Include("PersonU").Include("DepartmentPerson.DepartmentU").ToList();
            }
        }

        public List<Students> GetListNotDepartmentList()
        {
            using (var context = new StudentAutoDBContext())
            {
                return (List<Students>)(from s in context.Students
                                        join dp in context.DepartmentPerson on s.PersonUid equals dp.PersonUid into pp
                                        from pl in pp.DefaultIfEmpty()
                                        where pl == null
                                        select s).Include("PersonU").ToList();
            }
        }

        public List<Students> GetDepartmentAndPersonDataList()
        {
            using (var context = new StudentAutoDBContext())
            {
                return context.Set<Students>().Include("PersonU").Include("DepartmentPerson.DepartmentU").ToList();
            }
        }

        public List<Students> GetListNotCourseList(Guid? courseUID)
        {
            using (var context = new StudentAutoDBContext())
            {
                return (List<Students>)(from s in context.Students
                                        join dp in context.CourseRegistration on s.PersonUid equals dp.StudentUid into pp
                                        from pl in pp.DefaultIfEmpty()
                                        where pl == null
                                        select s).Include("PersonU").ToList();
                //return (List<Students>)(from cr in context.CourseRegistration
                //                        where
                //                          cr.CourseUid != courseUID
                //                        select s).Include("PersonU").ToList();
                //return (List<Students>)(from s in context.Students
                //                        from cr in context.CourseRegistration
                //                        where
                //                          s.PersonUid != cr.StudentUid &&
                //                          cr.CourseUid != courseUID
                //                        select s).Include("PersonU").ToList();
            }
        }
    }
}
