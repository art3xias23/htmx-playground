﻿using System.Text.RegularExpressions;
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
            return View("GetMore", new Tuple<List<Contact>, int>(next20Contacts, count + 10));
        }


        [Route("/examples/infinite")]
        [HttpGet]
        public async Task<IActionResult> InfiniteContacts(int count)
        {
            var repo = new Repo();
            var next20Contacts = repo.GetAll().Skip(count).Take(5).ToList();
            if (next20Contacts.Count > 0)
            {
                await (count == 0 ? Task.Delay(0) : Task.Delay(500));
                return View("GetInfinite", new Tuple<List<Contact>, int>(next20Contacts, count + 5));
            }

            return Content("<tbody><tr><td>No more items</td></tr></tbody>");
        }

        [Route("/examples/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var repo = new Repo();
            if (id > 0)
            {
                repo.Delete(id);
            }
            var contacts = repo.GetAll();
            return View("Delete", contacts);

        }


        [Route("/examples/delete")]
        [HttpPost]
        public IActionResult DeleteXvals(int id)
        {
            var repo = new Repo();
            if (id > 0)
            {
                repo.Delete(id);
            }
            var contacts = repo.GetAll();
            return View("Delete", contacts);

        }
        [Route("/examples/{id}")]
        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            var repo = new Repo();
            if (id > 0)
            {
                repo.Delete(id);
            }
            var contacts = repo.GetAll();
            return View("Delete", contacts);

        }

        [Route("/examples/edit/{id}")]
        [HttpPut]
        public IActionResult Edit(int id, string first, string last, long phone, string email)
        {
            var repo = new Repo();
            var contact = repo.Get(id);
            contact.First = first;
            contact.Last = last;
            contact.Phone = phone;
            contact.Email = email;
            repo.Update(contact);
            return View("Edit", repo.GetAll());

        }

        [Route("/examples/edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View("Edit", new Repo().GetAll());
        }

        [Route("/examples/edit/{id}")]
        [HttpGet]
        public IActionResult EditInline(int id)
        {
            return View("TableRowInput", new Repo().Get(id));
        }

        [Route("/examples/search")]
        [HttpPost]
        public async Task<IActionResult> EditInline(string search)
        {
            var contacts = new Repo().GetAll();
            if (string.IsNullOrEmpty(search))
            {
                return View("ActiveSearch", contacts);
            }

            await Task.Delay(2000);
            contacts = contacts.Where(x => x.First.Contains(search)).ToList();
            return View("ActiveSearch", contacts);
        }

        [Route("/examples/lazy")]
        [HttpGet]
        public IActionResult LazyLoading()
        {
            var contacts = new Repo().GetAll();
            return View("LazyLoading", contacts);
        }

        [Route("/examples/lazy/count")]
        [HttpGet]
        public async Task<string> LazyLoadingCount()
        {
            var contacts = new Repo().GetAll();
            await Task.Delay(4000);
            return $"Total Contacts: {contacts.Count}";
        }

        [Route("/examples/bulkdelete")]
        [HttpDelete]
        public IActionResult BulkDelete([FromForm] List<int> selection_ids_delete)
        {
            var repo = new Repo();
            repo.DeleteRange(selection_ids_delete.ToArray());
            var contacts = new Repo().GetAll();
            return View("DeleteBulk", contacts);
        }

        [Route("/examples/bulk")]
        [HttpGet]
        public IActionResult BulkDelete()
        {
            var contacts = new Repo().GetAll();
            return View("DeleteBulk", contacts);
        }
    }
}
