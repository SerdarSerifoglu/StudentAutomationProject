using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.Entities.Models;
using StudentAutomationProject.Identity;
using StudentAutomationProject.Models.CourseRegistration;

namespace StudentAutomationProject.Controllers
{
    [Authorize]
    public class CourseRegistrationController : BaseController
    {
        private readonly ICourseRegistrationService _courseRegistrationService;
        private readonly IDepartmentPersonsService _departmentPersonsService;
        public CourseRegistrationController(UserManager<SapIdentityUser> userManager, ICourseRegistrationService courseRegistrationService, IDepartmentPersonsService departmentPersonsService) : base(userManager, null, null)
        {
            _courseRegistrationService = courseRegistrationService;
            _departmentPersonsService = departmentPersonsService;
        }
        [Authorize(Roles = "Student")]
        public IActionResult MyCourses()
        {
            ViewBagMethod();
            var list = _courseRegistrationService.GetAllByStudentUID(CurrentUser.PersonUID ?? Guid.Empty);
            return View(list);
        }
        [Authorize(Roles = "Student")]
        public IActionResult CourseRegister()
        {
            ViewBagMethod();
            var courseList = _departmentPersonsService.GetByPersonUID(CurrentUser.PersonUID ?? Guid.Empty).DepartmentU.Courses;
            var courseRegisterList = _courseRegistrationService.GetAllByStudentUID(CurrentUser.PersonUID ?? Guid.Empty);
            List<CourseRegisterViewModel> courseRegisterViewModels = new List<CourseRegisterViewModel>();
            foreach (var course in courseList)
            {
                CourseRegisterViewModel model = new CourseRegisterViewModel();
                model.CourseUID = course.Uid;
                model.CourseName = course.Name;
                if (courseRegisterList.Where(x => x.CourseUid == course.Uid).Count() > 0)
                {
                    model.Exist = true;
                }
                else
                {
                    model.Exist = false;
                }
                courseRegisterViewModels.Add(model);
            }
            return View(courseRegisterViewModels);
        }
        [Authorize(Roles = "Student")]
        [HttpPost]
        public IActionResult CourseRegister(List<CourseRegisterViewModel> courseRegisterViewModels)
        {
            var courseRegisterList = _courseRegistrationService.GetAllByStudentUID(CurrentUser.PersonUID ?? Guid.Empty);

            foreach (var item in courseRegisterViewModels)
            {
                if (item.Exist == true && courseRegisterList.Where(x => x.CourseUid == item.CourseUID).Count() == 0)
                {
                    _courseRegistrationService.Add(
                        new CourseRegistration()
                        {
                            Uid = Guid.NewGuid(),
                            CourseUid = item.CourseUID,
                            StudentUid = CurrentUser.PersonUID,
                            Status = 1
                        });
                }
                else if (item.Exist == false && courseRegisterList.Where(x => x.CourseUid == item.CourseUID).Count() > 0)
                {
                    var deleteModel = _courseRegistrationService.GetByCourseUIDandStudentUID(item.CourseUID, CurrentUser.PersonUID ?? Guid.Empty);
                    _courseRegistrationService.Delete(deleteModel.Uid);
                }
            }
            return RedirectToAction("MyCourses");
        }
    }
}