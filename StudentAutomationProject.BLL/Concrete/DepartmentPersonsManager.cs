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

        public List<DepartmentPerson> GetAll(string inc)
        {
            return _departmentPersonsDAL.GetList(inc);
        }

        public DepartmentPerson GetById(int departmentPersonId)
        {
            return _departmentPersonsDAL.Get(p => p.Id == departmentPersonId);
        }

        public void Add(DepartmentPerson departmentPerson)
        {
            _departmentPersonsDAL.Add(departmentPerson);
        }

        public void Update(DepartmentPerson departmentPerson)
        {
            _departmentPersonsDAL.Update(departmentPerson);
        }

        public void Delete(int departmentPersonId)
        {
            _departmentPersonsDAL.Delete(new DepartmentPerson() { Id = departmentPersonId });
        }

        public DepartmentPerson GetByUID(Guid departmentPersonUID)
        {
            return _departmentPersonsDAL.Get(p => p.DepartmentUid == departmentPersonUID);
        }
    }
}
