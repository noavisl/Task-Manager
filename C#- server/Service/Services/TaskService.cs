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
    public class TaskService : IService<TaskDto>
    {
        private readonly IRepository<Repository.Entities.Task> repository;
        private readonly IMapper mapper;

        public TaskService(IRepository<Repository.Entities.Task> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public TaskDto Add(TaskDto item)
        {
            return mapper.Map<TaskDto>(repository.Add(mapper.Map<Repository.Entities.Task>(item)));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<TaskDto> GetAll()
        {
            return mapper.Map<List<TaskDto>>(repository.GetAll());
        }

        public TaskDto GetById(int id)
        {
            return mapper.Map<TaskDto>(repository.Get(id));
        }

        public TaskDto Update(int id, TaskDto entity)
        {
           return mapper.Map<TaskDto>( repository.Update(id, mapper.Map<Repository.Entities.Task>(entity)));
        }
        
       
    }
}
