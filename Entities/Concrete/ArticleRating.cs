using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ArticleRating
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ArticleTotalScore { get; set; }
        public int ArticleRatingCount { get; set; }
    }
}
