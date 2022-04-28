using System.Collections.Generic;

namespace Demo.Areas.LocalApi.Models
{
    class ArticleListRootObject
    {
        public List<ArticleApi> data { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
}
