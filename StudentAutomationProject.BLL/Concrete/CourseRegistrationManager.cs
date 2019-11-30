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
        private readonly ICourseRegistrationDAL _courseRegistrationDAL;
        public CourseRegistrationManager(ICourseRegistrationDAL courseRegistrationDAL)
        {
            _courseRegistrationDAL = courseRegistrationDAL;
        }

        public List<CourseRegistration> GetAllStudentList(Guid? courseUID, string inc = null)
        {
            return courseUID != null ? _courseRegistrationDAL.GetList(inc, x => x.CourseUid == courseUID) : _courseRegistrationDAL.GetList(inc);
        }

        public CourseRegistration GetById(int courseId)
        {
            return _courseRegistrationDAL.Get(p => p.Id == courseId);
        }

        public void Add(CourseRegistration course)
        {
            _courseRegistrationDAL.Add(course);
        }

        public void Update(CourseRegistration course)
        {
            _courseRegistrationDAL.Update(course);
        }

        public void Delete(Guid courseUID)
        {
            _courseRegistrationDAL.Delete(new CourseRegistration() { Uid = courseUID });
        }

        public CourseRegistration GetByUID(Guid courseUID)
        {
            return _courseRegistrationDAL.Get(p => p.Uid == courseUID);
        }
        public CourseRegistration GetByCourseUIDandStudentUID(Guid courseUID, Guid studentUID)
        {
            return _courseRegistrationDAL.Get(p => p.CourseUid == courseUID && p.StudentUid == studentUID);
        }
        public List<CourseRegistration> GetAllByStudentUID(Guid studentUID)
        {
            return _courseRegistrationDAL.GetList(null, x => x.StudentUid == studentUID);
        }
    }
}
