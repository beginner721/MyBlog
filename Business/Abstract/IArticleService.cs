﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        List<Article> GetAllWithCategory();
        List<Article> GetAllByWriter(int id);
        List<Article> GetAllWithCategoryByWriter(int id);

    }
}
