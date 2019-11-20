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
    public class StudentsManager : IStudentsService
    {
        private readonly IStudentsDAL _studentsDAL;
        public StudentsManager(IStudentsDAL studentsDAL)
        {
            _studentsDAL = studentsDAL;
        }

        public List<Students> GetAll(string inc)
        {
            return _studentsDAL.GetList(inc);
        }

        public Students GetById(int studentId)
        {
            return _studentsDAL.Get(p => p.PersonId == studentId);
        }

        public void Add(Students student)
        {
            _studentsDAL.Add(student);
        }

        public void Update(Students student)
        {
            _studentsDAL.Update(student);
        }

        public void Delete(int studentId)
        {
            _studentsDAL.Delete(new Students() { PersonId = studentId });
        }
    }
}
