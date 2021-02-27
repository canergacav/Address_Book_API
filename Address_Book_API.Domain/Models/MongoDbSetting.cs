using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Models
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
