using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.Managers;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.PersonClasses;
namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController(IRepository<Person> manager, INationalizeProvider nationalizeProvider, DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        private readonly IRepository<Person> _manager = manager;

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            return Ok(_manager.GetAll());
        }

        [HttpGet("part-of-list")]
        public async Task<IActionResult> List(int skip, int take)
        {
            return Ok(_manager.GetAll().Skip(skip).Take(take));
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(string name, string surname)
        {
            var phoneBook = _manager.GetAll();
            if (name == null || surname == null)
            {
                return NotFound();
            }

            if (!Functions.IsInBook(phoneBook, name, surname))
            {
                return NotFound();
            }
            return Ok(Functions.Find(phoneBook, name, surname));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PersonViewModel personVM)
        {
            var phoneBook = _manager.GetAll();
            var person = new Person(personVM);
            if (ModelState.IsValid && Functions.CheckPerson(person))
            {
                if (Functions.IsInBook(phoneBook, person.Name, person.Surname))
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
            if (name == null || surname == null)
            {
                return NotFound("Null fields");
            }
            var phoneBook = _manager.GetAll();
            var foundPerson = Functions.Find(phoneBook, name, surname);
            if (foundPerson == null)
            {
                return NotFound("Person not found");
            }
            var person = new Person(personVM);
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
            var phoneBook = _manager.GetAll();
            var personToDelete = Functions.Find(phoneBook, name, surname);
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
            var phoneBook = _manager.GetAll();

            Functions.SortBook(phoneBook);
            var names = new List<Person>();
            var surnames = new List<Person>();
            foreach (var person in phoneBook)
            {
                if (person.Name.Length >= beginning.Length && person.Name[..beginning.Length] == beginning)
                {
                    names.Add(person);
                }
                if (person.Surname.Length >= beginning.Length && person.Surname.Substring(0, beginning.Length) == beginning)
                {
                    surnames.Add(person);
                }
            }

            var result = new PersonSearchResult
            {
                Names = names.Select(x => new PersonViewModel(x)).ToList(),
                Surnames = surnames.Select(x => new PersonViewModel(x)).ToList()
            };

            return Ok(result);
        }
    }
}
