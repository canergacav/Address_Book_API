using Address_Book_API.Domain.Interfaces;
using Address_Book_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_API.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepo;
        public ContactService(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public async Task<APIResponse<Contact>> AddContact(ContactInput input)
        {
            Contact contact = new Contact
            {
                Address = input.Address,
                Email = input.Email,
                Name = input.Name,
                Phone = input.Phone,
                MobilePhone = input.MobilePhone
            };

            Contact IsExist = await _contactRepo.GetAsync(x => x.Name == contact.Name);

            if (IsExist != null)
                return new APIResponse<Contact>() { Code = "400", Data = null, Message = "There is already contact with the same name!", OK = false };

            Contact newContact = await _contactRepo.AddAsync(contact);

            return new APIResponse<Contact>() { Code = "200", Data = newContact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<bool>> Delete(string Id)
        {
            Contact deletedContact = await _contactRepo.DeleteAsync(Id);
            if(deletedContact == null)
                return new APIResponse<bool>() { Code = "400", Data = false, Message = "Not Found!", OK = false };

            return new APIResponse<bool>() { Code = "200", Data = true, Message = "Success", OK = true };
        }

        public async Task<APIResponse<IEnumerable<Contact>>> GetAll()
        {
            var list = _contactRepo.Get();

            return new APIResponse<IEnumerable<Contact>> () { Code = "200", Data = list, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetByAddress(string Address)
        {
            Contact contact = await _contactRepo.GetAsync(x => x.Address == Address);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetByEmail(string Email)
        {
            Contact contact = await _contactRepo.GetAsync(x => x.Email == Email);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetById(string Id)
        {
            Contact contact = await _contactRepo.GetByIdAsync(Id);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetByMobilePhone(string MobilePhone)
        {
            Contact contact = await _contactRepo.GetAsync(x => x.MobilePhone == MobilePhone);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetByName(string Name)
        {
            Contact contact = await _contactRepo.GetAsync(x => x.Name == Name);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> GetByPhone(string Phone)
        {
            Contact contact = await _contactRepo.GetAsync(x => x.Phone == Phone);
            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }

        public async Task<APIResponse<Contact>> UpdateContact(string Id, ContactInput input)
        {
            Contact contact = await _contactRepo.GetByIdAsync(Id);

            if (contact == null)
                return new APIResponse<Contact>() { Code = "400", Data = contact, Message = "Not Found!", OK = false };

            contact.Name = input.Name;
            contact.MobilePhone = input.MobilePhone;
            contact.Phone = input.Phone;
            contact.Email = input.Email;
            contact.Address = input.Address;
            contact = await _contactRepo.UpdateAsync(Id,contact);

            return new APIResponse<Contact>() { Code = "200", Data = contact, Message = "Success", OK = true };
        }
    }
}
