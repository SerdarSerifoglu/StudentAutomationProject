using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.Entities.Models;

namespace StudentAutomationProject.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Exams model)
        {
            return RedirectToAction();
        }
    }
}