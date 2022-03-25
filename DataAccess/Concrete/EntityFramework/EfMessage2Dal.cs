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
    public class EfMessage2Dal : EntityRepositoryBase<Message2>, IMessage2Dal
    {
        public List<Message2> GetMessageListByWriter(int id)
        {
            using (var context= new MyBlogContext())
            {
                return context.Message2s.Include(a=> a.SenderUser).Where(a=> a.ReceiverId==id).ToList();
            }
        }
    }
}
