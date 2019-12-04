using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.Core.DAL
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter, string include=null);
        List<T> GetList(string inc=null,Expression<Func<T, bool>> filter = null);
        List<T> GetListOrderBy(bool desc, Expression<Func<T, Object>> orderBy, Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
