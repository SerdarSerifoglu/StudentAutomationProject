using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IExamResultsService
    {
        List<ExamResults> GetAll(string inc);
        void Add(ExamResults examResult);
        void Update(ExamResults examResult);
        void Delete(int examResultId);
        ExamResults GetById(int examResultId);
    }
}
