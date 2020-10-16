using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class CatRepository
    {
        WebBasicsDBContext _context;

        public CatRepository(IConfiguration configuration)
        {
            _context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Cat> Get()
        {
            var cats = _context.Cats.ToList();
            return cats;
        }
    }
}
