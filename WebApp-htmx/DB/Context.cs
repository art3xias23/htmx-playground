using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebApp_htmx.DB
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=mydatabase.db");
        }

        public void SeedData(Context context)
        {
            context.Database.EnsureCreated();
            if (!context.Contacts.Any())
            {
                var initialContacts = new List<Contact>
                {
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    },
                    new Contact
                    {
                        First = "John",
                        Last = "Doe",
                        Phone = 1234567890,
                        Email = "john@example.com",
                    },
                    new Contact
                    {
                        First = "Brian",
                        Last = "Adams",
                        Phone = 1234567890,
                        Email = "brian@example.com",
                    }
                };

                context.Contacts.AddRange(initialContacts);
                context.SaveChanges();
            }
        }
    }
}
