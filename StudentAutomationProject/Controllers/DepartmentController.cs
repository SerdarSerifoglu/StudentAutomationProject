using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.BLL.Abstract;
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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>List()
        {
            //test yapıldı
            var ss = CurrentUser;
            var serdar = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var role = await _userManager.IsInRoleAsync(serdar, "Admin");
            var list = _departmentsService.GetAll("Courses");
            return View(list);
        }

        public 
    }
}