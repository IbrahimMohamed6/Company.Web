﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public  class Email
    {
        public string Subject { get; set; } 
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
