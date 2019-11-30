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
        List<CourseRegistration> GetAllStudentList(Guid? courseUID, string inc = null);
        void Add(CourseRegistration courseRegistration);
        void Update(CourseRegistration courseRegistration);
        void Delete(Guid courseUID);
        CourseRegistration GetById(int courseRegistrationId);
        CourseRegistration GetByUID(Guid courseRegistrationUID);
        List<CourseRegistration> GetAllByStudentUID(Guid studentUID);
        CourseRegistration GetByCourseUIDandStudentUID(Guid courseUID, Guid studentUID);
    }
}
