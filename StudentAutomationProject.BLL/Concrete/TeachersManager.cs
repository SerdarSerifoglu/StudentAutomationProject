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
    public class TeachersManager : ITeachersService
    {
        private readonly ITeachersDAL _teachersDAL;
        public TeachersManager(ITeachersDAL teachersDAL)
        {
            _teachersDAL = teachersDAL;
        }

        public List<Teachers> GetAll(string inc)
        {
            return _teachersDAL.GetList(inc);
        }

        public Teachers GetByUID(Guid teacherUID)
        {
            return _teachersDAL.Get(p => p.PersonUid == teacherUID);
        }

        public void Add(Teachers teacher)
        {
            _teachersDAL.Add(teacher);
        }

        public void Update(Teachers teacher)
        {
            _teachersDAL.Update(teacher);
        }

        public void Delete(Guid teacherUID)
        {
            _teachersDAL.Delete(new Teachers() { PersonUid = teacherUID });
        }
    }
}
