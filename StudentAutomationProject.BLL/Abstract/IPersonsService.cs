using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IPersonsService
    {
        List<Persons> GetAll(string inc);
        void Add(Persons person);
        void Update(Persons person);
        void Delete(int personId);
        Persons GetById(int personId);
    }
}
