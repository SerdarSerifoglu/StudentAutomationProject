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
    public class DepartmentsManager : IDepartmentsService
    {
        private readonly IDepartmentsDAL _departmentsDAL;
        public DepartmentsManager(IDepartmentsDAL departmentsDAL)
        {
            _departmentsDAL = departmentsDAL;
        }

        public List<Departments> GetAll(string inc)
        {
            return _departmentsDAL.GetList(inc);
        }

        public Departments GetById(int departmentId)
        {
            return _departmentsDAL.Get(p => p.Id == departmentId);
        }

        public void Add(Departments department)
        {
            _departmentsDAL.Add(department);
        }

        public void Update(Departments department)
        {
            _departmentsDAL.Update(department);
        }

        public void Delete(int departmentId)
        {
            _departmentsDAL.Delete(new Departments() { Id = departmentId });
        }
        public Departments GetByUID(Guid departmentUID)
        {
            return _departmentsDAL.Get(p => p.Uid == departmentUID);
        }
    }
}
