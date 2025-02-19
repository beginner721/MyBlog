﻿using Business.Abstract;
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

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }
        public List<Article> GetLastThreeBlog()
        {
            return _articleDal.GetAll().TakeLast(3).ToList();
        }
        public List<Article> GetArticleById(int id)
        {
            return _articleDal.GetAll(a => a.Id == id);
        }

        public List<Article> GetAllWithCategory()
        {
            return _articleDal.GetAllWithCategory();
        }

        public List<Article> GetAllByWriter(int id)
        {
            return _articleDal.GetAll(a => a.WriterId == id);
        }

        public void Add(Article entity)
        {
            _articleDal.Add(entity);
        }

        public void Update(Article entity)
        {
            _articleDal.Update(entity);
        }

        public void Delete(Article entity)
        {
            _articleDal.Delete(entity);
        }

        public Article GetById(int id)
        {
            return _articleDal.Get(id);
        }

        public List<Article> GetAllWithCategoryByWriter(int id)
        {
            return _articleDal.GetAllWithCategoryByWriter(id);
        }
    }
}
