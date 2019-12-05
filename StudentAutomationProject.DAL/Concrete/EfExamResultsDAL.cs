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
    public class EfExamResultsDAL : EfEntityRepositoryBase<ExamResults, StudentAutoDBContext>, IExamResultsDAL
    {
        public List<ExamResults> GetByPersonUID(Guid personUID)
        {
            using (var context = new StudentAutoDBContext())
            {
                return context.ExamResults
                   .Include("ExamU.CourseU").Include("PersonU.PersonU").Where(x => x.PersonUid == personUID).ToList();

            }

        }
    }
}
