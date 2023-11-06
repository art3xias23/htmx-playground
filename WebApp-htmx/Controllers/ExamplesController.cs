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
            contact.Error = "Some Server Error";
            return View("Error1");
        }

        [Route("/examples/more")]
        [HttpGet]
        public IActionResult MoreContacts(int count)
        {
            var repo = new Repo();
            var next20Contacts = repo.GetAll().Skip(count).Take(10).ToList();
            return PartialView("Get", next20Contacts);


        }
    }
}
