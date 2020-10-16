using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class AccountRepository
    {
        WebBasicsDBContext _context;

        public AccountRepository(IConfiguration configuration)
        {
            _context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Account> Get()
        {
            var accounts = _context.Accounts.ToList();
            return accounts;
        }

        public Account Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public Account Update(Account account)
        {
            Account acc = _context.Accounts.Find(account.Id);
            acc.Role = account.Role;
            _context.Accounts.Update(acc);
            _context.SaveChanges();
            return acc;
        }

        public bool Delete(int id)
        {
            Account acc = _context.Accounts.Find(id);
            if (acc == null)
                return false;
            
            _context.Accounts.Remove(acc);
            _context.SaveChanges();

            return true;
        }
    }
}
