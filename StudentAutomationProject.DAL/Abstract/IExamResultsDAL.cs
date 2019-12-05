using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAutomationProject.Core.DAL;
using StudentAutomationProject.Entities.Models;

namespace StudentAutomationProject.DAL.Abstract
{
    public interface IExamResultsDAL : IEntityRepository<ExamResults>
    {
        List<ExamResults> GetByPersonUID(Guid personUID);
    }
}
