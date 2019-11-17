using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface ITeachersService
    {
        List<Teachers> GetAll();
        void Add(Teachers teacher);
        void Update(Teachers teacher);
        void Delete(int teacherId);
        Teachers GetById(int teacherId);
    }
}
