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
    public class DepartmentPersonsManager : IDepartmentPersonsService
    {
        private readonly IDepartmentPersonsDAL _departmentPersonsDAL;
        public DepartmentPersonsManager(IDepartmentPersonsDAL departmentPersonsDAL)
        {
            _departmentPersonsDAL = departmentPersonsDAL;
        }

        public List<DepartmentPersons> GetAll(string inc)
        {
            return _departmentPersonsDAL.GetList(inc);
        }

        public DepartmentPersons GetById(int departmentPersonId)
        {
            return _departmentPersonsDAL.Get(p => p.Id == departmentPersonId);
        }

        public void Add(DepartmentPersons departmentPerson)
        {
            _departmentPersonsDAL.Add(departmentPerson);
        }

        public void Update(DepartmentPersons departmentPerson)
        {
            _departmentPersonsDAL.Update(departmentPerson);
        }

        public void Delete(int departmentPersonId)
        {
            _departmentPersonsDAL.Delete(new DepartmentPersons() { Id = departmentPersonId });
        }
    }
}
