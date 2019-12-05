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

namespace StudentAutomationProject.Controllers
{
    [Authorize]
    public class TeacherController : BaseController
    {
        private readonly ITeachersService _teachersService;
        private readonly IPersonsService _personsService;
        public TeacherController(UserManager<SapIdentityUser> userManager, ITeachersService teachersService, IPersonsService personsService) : base(userManager, null, null)
        {
            _teachersService = teachersService;
            _personsService = personsService;
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult List()
        {
            ViewBagMethod();
            var list = _teachersService.GetAll("PersonU");

            return View(list);
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Add(int departmentId)
        {
            ViewBagMethod();
            return View();
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Add(Persons model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Uid = Guid.NewGuid();
            _personsService.Add(model);
            _teachersService.Add(new Teachers() { PersonUid = model.Uid });
            return RedirectToAction("List");
        }
        [Authorize(Roles = "StudentAffairs,Teacher")]
        public IActionResult Edit(Guid uid)
        {
            ViewBagMethod();
            var data = _personsService.GetByUID(uid);
            return View(data);
        }
        [Authorize(Roles = "StudentAffairs,Teacher")]
        [HttpPost]
        public IActionResult Edit(Persons model)
        {
            _personsService.Update(model);
            return RedirectToAction("List");
        }
    }
}