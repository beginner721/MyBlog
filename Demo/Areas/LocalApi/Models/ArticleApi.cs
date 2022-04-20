using System;

namespace Demo.Areas.LocalApi.Models
{
    public class ArticleApi
    {
        public string id { get; set; }
        public string categoryid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime creationdate { get; set; }
        public bool status { get; set; }
    }
}
