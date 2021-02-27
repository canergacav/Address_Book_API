using Address_Book_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_API.Domain.Interfaces
{
    public interface IContactRepository:IBaseCrudRepository<Contact>
    {
    }
}
