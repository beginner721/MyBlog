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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public List<Comment> GetAll(int id)
        {
            return _commentDal.GetAll(a => a.Id == id);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetCommentByArticleId(int id)
        {
            return _commentDal.GetAll(a=> a.ArticleId==id);
        }
    }
}
