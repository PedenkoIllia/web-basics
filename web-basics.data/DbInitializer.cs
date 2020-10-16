using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cats.Any())
            {
                context.Cats.AddRange(new Cat[] {
                    new Cat() { Name = "Barsik", Age = 3 },
                    new Cat() { Name = "Kozkii", Age = 4 },
                    new Cat() { Name = "Murka", Age = 13 },
                    new Cat() { Name = "Bony", Age = 2 }
                });
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(new Account[] {
                    new Account() { Email = "user1@email.com", Password = "111111", Role = Role.User },
                    new Account() { Email = "user2@email.com", Password = "222222", Role = Role.User },
                    new Account() { Email = "admin@email.com", Password = "password", Role = Role.Admin }
                });
            }

            if (!context.Owners.Any())
            {
                context.Owners.AddRange(new Owner[] {
                    new Owner() { UserId = 1 , CatId = 1 },
                    new Owner() { UserId = 2 , CatId = 3 },
                    new Owner() { UserId = 2 , CatId = 4 }
                });
            }

            context.SaveChanges();
        }
    }
}
