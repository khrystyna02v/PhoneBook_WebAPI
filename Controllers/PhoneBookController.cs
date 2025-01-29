using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.PersonClasses;
using PhoneBook_webAPI.Repositories;
namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController(IPersonRepository manager) : Controller
    {
        private readonly IPersonRepository _manager = manager;

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            return Ok(_manager.GetAll());
        }

        [HttpGet("part-of-list")]
        public async Task<IActionResult> List(int skip, int take)
        {
            return Ok(_manager.GetAll(skip, take));
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(string name, string surname)
        {
            var person = _manager.Get(x => x.Surname == surname && x.Name == name);
            if (person == null)
            {
                return NotFound("Person not found");
            }
            return Ok(person);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PersonViewModel personVM)
        {
            var person = new Person(personVM);
            if (ModelState.IsValid && Functions.CheckPerson(person))
            {
                if (_manager.Get(x => x.Surname == person.Surname && x.Name == person.Name) != null)
                {
                    return BadRequest("Person already in the book");
                }
                if (!Functions.CheckEmail(person.Email))
                {
                    person.Email = null;
                }
                _manager.Add(person);
                return CreatedAtAction("Details", new { name = person.Name, surname = person.Surname }, person);
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(string name, string surname, [FromBody] PersonViewModel personVM)
        {
            var person = new Person(personVM);
            var foundPerson = _manager.Get(x => x.Surname == surname && x.Name == name);
            if (foundPerson == null)
            {
                return NotFound("Person not found");
            }
            if (ModelState.IsValid && Functions.CheckPerson(person))
            {
                if (!Functions.CheckEmail(person.Email))
                {
                    person.Email = null;
                }
                _manager.Update(foundPerson, person);
                return Ok("Person edited successfully");
            }
            return BadRequest();
        }

        [HttpDelete("deleting")]
        public async Task<IActionResult> Delete(string name, string surname)
        {
            var personToDelete = _manager.Get(x => x.Surname == surname && x.Name == name);
            if (personToDelete == null)
            {
                return NotFound("Person not found");
            }
            _manager.Delete(personToDelete);
            return Ok("Deleted successfully");
        }

        [HttpGet("beginning")]
        public async Task<IActionResult> Beginning(string beginning)
        {
            if (!Functions.CheckPartOfName(beginning))
            {
                return BadRequest();
            }
            var result = new PersonSearchResult
            {
                Names = _manager.GetAll(x => x.Name.Length >= beginning.Length && x.Name.Substring(0, beginning.Length) == beginning),
                Surnames = _manager.GetAll(x => x.Surname.Length >= beginning.Length && x.Surname.Substring(0, beginning.Length) == beginning)
            };

            return Ok(result);
        }
    }
}
