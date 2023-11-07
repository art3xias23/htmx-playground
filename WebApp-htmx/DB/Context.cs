using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System;

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
                    new() { First = "John", Last = "Doe", Phone = 1234567890, Email = "john@example.com" },
                    new() { First = "Jane", Last = "Smith", Phone = 2345678901, Email = "jane@example.com" },
                    new()
                    {
                        First = "Robert", Last = "Johnson", Phone = 3456789012, Email = "robert@example.com"
                    },
                    new() { First = "Emily", Last = "Williams", Phone = 4567890123, Email = "emily@example.com" },
                    new()
                    {
                        First = "Michael", Last = "Brown", Phone = 5678901234, Email = "michael@example.com"
                    },
                    new() { First = "Linda", Last = "Lee", Phone = 6789012345, Email = "linda@example.com" },
                    new() { First = "David", Last = "Anderson", Phone = 7890123456, Email = "david@example.com" },
                    new() { First = "Sarah", Last = "Martin", Phone = 8901234567, Email = "sarah@example.com" },
                    new()
                    {
                        First = "William", Last = "Wilson", Phone = 9012345678, Email = "william@example.com"
                    },
                    new() { First = "Olivia", Last = "Moore", Phone = 1234567890, Email = "olivia@example.com" },
                    new() { First = "James", Last = "Taylor", Phone = 2345678901, Email = "james@example.com" },
                    new() { First = "Ava", Last = "Jackson", Phone = 3456789012, Email = "ava@example.com" },
                    new() { First = "Joseph", Last = "Clark", Phone = 4567890123, Email = "joseph@example.com" },
                    new() { First = "Sophia", Last = "White", Phone = 5678901234, Email = "sophia@example.com" },
                    new() { First = "Daniel", Last = "Thomas", Phone = 6789012345, Email = "daniel@example.com" },
                    new() { First = "Ella", Last = "Harris", Phone = 7890123456, Email = "ella@example.com" },
                    new()
                    {
                        First = "Christopher", Last = "Wright", Phone = 8901234567, Email = "christopher@example.com"
                    },
                    new()
                    {
                        First = "Isabella", Last = "Lewis", Phone = 9012345678, Email = "isabella@example.com"
                    },
                    new()
                    {
                        First = "Matthew", Last = "Young", Phone = 1234567890, Email = "matthew@example.com"
                    },
                    new() { First = "Mia", Last = "Evans", Phone = 2345678901, Email = "mia@example.com" },
                    new() { First = "Andrew", Last = "Hall", Phone = 3456789012, Email = "andrew@example.com" },
                    new()
                    {
                        First = "Samantha", Last = "Walker", Phone = 4567890123, Email = "samantha@example.com"
                    },
                    new()
                    {
                        First = "David", Last = "Gonzalez", Phone = 5678901234, Email = "davidg@example.com"
                    },
                    new() { First = "Olivia", Last = "Perez", Phone = 6789012345, Email = "oliviap@example.com" },
                    new()
                    {
                        First = "James", Last = "Rodriguez", Phone = 7890123456, Email = "jamesr@example.com"
                    },
                    new()
                    {
                        First = "Emily", Last = "Martinez", Phone = 8901234567, Email = "emilym@example.com"
                    },
                    new() { First = "Liam", Last = "Garcia", Phone = 9012345678, Email = "liam@example.com" }
                };
                for (int i = 0; i < initialContacts.Count; i++) initialContacts[i].Id = i+1;
                context.AddRange(initialContacts);
                context.SaveChanges();
            }
        }
    }
}
