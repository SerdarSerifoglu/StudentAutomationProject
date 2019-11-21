using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IDepartmentPersonsService
    {
        List<DepartmentPerson> GetAll(string inc);
        void Add(DepartmentPerson departmentPerson);
        void Update(DepartmentPerson departmentPerson);
        void Delete(int departmentPersonId);
        DepartmentPerson GetById(int departmentPersonId);
        DepartmentPerson GetByUID(Guid departmentPersonUID);
    }
}
