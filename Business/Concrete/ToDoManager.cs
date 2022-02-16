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
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDal;

        public ToDoManager(IToDoDal toDal)
        {
            _toDal = toDal;
        }

        public void Add(ToDo entity)
        {
            _toDal.Add(entity);
        }

        public void Delete(ToDo entity)
        {
            _toDal.Delete(entity);
        }

        public List<ToDo> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDo GetById(int id)
        {
            return _toDal.Get(id);
        }

        public List<ToDo> GetTodoByWriter(int id)
        {
           return _toDal.GetAll(a => a.WriterId == id);
        }

        public void Update(ToDo entity)
        {
            throw new NotImplementedException();
        }
    }
}
