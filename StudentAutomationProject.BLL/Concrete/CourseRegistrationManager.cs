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
    public class CourseRegistrationManager : ICourseRegistrationService
    {
        private readonly ICourseRegistrationDAL _courseRegistrationRegistrationDAL;
        public CourseRegistrationManager(ICourseRegistrationDAL courseRegistrationRegistrationDAL)
        {
            _courseRegistrationRegistrationDAL = courseRegistrationRegistrationDAL;
        }

        public List<CourseRegistration> GetAll()
        {
            return _courseRegistrationRegistrationDAL.GetList();
        }

        public CourseRegistration GetById(int courseRegistrationId)
        {
            return _courseRegistrationRegistrationDAL.Get(p => p.Id == courseRegistrationId);
        }

        public void Add(CourseRegistration courseRegistration)
        {
            _courseRegistrationRegistrationDAL.Add(courseRegistration);
        }

        public void Update(CourseRegistration courseRegistration)
        {
            _courseRegistrationRegistrationDAL.Update(courseRegistration);
        }

        public void Delete(int courseRegistrationId)
        {
            _courseRegistrationRegistrationDAL.Delete(new CourseRegistration() { Id = courseRegistrationId });
        }
    }
}
