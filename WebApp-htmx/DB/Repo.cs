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
                var items = context.Contacts.Add(c);
            }
        }

        public List<Contact> GetAll()
        {
            using (var context = new Context())
            {

                return context.Contacts.ToList();
            }
        }
    }
}
