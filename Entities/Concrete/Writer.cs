﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public List<Article> Articles { get; set; }

        public virtual ICollection<Message2> SentMessage { get; set; }
        public virtual ICollection<Message2> ReceivedMessage { get; set; }
    }
}
