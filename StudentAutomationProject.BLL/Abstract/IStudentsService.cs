using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IStudentsService
    {
        List<Students> GetAllDepartmentStudent(int? departmentId);
        List<Students> GetAll(string inc);
        void Add(Students student);
        void Update(Students student);
        void Delete(int studentId);
        Students GetById(int studentId);
    }
}
