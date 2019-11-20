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
        public CourseController(UserManager<SapIdentityUser> userManager, ICoursesService coursesService) : base(userManager, null, null)
        {
            _coursesService = coursesService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int departmentId)
        {
            //test yapıldı
            CourseListViewModel viewModel = new CourseListViewModel()
            {
                DepartmentId = departmentId,
                Courses = _coursesService.GetAll("Department", departmentId)
            };
            return View(viewModel);
        }

        public IActionResult Add(int departmentId)
        {
            Courses model = new Courses()
            {
                DepartmentId = departmentId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Courses model)
        {
            _coursesService.Add(model);
            return RedirectToAction("List",new { departmentId = model.DepartmentId });
        }

        public IActionResult Edit(int id)
        {
            var data = _coursesService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Courses model)
        {
            _coursesService.Update(model);
            return RedirectToAction("List", new { departmentId = model.DepartmentId });
        }
    }
}