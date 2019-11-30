using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.Entities.Models;
using StudentAutomationProject.Identity;
using StudentAutomationProject.Models.Course;
using StudentAutomationProject.Models.Student;

namespace StudentAutomationProject.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private readonly IStudentsService _studentsService;
        private readonly IPersonsService _personsService;
        private readonly IDepartmentsService _departmentsService;
        private readonly IDepartmentPersonsService _departmentPersonsService;
        private readonly ICoursesService _coursesService;
        public StudentController(UserManager<SapIdentityUser> userManager, IStudentsService studentsService, IPersonsService personsService, IDepartmentsService departmentsService, IDepartmentPersonsService departmentPersonsService, ICoursesService coursesService) : base(userManager, null, null)
        {
            _studentsService = studentsService;
            _personsService = personsService;
            _departmentsService = departmentsService;
            _departmentPersonsService = departmentPersonsService;
            _coursesService = coursesService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            ViewBagMethod();
            var list = _studentsService.GetDepartmentAndPersonDataList();

            return View(list);
        }

        public IActionResult Add(int departmentId)
        {
            ViewBagMethod();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Persons model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Uid = Guid.NewGuid();
            _personsService.Add(model);
            _studentsService.Add(new Students() { PersonUid = model.Uid });
            return RedirectToAction("List");
            //return RedirectToAction("List", new { departmentId = model.DepartmentId });
        }

        public IActionResult Edit(Guid uid)
        {
            ViewBagMethod();
            var data = _personsService.GetByUID(uid);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Persons model)
        {
            _personsService.Update(model);
            return RedirectToAction("List");
        }


        #region Bölüm Kayıt İşlemleri
        public IActionResult DepartmentAdd()
        {
            ViewBagMethod();
            var list = _studentsService.GetListNotDepartmentList();
            return View(list);
        }
        [HttpPost]
        public JsonResult JsonDepartmentAdd([FromBody]StudentDataModel model)
        {
            if (model != null && model.DepartmentUID != null && model.DepartmentUID != Convert.ToString(Guid.Empty))
            {
                foreach (var item in model.Dizi)
                {
                    _departmentPersonsService.Add(new DepartmentPerson()
                    {
                        Uid = Guid.NewGuid(),
                        DepartmentUid = Guid.Parse(model.DepartmentUID),
                        PersonUid = Guid.Parse(item)
                    });
                }

            }
            return Json(new { Success = true, Message = "" });
        }

        public JsonResult ListDepartmentCombo()
        {
            List<Departments> list = new List<Departments>();
            list = _departmentsService.GetAll();
            list.Insert(0, new Departments() { Uid = Guid.Empty, Name = "Bölüm Seçiniz" });
            return Json(new SelectList(list, "Uid", "Name"));
        }
        #endregion

        #region Ders Kayıt İşlemleri
        //Komple kaldırılabilir Öğrenci Kayıt yapıcak şekilde yapabilirim bakılacak
        
        public IActionResult SelectCourse()
        {
            ViewBagMethod();
            return View(new StudentCourseDataModel());
        }

        //public IActionResult CourseAdd(string courseUID)
        //{
        //    var list = _studentsService.GetListNotCourseList(Guid.Empty);
        //    return View(list);
        //}
        [HttpPost]
        public JsonResult JsonCourseAdd([FromBody]StudentCourseDataModel model)
        {
            var list = _studentsService.GetListNotCourseList(Guid.Parse(model.CourseUID));
            return Json(new { Success = true, List = list });
        }

        public IActionResult JsonCourseAdd()
        {
            var list = _studentsService.GetListNotCourseList(Guid.Empty);
            return View(list);
        }




        public JsonResult ListCourseCombo(string departmentUID)
        {
            List<Courses> list = new List<Courses>();
            list = _coursesService.GetAll(Guid.Parse(departmentUID));
            list.Insert(0, new Courses() { Uid = Guid.Empty, Name = "Ders Seçiniz" });
            return Json(new SelectList(list, "Uid", "Name"));
        }
        #endregion
    }
}