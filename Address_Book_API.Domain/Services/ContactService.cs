using Address_Book_API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepo;
        public ContactService(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }
    }
}
