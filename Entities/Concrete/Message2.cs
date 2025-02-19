﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Message2
    {
        [Key]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }//read-seen 

        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
