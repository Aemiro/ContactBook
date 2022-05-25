using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactBook.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetContacts()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string GetContact(int id)
        {
            return "value";
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void CreateContact([FromForm] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
