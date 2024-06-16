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
    public class VacationService:IService<VacationDto>
    {
        private readonly IRepository<Vacation> repository;
        private readonly IMapper mapper;

        public VacationService(IRepository<Vacation> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public VacationDto Add(VacationDto item)
        {
            return mapper.Map<VacationDto>(repository.Add(mapper.Map<Vacation>(item)));
        }

        public Vacation Add(Vacation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<VacationDto> GetAll()
        {
            return mapper.Map<List<VacationDto>>(repository.GetAll());
        }

        public VacationDto GetById(int id)
        {
            return mapper.Map<VacationDto>(repository.Get(id));
        }

        public VacationDto Update(int id, VacationDto entity)
        {
            return mapper.Map<VacationDto>(repository.Update(id, mapper.Map<Vacation>(entity)));
        }

        public Vacation Update(int id, Vacation entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
