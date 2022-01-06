using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityRepositoryBase<T> : IEntityRepository<T> where T:class
    {
        public void Add(T entity)
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public T Get(int id)
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public List<T> GetAll()
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
