using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Address_Book_API.Domain.Models
{
    public class ContactInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
