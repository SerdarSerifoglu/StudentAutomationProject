using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Concrete
{
    public class CoursesManager : ICoursesService
    {
        private readonly ICoursesDAL _coursesDAL;
        public CoursesManager(ICoursesDAL coursesDAL)
        {
            _coursesDAL = coursesDAL;
        }

        public List<Courses> GetAll(string inc)
        {
            return _coursesDAL.GetList(inc);
        }

        public Courses GetById(int courseId)
        {
            return _coursesDAL.Get(p => p.Id == courseId);
        }

        public void Add(Courses course)
        {
            _coursesDAL.Add(course);
        }

        public void Update(Courses course)
        {
            _coursesDAL.Update(course);
        }

        public void Delete(int courseId)
        {
            _coursesDAL.Delete(new Courses() { Id = courseId });
        }
    }
}
