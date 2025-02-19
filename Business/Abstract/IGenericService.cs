﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);

        //void DeleteAll();
        //void DeleteById(int id);
        //void DeleteByName(string name);
        //void UpdateById(T entity);
        //void UpdateByName(T entity);
        //void UpdateById(T entity, int id);
    }
}
