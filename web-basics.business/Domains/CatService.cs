using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels;
using web_basics.data.Entities;
using web_basics.data.Repositories;

namespace web_basics.business.Domains
{
    public class CatService
    {
        CatRepository _repository;
        IMapper _mapper;

        public CatService(IConfiguration configuration)
        {
            _repository = new CatRepository(configuration);
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Cat, CatViewModel>();
            }).CreateMapper();
        }

        public IEnumerable<CatViewModel> Get()
        {
            var cats = _repository.Get();
            return cats.Select(cat => _mapper.Map<Cat, CatViewModel>(cat));
        }
    }
}
