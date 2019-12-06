using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.BLL.Abstract
{
    public interface IStudentsService
    {
        /// <summary>
        /// Bölüme kayıtlı tüm öğrencileri getirir
        /// </summary>
        /// <param name="departmentUID"></param>
        /// <returns></returns>
        List<Students> GetAllDepartmentStudent(Guid? departmentUID);
        /// <summary>
        /// Herhangi bir bölüme kayıtlı olmayan öğrencileri getirir
        /// </summary>
        /// <returns></returns>
        List<Students> GetListNotDepartmentList();
        /// <summary>
        /// Person ve Bölüm bilgilerini içerek öğrencilerin listesi
        /// </summary>
        /// <returns></returns>
        List<Students> GetDepartmentAndPersonDataList();
        /// <summary>
        /// Deneme
        /// </summary>
        /// <param name="courseUID"></param>
        /// <returns></returns>
        List<Students> GetListNotCourseList(Guid? courseUID);
        List<Students> GetAll(string inc=null);
        void Add(Students student);
        void Update(Students student);
        void Delete(Guid studentUID);
        Students GetByUID(Guid studentUID);
    }
}
