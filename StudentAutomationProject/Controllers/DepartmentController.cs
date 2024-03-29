﻿using System;
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
    [Authorize]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly ICoursesService _coursesService;
        public DepartmentController(UserManager<SapIdentityUser> userManager, IDepartmentsService departmentsService, ICoursesService coursesService) : base(userManager, null, null)
        {
            _departmentsService = departmentsService;
            _coursesService = coursesService;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBagMethod();
            var user = CurrentUser;
            return View(user);
        }
        [Authorize(Roles = "Teacher,StudentAffairs")]
        public IActionResult List()
        {
            ViewBagMethod();
            var list = _departmentsService.GetAll("Courses");
            return View(list);
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Add()
        {
            ViewBagMethod();
            return View();
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Add(Departments model)
        {
            model.Uid = Guid.NewGuid();
            _departmentsService.Add(model);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Edit(Guid uid)
        {
            ViewBagMethod();
            var data = _departmentsService.GetByUID(uid);
            return View(data);
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Edit(Departments model)
        {
            _departmentsService.Update(model);
            return RedirectToAction("List");
        }
    }
}