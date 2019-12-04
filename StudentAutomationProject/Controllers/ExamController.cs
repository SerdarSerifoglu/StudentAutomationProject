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
    [Authorize]
    public class ExamController : BaseController
    {
        private readonly IExamsService _examsService;
        public ExamController(UserManager<SapIdentityUser> userManager, IExamsService examsService) : base(userManager, null, null)
        {
            _examsService = examsService;

        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Teacher,StudentAffairs")]
        public IActionResult List(Guid? courseUID)
        {
            ViewBagMethod();
            List<Exams> list = new List<Exams>();
            if (courseUID != null)
            {
                list = _examsService.GetByCourseUID("CourseU",courseUID ?? Guid.Empty);
            }
            else
            {
                list = _examsService.GetAll("CourseU");
            }
            return View(list);
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult Add()
        {
            ViewBagMethod();
            return View();
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult Add(Exams model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Uid = Guid.NewGuid();
            model.Status = 1;
            model.CreDate = DateTime.Now;
            model.CreUserUid = CurrentUser.PersonUID;
            model.ModDate = DateTime.Now;
            model.ModUserUid = CurrentUser.PersonUID;
            _examsService.Add(model);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Teacher,StudentAffairs")]
        public IActionResult Edit(Guid uid)
        {
            ViewBagMethod();
            var model = _examsService.GetByUID(uid);
            return View(model);
        }
        [Authorize(Roles = "Teacher,StudentAffairs")]
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