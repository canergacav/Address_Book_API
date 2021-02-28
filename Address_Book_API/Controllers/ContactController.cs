using Address_Book_API.Domain.Interfaces;
using Address_Book_API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Address_Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Create")]
        public APIResponse<Contact> Add([FromBody] ContactInput data)
        {
            return _contactService.AddContact(data).Result;
        }

        [HttpPut("Update/Id")]
        public APIResponse<Contact> UpdateContact(string Id, [FromBody] ContactInput input)
        {
            return _contactService.UpdateContact(Id, input).Result;
        }

        [HttpGet("GetById/Id")]
        public APIResponse<Contact> GetById(string Id)
        {
            return _contactService.GetById(Id).Result;
        }

        [HttpGet("GetByName/Name")]
        public APIResponse<Contact> GetByName(string Name)
        {
            return _contactService.GetByName(Name).Result;
        }

        [HttpGet("GetByEmail/Email")]
        public APIResponse<Contact> GetByEmail(string Email)
        {
            return _contactService.GetByEmail(Email).Result;
        }

        [HttpGet("GetByAddress/Address")]
        public APIResponse<Contact> GetByAdress(string Address)
        {
            return _contactService.GetByAddress(Address).Result;
        }

        [HttpGet("GetByPhone/Phone")]
        public APIResponse<Contact> GetByPhone(string Phone)
        {
            return _contactService.GetByPhone(Phone).Result;
        }

        [HttpGet("GetByMobilePhone/MobilePhone")]
        public APIResponse<Contact> GetByMobilePhone(string MobilePhone)
        {
            return _contactService.GetByMobilePhone(MobilePhone).Result;
        }

        [HttpGet("GetAll")]
        public APIResponse<IEnumerable<Contact>> GetAll()
        {
            return _contactService.GetAll().Result;
        }

        [HttpDelete("Delete/Id")]
        public APIResponse<bool> Delete(string Id)
        {
            return _contactService.Delete(Id).Result;
        }
    }
}
