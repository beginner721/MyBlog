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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
