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

namespace Service.Services
{
    public class LanguageForEmployeeService : IService<LanguageForEmployeeDto>
    {
        private readonly IRepository<LanguageForEmployee> repository;
        private readonly IMapper mapper;

        public LanguageForEmployeeService(IRepository<LanguageForEmployee> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public LanguageForEmployeeDto Add(LanguageForEmployeeDto item)
        {
            return mapper.Map<LanguageForEmployeeDto>(repository.Add(mapper.Map<LanguageForEmployee>(item)));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<LanguageForEmployeeDto> GetAll()
        {
            return mapper.Map<List<LanguageForEmployeeDto>>(repository.GetAll());
        }

        public LanguageForEmployeeDto GetById(int id)
        {
            return mapper.Map<LanguageForEmployeeDto>(repository.Get(id));
        }

        public LanguageForEmployeeDto Update(int id, LanguageForEmployeeDto entity)
        {
            return mapper.Map<LanguageForEmployeeDto>(repository.Update(id, mapper.Map<LanguageForEmployee>(entity)));
        }
    }
}
