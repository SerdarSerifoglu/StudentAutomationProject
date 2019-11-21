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
        public StudentController(UserManager<SapIdentityUser> userManager, IStudentsService studentsService) : base(userManager, null, null)
        {
            _studentsService = studentsService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List(int departmentId)
        {
            //test yapıldı
            StudentListViewModel viewModel = new StudentListViewModel()
            {
                DepartmentId = departmentId,
                Students = _studentsService.GetAllDepartmentStudent(departmentId)
            };

            return View(viewModel);
        }

        //public IActionResult Add(int departmentId)
        //{
        //    //StudentAddViewModel viewModel = new StudentAddViewModel()
        //    //{
        //    //    DepartmentPerson = new DepartmentPersons()
        //    //    {
        //    //        DepartmentId = departmentId
        //    //    }
        //    //};

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(Students model)
        //{
        //    _studentsService.Add(model);
        //    return View(model);
        //    //return RedirectToAction("List", new { departmentId = model.DepartmentId });
        //}

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