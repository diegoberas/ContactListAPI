using ContactList.Model;
using ContactList.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/contact
        [HttpGet]
        public IActionResult Get()
        {
            ContactRepository contact = new ContactRepository();
            return Ok(contact.GetContacts());
        }

        // GET api/contact/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ContactRepository contact = new ContactRepository();
            if (contact.GetContactById(id) == null)
                return NotFound("Contact does not exist");
            
            return Ok(contact.GetContactById(id));
        }

        // POST api/contact
        [HttpPost]
        public IActionResult Post([FromQuery] Contact contact)
        {

            if (ContactRepository.Contacts.Exists(x => x.Id == contact.Id))
                return BadRequest("Id contact already exists");

            ContactRepository.AddContact(contact);
            return Ok("Contact added");
        }

        // PUT api/contact/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery] Contact newContact)
        {
            if (!ContactRepository.Contacts.Exists(x => x.Id == id))
                return NotFound("Contact does not exist");

            ContactRepository.UpdateContact(id, newContact);
            return Ok("Contact updated");
        }

        // DELETE api/contact/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ContactRepository.Contacts.Exists(x => x.Id == id))
                return NotFound("Contact does not exist");

            ContactRepository.DeleteContact(id);
            return Ok("Contact deleted");
        }
    }
}
