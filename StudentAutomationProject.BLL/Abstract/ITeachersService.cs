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
        List<Teachers> GetAll(string inc);
        void Add(Teachers teacher);
        void Update(Teachers teacher);
        void Delete(Guid teacherUID);
        Teachers GetByUID(Guid teacherUID);
    }
}
