using System.Collections.Generic;
using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class CatRepository
    {
        WebBasicsDBContext _context;

        public CatRepository(WebBasicsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Cat> Get()
        {
            var cats = _context.Cats.ToList();
            return cats;
        }
    }
}
