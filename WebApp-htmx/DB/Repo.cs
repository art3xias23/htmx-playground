using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApp_htmx.DB
{
    public class Repo
    {
        public Repo()
        {
        }

        public void Insert(Contact c)
        {
            using (var context = new Context())
            {
                 context.Contacts.Add(c);
                 context.SaveChanges();
            }
        }

        public Contact Get(int id)
        {
            using (var context = new Context())
            {
                return context.Contacts.First(x=>x.Id == id);
            }
        }

        public void Update(Contact c)
        {
            using (var context = new Context())
            {
                context.Update(c);
                context.SaveChanges();
            }
        }

        public List<Contact> GetAll()
        {
            using (var context = new Context())
            {
                return context.Contacts.ToList();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                
                context.Remove(Get(id));
                context.SaveChanges();
            }
        }
    }
}
