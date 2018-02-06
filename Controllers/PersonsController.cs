using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIRepositoryExample.Data;
using DIRepositoryExample.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DIRepositoryExample.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IRepository<Person> personRepository;
        public PersonsController(IRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET api/persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personRepository.All());
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var person = personRepository.FindById(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid || person == null) return BadRequest();

            if (personRepository.Add(person))
                return Ok(person);

            return BadRequest();
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]Person person)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid || person == null) return BadRequest();

            var oldPerson = personRepository.FindById(id);
            if (oldPerson == null) return NotFound();

            person.Id = oldPerson.Id;
            if (personRepository.Update(person))
                return Ok(person);
            return BadRequest();
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var person = personRepository.FindById(id);
            if (person == null) return NotFound();

            if (personRepository.Delete(person))
                return Ok(person);
            return BadRequest();
        }
    }
}
