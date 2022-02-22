using Microsoft.AspNetCore.Http;

namespace Demo.Models
{
    public class AddProfileImage
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public bool Status { get; set; }
    }
}
