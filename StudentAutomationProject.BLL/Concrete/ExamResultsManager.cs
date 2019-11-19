﻿using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Concrete
{
    public class ExamResultsManager : IExamResultsService
    {
        private readonly IExamResultsDAL _examResultsDAL;
        public ExamResultsManager(IExamResultsDAL examResultsDAL)
        {
            _examResultsDAL = examResultsDAL;
        }

        public List<ExamResults> GetAll()
        {
            return _examResultsDAL.GetList();
        }

        public ExamResults GetById(int examResultId)
        {
            return _examResultsDAL.Get(p => p.Id == examResultId);
        }

        public void Add(ExamResults examResult)
        {
            _examResultsDAL.Add(examResult);
        }

        public void Update(ExamResults examResult)
        {
            _examResultsDAL.Update(examResult);
        }

        public void Delete(int examResultId)
        {
            _examResultsDAL.Delete(new ExamResults() { Id = examResultId });
        }
    }
}