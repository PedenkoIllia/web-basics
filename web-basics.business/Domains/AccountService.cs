using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;
using web_basics.data.Entities;
using web_basics.data.Repositories;

namespace web_basics.business.Domains
{
    public class AccountService
    {
        IMapper _mapper;
        AccountRepository _repository;

        public AccountService(IConfiguration configuration)
        {
            _repository = new AccountRepository(configuration);
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Account, AccountViewModel>();
                cfg.CreateMap<AccountViewModel, Account>();
            }).CreateMapper();

        }

        public IEnumerable<AccountViewModel> Get()
        {
            var accounts = _repository.Get();
            return accounts.Select(account => _mapper.Map<Account, AccountViewModel>(account));
        }

        public AccountViewModel Create(AccountViewModel accountModel)
        {
            Account acc = null;
            try
            {
                acc = _repository.Create(_mapper.Map<Account>(accountModel));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
            return _mapper.Map<AccountViewModel>(acc);
        }

        public AccountViewModel Update(AccountViewModel accountModel)
        {
            Account changedAccount = null;
            try
            {
                changedAccount = _repository.Update(_mapper.Map<Account>(accountModel));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            accountModel = _mapper.Map<AccountViewModel>(changedAccount);

            return accountModel;
        }

        public bool Delete(int id) => _repository.Delete(id);
    }
}
