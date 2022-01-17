using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface ICommentService
    {
        void Add(Comment comment);
       // void Delete(Comment comment);
      //  void Update(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetCommentByArticleId(int id);
       // Comment GetById(int id);
    }
}
