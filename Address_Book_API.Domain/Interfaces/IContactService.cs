using Address_Book_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_API.Domain.Interfaces
{
    public interface IContactService
    {
        Task<APIResponse<Contact>> AddContact(ContactInput input);
        Task<APIResponse<Contact>> UpdateContact(string Id, ContactInput input);
        Task<APIResponse<Contact>> GetById(string Id);
        Task<APIResponse<Contact>> GetByName(string Name);
        Task<APIResponse<Contact>> GetByEmail(string Email);
        Task<APIResponse<Contact>> GetByAddress(string Address);
        Task<APIResponse<Contact>> GetByPhone(string Phone);
        Task<APIResponse<Contact>> GetByMobilePhone(string MobilePhone);
        Task<APIResponse<IEnumerable<Contact>>> GetAll();
        Task<APIResponse<bool>> Delete(string Id);

    }
}
