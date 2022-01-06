using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Add(Article article)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Article> GetArticleById(int id)
        {
            return _articleDal.GetAll(a => a.Id == id);
        }

        public List<Article> GetAllWithCategory()
        {
            return _articleDal.GetAllWithCategory();
        }

        public void Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
