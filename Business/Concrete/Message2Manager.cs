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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message2> GetMessageListByWriter(int id)
        {
            return _messageDal.GetMessageListByWriter(id);
        }

        public Message2 GetById(int id)
        {
            return _messageDal.Get(id);
        }

        public void Update(Message2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
