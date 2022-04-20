namespace Demo.Areas.LocalApi.Models
{
    public class OneCategoryRootObject
    {//This class for one data, not List of Data
        public CategoryApi data { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
}
