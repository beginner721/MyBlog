using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EntityRepositoryBase<Article>, IArticleDal
    {
        public List<Article> GetAllWithCategory()
        {
            using (MyBlogContext context = new MyBlogContext())
            {
                return context.Articles.Include(a => a.Category).ToList();
            }
        }
    }
}
