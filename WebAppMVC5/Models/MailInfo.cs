using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC5.Models
{
    public class MailInfo
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}