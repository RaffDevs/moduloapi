using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moduloapi.Database;
using moduloapi.Entities;

namespace moduloapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly DatabaseContext _database;
        public ContactController(DatabaseContext database) {
            _database = database;
        }

        [HttpPost]
        public IActionResult Create(Contact contact) {
            _database.Add(contact);
            _database.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var contact = _database.Contacts.Find(id);

            if (contact == null) {
                return NotFound();
            }

            return Ok(contact);

        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetByName(string name) {
            var contact = _database.Contacts.Where(contact => contact.Name.Contains(name));

            if (contact == null) {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact) {
            var findContact = _database.Contacts.Find(id);

            if (findContact == null) {
                return NotFound();
            }

            findContact.Name = contact.Name;
            findContact.Telephone = contact.Telephone;
            findContact.Active = contact.Active;

            _database.Update(findContact);
            _database.SaveChanges();

            return Ok(findContact);

        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var contact = _database.Contacts.Find(id);

            if (contact == null) {
                return NotFound();
            }

            _database.Remove(contact);
            _database.SaveChanges();

            return NoContent();
        }
    }
}