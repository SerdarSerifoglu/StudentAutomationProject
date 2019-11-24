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
    public class PersonsManager : IPersonsService
    {
        private readonly IPersonsDAL _personsDAL;
        public PersonsManager(IPersonsDAL personsDAL)
        {
            _personsDAL = personsDAL;
        }

        public List<Persons> GetAll(string inc)
        {
            return _personsDAL.GetList(inc);
        }

        public Persons GetByUID(Guid uid)
        {
            return _personsDAL.Get(p => p.Uid == uid);
        }

        public void Add(Persons person)
        {
            _personsDAL.Add(person);
        }

        public void Update(Persons person)
        {
            _personsDAL.Update(person);
        }

        public void Delete(int personId)
        {
            _personsDAL.Delete(new Persons() { Id = personId });
        }
    }
}
