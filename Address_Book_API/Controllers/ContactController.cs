using Address_Book_API.Domain.Interfaces;
using Address_Book_API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepo;

        public ContactController(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact data)
        {
            var result = _contactRepo.AddAsync(data).Result;
            return Ok(result);
        }
    }
}
