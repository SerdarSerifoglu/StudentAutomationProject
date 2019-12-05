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
using StudentAutomationProject.Models.ExamResult;

namespace StudentAutomationProject.Controllers
{
    [Authorize]
    public class ExamResultController : BaseController
    {
        private readonly IExamResultsService _examResultsService;
        private readonly ICourseRegistrationService _courseRegistrationService;
        private readonly ICoursesService _coursesService;
        public ExamResultController(UserManager<SapIdentityUser> userManager, IExamResultsService examResultsService, ICourseRegistrationService courseRegistrationService, ICoursesService coursesService) : base(userManager, null, null)
        {
            _examResultsService = examResultsService;
            _courseRegistrationService = courseRegistrationService;
            _coursesService = coursesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Teacher,StudentAffairs")]
        public IActionResult List(Guid examUID)
        {
            ViewBagMethod();
            TempData["ExamUID"] = examUID;
            var examResultsList = _examResultsService.GetByExamUID("PersonU.PersonU", examUID);
            return View(examResultsList);
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult Add(Guid courseUID, Guid examUID)
        {
            ViewBagMethod();
            var list = _courseRegistrationService.GetAllStudentList(courseUID, "StudentU.PersonU");
            List<ExamResultViewModel> examResultViewModels = new List<ExamResultViewModel>();
            foreach (var item in list)
            {
                ExamResultViewModel model = new ExamResultViewModel();
                model.ExamUID = examUID;
                model.PersonName = item.StudentU.PersonU.FirstName;
                model.PersonLastName = item.StudentU.PersonU.LastName;
                model.PersonUID = item.StudentUid ?? Guid.Empty;
                examResultViewModels.Add(model);
            }
            TempData["ExamUID"] = examUID;
            return View(examResultViewModels);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult Add(List<ExamResultViewModel> examResultViewModels)
        {
            var examUID = Convert.ToString(TempData["ExamUID"]);
            var resultList = _examResultsService.GetByExamUID(null, Guid.Parse(examUID));
            foreach (var item in examResultViewModels)
            {
                if (!resultList.Any(x => x.PersonUid == item.PersonUID))
                {
                    _examResultsService.Add(new ExamResults()
                    {
                        Uid = Guid.NewGuid(),
                        ExamUid = item.ExamUID,
                        PersonUid = item.PersonUID,
                        Grade = item.Grade
                    });
                }
            }
            return RedirectToAction("List", new { examUID = examUID });
        }
        [Authorize(Roles = "StudentAffairs")]
        public IActionResult Edit(Guid examUID)
        {
            ViewBagMethod();
            TempData["ExamUID"] = examUID;
            var examResultsList = _examResultsService.GetByExamUID("PersonU.PersonU", examUID);
            return View(examResultsList);
        }
        [Authorize(Roles = "StudentAffairs")]
        [HttpPost]
        public IActionResult Edit(List<ExamResults> examResultList)
        {
            var examUID = Convert.ToString(TempData["ExamUID"]);
            var resultList = _examResultsService.GetByExamUID(null, Guid.Parse(examUID));
            foreach (var item in examResultList)
            {
                if (resultList.Any(x => x.PersonUid == item.PersonUid && x.Grade != item.Grade))
                {
                    _examResultsService.Update(item);
                }
            }
            return RedirectToAction("List", new { examUID = examUID });
        }
        [Authorize(Roles = "Student,Teacher,StudentAffairs")]
        public IActionResult StudentGrades(Guid? studentUID)
        {
            ViewBagMethod();
            Guid sUID;
            if (studentUID == null)
            {
                sUID = CurrentUser.PersonUID ?? Guid.Empty;
            }
            else
            {
                sUID = studentUID ?? Guid.Empty;
            }
               
            var list = _examResultsService.GetByPersonUID(sUID);
            StudentGradesViewModel viewModel = new StudentGradesViewModel();
            viewModel.ExamResults = list;
            if (list.Count > 0)
            {
                viewModel.Student = list.FirstOrDefault().PersonU.PersonU;
            }
            return View(viewModel);
        }
    }
}