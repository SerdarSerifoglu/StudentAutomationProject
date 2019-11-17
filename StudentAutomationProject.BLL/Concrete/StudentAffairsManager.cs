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
    public class StudentAffairsManager : IStudentAffairsService
    {
        private readonly IStudentAffairsDAL _studentAffairsDAL;
        public StudentAffairsManager(IStudentAffairsDAL studentAffairsDAL)
        {
            _studentAffairsDAL = studentAffairsDAL;
        }

        public List<StudentAffairs> GetAll()
        {
            return _studentAffairsDAL.GetList();
        }

        public StudentAffairs GetById(int studentAffairId)
        {
            return _studentAffairsDAL.Get(p => p.PersonId == studentAffairId);
        }

        public void Add(StudentAffairs studentAffair)
        {
            _studentAffairsDAL.Add(studentAffair);
        }

        public void Update(StudentAffairs studentAffair)
        {
            _studentAffairsDAL.Update(studentAffair);
        }

        public void Delete(int studentAffairId)
        {
            _studentAffairsDAL.Delete(new StudentAffairs() { PersonId = studentAffairId });
        }
    }
}
