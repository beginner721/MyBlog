using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        void Add(Article article);
        void Delete(Article article);
        void Update(Article article);
        List<Article> GetAll();
        Category GetById(int id);
        List<Article> GetAllWithCategory();
        List<Article> GetAllByWriter(int id);

    }
}
