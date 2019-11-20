using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IStudentAffairsService
    {
        List<StudentAffairs> GetAll(string inc);
        void Add(StudentAffairs studentAffair);
        void Update(StudentAffairs studentAffair);
        void Delete(int studentAffairId);
        StudentAffairs GetById(int studentAffairId);
    }
}
