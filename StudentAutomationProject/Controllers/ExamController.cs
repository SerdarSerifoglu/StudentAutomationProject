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
{[Authorize]
    public class ExamController : BaseController
    {
        private readonly IExamsService _examsService;
        public ExamController(UserManager<SapIdentityUser> userManager,IExamsService examsService) : base(userManager, null, null)
        {
            _examsService = examsService;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Layout = StaticMethods.LayoutPicker(CurrentUser.Type);
            var list = _examsService.GetAll("CourseU");
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Exams model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Uid = Guid.NewGuid();
            model.Status = 1;
            _examsService.Add(model);
            return RedirectToAction();
        }

        public IActionResult Edit(Guid uid)
        {
            var model = _examsService.GetByUID(uid);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Exams model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _examsService.Update(model);
            return RedirectToAction();
        }
    }
}