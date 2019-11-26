using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.Core.Statics;
using StudentAutomationProject.Entities.Models;
using StudentAutomationProject.Identity;

namespace StudentAutomationProject.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly ICoursesService _coursesService;
        public DepartmentController(UserManager<SapIdentityUser> userManager, IDepartmentsService departmentsService, ICoursesService coursesService) : base(userManager, null, null)
        {
            _departmentsService = departmentsService;
            _coursesService = coursesService;
        }
        public IActionResult Index()
        {
            var user = CurrentUser;
            return View(user);
        }

        public IActionResult List()
        {
            var list = _departmentsService.GetAll("Courses");
            return View(list);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Departments model)
        {
            model.Uid = Guid.NewGuid();
            _departmentsService.Add(model);
            return RedirectToAction("List");
        }

        public IActionResult Edit(Guid uid)
        {
            var data = _departmentsService.GetByUID(uid);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Departments model)
        {
            _departmentsService.Update(model);
            return RedirectToAction("List");
        }
    }
}