using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.BLL.Abstract;

namespace StudentAutomationProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()

        {
            var list = _departmentsService.GetAll();
            return View(list);
        }

    }
}