using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.Entities.Models;
using StudentAutomationProject.Identity;
using StudentAutomationProject.Models.ExamResult;

namespace StudentAutomationProject.Controllers
{
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

        public IActionResult Add(Guid courseUID, Guid examUID)
        {
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
            TempData["CourseUID"] = courseUID;
            return View(examResultViewModels);
        }

        [HttpPost]
        public IActionResult Add(List<ExamResultViewModel> examResultViewModels)
        {
            var examUID = Convert.ToString(TempData["ExamUID"]);
            var courseUID = Convert.ToString(TempData["ExamUID"]);
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
            return View(examResultViewModels);
        }

        public IActionResult Edit(Guid examUID)
        {
            TempData["ExamUID"] = examUID;
            var examResultsList = _examResultsService.GetByExamUID("PersonU.PersonU", examUID);
            return View(examResultsList);
        }
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
            return View(examResultList);
        }
    }
}