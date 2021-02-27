using Address_Book_API.Domain.Interfaces;
using Address_Book_API.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Repository
{
    public class ContactRepository : BaseCrudRepository<Contact>, IContactRepository
    {
        public ContactRepository(IMongoClient client, IOptions<MongoDbSettings> settings):base(client,settings)
        {

        }
    }
}
