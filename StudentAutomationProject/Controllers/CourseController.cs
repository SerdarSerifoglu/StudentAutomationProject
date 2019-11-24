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

        public async Task<IActionResult> List(Guid departmentUID)
        {
            //test yapıldı
            CourseListViewModel viewModel = new CourseListViewModel()
            {
                DepartmentUID = departmentUID,
                Courses = _coursesService.GetAll(departmentUID, "DepartmentU")
            };
            return View(viewModel);
        }

        public IActionResult Add(Guid departmentUID)
        {
            Courses model = new Courses()
            {
                DepartmentUid = departmentUID
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Courses model)
        {
            model.Uid = Guid.NewGuid();
            _coursesService.Add(model);
            return RedirectToAction("List",new { departmentUID = model.DepartmentUid });
        }

        public IActionResult Edit(Guid uid)
        {
            var data = _coursesService.GetByUID(uid);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Courses model)
        {
            _coursesService.Update(model);
            return RedirectToAction("List", new { departmentUID = model.DepartmentUid });
        }
    }
}