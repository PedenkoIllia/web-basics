using System.Collections.Generic;
using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class DogRepository
    {
        WebBasicsDBContext _context;

        public DogRepository(WebBasicsDBContext context)
        {
            _context = context;
        }

        public bool Add(Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Dog> Get()
        {
            var dogs = _context.Dogs.ToList();
            return dogs;
        }
    }
}
