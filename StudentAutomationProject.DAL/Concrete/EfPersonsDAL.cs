using StudentAutomationProject.Core.DAL.EntityFramework;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.DAL.Concrete
{
    public class EfPersonsDAL : EfEntityRepositoryBase<Persons, StudentAutomationDBContext>, IPersonsDAL
    {
    }
}
