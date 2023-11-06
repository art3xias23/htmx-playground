using Microsoft.AspNetCore.Mvc;
using WebApp_htmx.DB;

namespace WebApp_htmx.Controllers
{
    public class ExamplesController :Controller
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
    }
}
