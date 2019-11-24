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
        List<Students> GetAllDepartmentStudent(Guid? departmentUID);
        List<Students> GetListNotDepartmentList();
        List<Students> GetDepartmentAndPersonDataList();
        List<Students> GetListNotCourseList(Guid? courseUID);
        List<Students> GetAll(string inc=null);
        void Add(Students student);
        void Update(Students student);
        void Delete(Guid studentUID);
        Students GetByUID(Guid studentUID);
    }
}
