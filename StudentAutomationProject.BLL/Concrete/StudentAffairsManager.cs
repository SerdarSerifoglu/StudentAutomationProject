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

        public List<StudentAffairs> GetAll(string inc)
        {
            return _studentAffairsDAL.GetList(inc);
        }

        public StudentAffairs GetByUID(Guid studentAffairUID)
        {
            return _studentAffairsDAL.Get(p => p.PersonUid == studentAffairUID);
        }

        public void Add(StudentAffairs studentAffair)
        {
            _studentAffairsDAL.Add(studentAffair);
        }

        public void Update(StudentAffairs studentAffair)
        {
            _studentAffairsDAL.Update(studentAffair);
        }

        public void Delete(Guid studentAffairUID)
        {
            _studentAffairsDAL.Delete(new StudentAffairs() { PersonUid = studentAffairUID });
        }
    }
}
