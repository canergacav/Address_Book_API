using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Models
{
    public class APIResponse<T>
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public bool OK { get; set; }
        public T Data { get; set; }
    }
}
