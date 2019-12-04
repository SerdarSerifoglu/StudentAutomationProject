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
using StudentAutomationProject.Models.Course;

namespace StudentAutomationProject.Controllers
{
   [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICoursesService _coursesService;
        private readonly IDepartmentsService _departmentsService;
        public CourseController(UserManager<SapIdentityUser> userManager, ICoursesService coursesService, IDepartmentsService departmentsService) : base(userManager, null, null)
        {
            _coursesService = coursesService;
            _departmentsService = departmentsService;
        }
      
        [Authorize(Roles = "Teacher,StudentAffairs")]
        public async Task<IActionResult> List(Guid departmentUID)
        {
            ViewBagMethod();
            var departmentModel = _departmentsService.GetByUID(departmentUID);

            CourseListViewModel viewModel = new CourseListViewModel()
            {
                Department = departmentModel,
                Courses = _coursesService.GetAll(departmentUID, "DepartmentU")
            };
            return View(viewModel);
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Add(Guid departmentUID)
        {
            ViewBagMethod();
            Courses model = new Courses()
            {
                DepartmentUid = departmentUID
            };
            return View(model);
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Add(Courses model)
        {
            model.Uid = Guid.NewGuid();
            _coursesService.Add(model);
            return RedirectToAction("List",new { departmentUID = model.DepartmentUid });
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Edit(Guid uid)
        {
            ViewBagMethod();
            var data = _coursesService.GetByUID(uid);
            return View(data);
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Edit(Courses model)
        {
            _coursesService.Update(model);
            return RedirectToAction("List", new { departmentUID = model.DepartmentUid });
        }
    }
}