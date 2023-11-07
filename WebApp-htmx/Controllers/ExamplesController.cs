using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using WebApp_htmx.DB;

namespace WebApp_htmx.Controllers
{
    public class ExamplesController : Controller
    {
        public IActionResult Index()
        {
            var repo = new Repo();
            var contacts = repo.GetAll();
            return View(contacts);
        }
        public IActionResult Get()
        {
            var repo = new Repo();
            var contacts = repo.GetAll();
            return View(contacts);
        }

        public IActionResult Dog()
        {
            var repo = new Repo();
            var contacts = repo.GetAll();
            return View();
        }

        [Route("/examples/{id:int}/email")]
        [HttpGet]
        public IActionResult Email(int id)
        {
            var repo = new Repo();
            var contacts = repo.GetAll();
            var contact = contacts.First(x => x.Id == id);
            var emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!emailRegex.IsMatch(contact.Email))
            {
                return View("Error1");
            }

            return null;
        }

        [Route("/examples/more")]
        [HttpGet]
        public IActionResult MoreContacts(int count)
        {
            var repo = new Repo();
            var next20Contacts = repo.GetAll().Skip(count).Take(10).ToList();
            return View("GetMore", new Tuple<List<Contact>, int>(next20Contacts, count+10));
        }
    }
}
