using System.Linq;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cats.Any())
            {
                context.Cats.AddRange(new Entities.Cat[] {
                    new Entities.Cat() { Name = "Barsik", Age = 3 },
                    new Entities.Cat() { Name = "Kozkii", Age = 4 },
                    new Entities.Cat() { Name = "Murka", Age = 13 },
                    new Entities.Cat() { Name = "Bony", Age = 2 }
                });
            }

            if (!context.Dogs.Any())
            {
                context.Dogs.AddRange(new Entities.Dog[] {
                    new Entities.Dog() { Name = "Bella", Age = 5 },
                    new Entities.Dog() { Name = "Charlie", Age = 3 },
                    new Entities.Dog() { Name = "Luna", Age = 6 },
                    new Entities.Dog() { Name = "Palpatine", Age = 10 }
                });
            }

            context.SaveChanges();
        }
    }
}