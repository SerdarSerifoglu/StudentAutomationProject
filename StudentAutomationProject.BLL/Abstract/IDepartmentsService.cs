using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IDepartmentsService
    {
        List<Departments> GetAll();
        void Add(Departments department);
        void Update(Departments department);
        void Delete(int departmentId);
        Departments GetById(int departmentId);
    }
}
