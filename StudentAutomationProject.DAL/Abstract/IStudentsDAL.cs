using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAutomationProject.Core.DAL;
using StudentAutomationProject.Entities.Models;

namespace StudentAutomationProject.DAL.Abstract
{
    public interface IStudentsDAL : IEntityRepository<Students>
    {
        List<Students> GetListFullList(Guid? departmentUID);
        List<Students> GetListNotDepartmentList();
        List<Students> GetDepartmentAndPersonDataList();
        List<Students> GetListNotCourseList(Guid? courseUID);
    }
}
