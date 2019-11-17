using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IExamsService
    {
        List<Exams> GetAll();
        void Add(Exams exam);
        void Update(Exams exam);
        void Delete(int examId);
        Exams GetById(int examId);
    }
}
