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
using StudentAutomationProject.Models.Student;

namespace StudentAutomationProject.Controllers
{

    public class StudentController : BaseController
    {
        private readonly IStudentsService _studentsService;
        private readonly IPersonsService _personsService;
        public StudentController(UserManager<SapIdentityUser> userManager, IStudentsService studentsService, IPersonsService personsService) : base(userManager, null, null)
        {
            _studentsService = studentsService;
            _personsService = personsService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List(Guid departmentUID)
        {
            //test yapıldı
            StudentListViewModel viewModel = new StudentListViewModel()
            {
                DepartmentUID = departmentUID,
                Students = _studentsService.GetAllDepartmentStudent(departmentUID)
            };

            return View(viewModel);
        }

        public IActionResult Add(int departmentId)
        {
            //StudentAddViewModel viewModel = new StudentAddViewModel()
            //{
            //    DepartmentPerson = new DepartmentPersons()
            //    {
            //        DepartmentId = departmentId
            //    }
            //};

            return View();
        }

        [HttpPost]
        public IActionResult Add(Persons model)
        {
            model.Uid = Guid.NewGuid();
            _personsService.Add(model);
            _studentsService.Add(new Students() { PersonUid = model.Uid });
            return View(model);
            //return RedirectToAction("List", new { departmentId = model.DepartmentId });
        }

        //public IActionResult Edit(int id)
        //{
        //    var data = _coursesService.GetById(id);
        //    return View(data);
        //}

        //[HttpPost]
        //public IActionResult Edit(Courses model)
        //{
        //    _coursesService.Update(model);
        //    return RedirectToAction("List", new { departmentId = model.DepartmentId });
        //}
    }
}