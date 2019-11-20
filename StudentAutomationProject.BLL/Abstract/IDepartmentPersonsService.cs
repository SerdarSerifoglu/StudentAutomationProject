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
        List<DepartmentPersons> GetAll(string inc);
        void Add(DepartmentPersons departmentPerson);
        void Update(DepartmentPersons departmentPerson);
        void Delete(int departmentPersonId);
        DepartmentPersons GetById(int departmentPersonId);
    }
}
