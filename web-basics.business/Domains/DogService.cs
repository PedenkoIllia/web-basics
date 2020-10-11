using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;
using web_basics.data.Entities;
using web_basics.data.Repositories;

namespace web_basics.business.Domains
{
    public class DogService
    {
        DogRepository _repository;
        IMapper _mapper;

        public DogService(DogRepository repository)
        {
            _repository = repository;
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Dog, DogViewModel>();
                cfg.CreateMap<DogViewModel, Dog>();
            }).CreateMapper();
        }

        public int Add(DogViewModel dogModel)
        {
            Dog dog = _mapper.Map<DogViewModel, Dog>(dogModel);
            return _repository.Add(dog);
        }

        public IEnumerable<DogViewModel> Get()
        {
            var dogs = _repository.Get();
            return dogs.Select(dog => _mapper.Map<Dog, DogViewModel>(dog));
        }
    }
}
