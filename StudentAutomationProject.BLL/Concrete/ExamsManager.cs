using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Concrete
{
    public class ExamsManager : IExamsService
    {
        private readonly IExamsDAL _examsDAL;
        public ExamsManager(IExamsDAL examsDAL)
        {
            _examsDAL = examsDAL;
        }

        public List<Exams> GetAll(string inc)
        {
            return _examsDAL.GetList(inc);
        }

        public Exams GetById(int examId)
        {
            return _examsDAL.Get(p => p.Id == examId);
        }

        public void Add(Exams exam)
        {
            _examsDAL.Add(exam);
        }

        public void Update(Exams exam)
        {
            _examsDAL.Update(exam);
        }

        public void Delete(int examId)
        {
            _examsDAL.Delete(new Exams() { Id = examId });
        }
    }
}
