using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Models
{
    public class ContactInput
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
