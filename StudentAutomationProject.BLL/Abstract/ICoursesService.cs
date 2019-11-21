using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface ICoursesService
    {
        List<Courses> GetAll(string inc, Guid? departmentUID);
        void Add(Courses course);
        void Update(Courses course);
        void Delete(int courseId);
        Courses GetById(int courseId);
        Courses GetByUID(Guid courseUID);
    }
}
