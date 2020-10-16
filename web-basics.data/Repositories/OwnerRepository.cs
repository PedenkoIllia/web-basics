using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class OwnerRepository
    {
        WebBasicsDBContext _context;

        public OwnerRepository(IConfiguration configuration)
        {
            _context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Owner> Get()
        {
            var owners = _context.Owners.ToList();
            return owners;
        }
    }
}
