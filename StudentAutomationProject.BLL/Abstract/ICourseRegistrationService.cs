using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface ICourseRegistrationService
    {
        List<CourseRegistration> GetAll(string inc);
        void Add(CourseRegistration courseRegistration);
        void Update(CourseRegistration courseRegistration);
        void Delete(int courseRegistrationId);
        CourseRegistration GetById(int courseRegistrationId);
    }
}
