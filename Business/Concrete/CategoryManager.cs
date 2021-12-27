using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryDal efCategoryDal;

        public CategoryManager()
        {
            efCategoryDal = new EfCategoryDal();
        }

        public void Add(Category category)
        {
            efCategoryDal.Add(category);
        }

        public void Delete(Category category)
        {

            efCategoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return efCategoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return efCategoryDal.Get(id);
        }

        public void Update(Category category)
        {
            efCategoryDal.Update(category);
        }
    }
}
