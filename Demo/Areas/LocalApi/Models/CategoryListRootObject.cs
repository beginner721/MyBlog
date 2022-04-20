using System.Collections.Generic;

namespace Demo.Areas.LocalApi.Models
{
    public class CategoryListRootObject
    {
        public List<CategoryApi> data { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
}
