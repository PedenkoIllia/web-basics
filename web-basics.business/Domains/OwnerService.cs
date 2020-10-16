using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;
using web_basics.data.Entities;
using web_basics.data.Repositories;

namespace web_basics.business.Domains
{
    public class OwnerService
    {
        IMapper _mapper;
        OwnerRepository _repository;

        public OwnerService(IConfiguration configuration)
        {
            _repository = new OwnerRepository(configuration);
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Owner, OwnerViewModel>();
            }).CreateMapper();
        }

        public IEnumerable<OwnerViewModel> Get()
        {
            var owners = _repository.Get();
            return owners.Select(owner => _mapper.Map<Owner, OwnerViewModel>(owner));
        }
    }
}
