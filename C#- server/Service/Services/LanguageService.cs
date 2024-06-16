using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servises
{
    public class LanguageService : IService<LanguageDto>
    {
        private readonly IRepository<Language> repository;
        private readonly IMapper mapper;

        public LanguageService(IRepository<Language> repository,IMapper mapper) { 
             this.repository = repository;
            this.mapper = mapper;
        }

        public LanguageDto Add(LanguageDto item)
        {
            return mapper.Map<LanguageDto>(repository.Add(mapper.Map<Language>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LanguageDto> GetAll()
        {
            return mapper.Map<List<LanguageDto>>(repository.GetAll());
        }

        public LanguageDto GetById(int id)
        {
            return mapper.Map<LanguageDto>(repository.Get(id));
        }

        public LanguageDto Update(int id, LanguageDto entity)
        {
           return mapper.Map<LanguageDto>( repository.Update(id, mapper.Map<Language>(entity)));
        }

     
    }
}
