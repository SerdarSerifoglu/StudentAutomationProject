using Microsoft.EntityFrameworkCore;
using StudentAutomationProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.Core.DAL.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetList(string inc,Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if(inc != null || inc != "")
                {
                    return filter == null
                  ? context.Set<TEntity>().Include(inc).ToList()
                  : context.Set<TEntity>().Include(inc).Where(filter).ToList();
                }
                else
                {
                    return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
                }
            }
        }

        public List<TEntity> GetListOrderBy(bool desc, Expression<Func<TEntity, Object>> orderBy = null, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (desc == true)
                {
                    return filter == null
                        ? context.Set<TEntity>().OrderByDescending(orderBy).ToList()
                        : context.Set<TEntity>().Where(filter).OrderByDescending(orderBy).ToList();
                }
                else
                {
                    return filter == null
                        ? context.Set<TEntity>().OrderBy(orderBy).ToList()
                        : context.Set<TEntity>().Where(filter).OrderBy(orderBy).ToList();
                }
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
