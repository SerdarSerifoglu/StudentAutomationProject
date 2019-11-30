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
    public class EfCourseRegistrationDAL : EfEntityRepositoryBase<CourseRegistration, StudentAutoDBContext>, ICourseRegistrationDAL
    {
        //public List<Courses> GetListNotRegisterCourseList()
        //{
        //    using (var context = new StudentAutoDBContext())
        //    {
        //        return (List<Courses>)(from s in context.Courses
        //                                join dp in context.CourseRegistration on s.Uid equals dp.CourseUid into pp
        //                                from pl in pp.DefaultIfEmpty()
        //                                where pl == null
        //                                select s).ToList();
        //    }
        //}
    }
}
