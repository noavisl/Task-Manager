using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;

namespace Service.Servises
{
    public class EmployeeService : IService<EmployeeDto>
    {

        private readonly IRepository<Employee> repository;
        private readonly IRepository<Language> languageRepository;
        private readonly IMapper mapper;
        private readonly IContext context;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper,IRepository<Language> repository1, IContext context)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.languageRepository = repository1;
            this.context = context;
        }

        public EmployeeDto Add(EmployeeDto item)
        {
            Employee employee = mapper.Map<Employee>(item);
            employee.LanguageForEmployees = new List<LanguageForEmployee>();

            foreach (var item1 in item.LanguageInt.Keys)
            {
                Language l = languageRepository.Get(item1);
                int level = item.LanguageInt[item1];


                employee.LanguageForEmployees.Add(new LanguageForEmployee() { LanguageId=l.Id,Level=level});
            }
            return mapper.Map<EmployeeDto>(repository.Add(employee));
            
        }
        
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<EmployeeDto> GetAll()
        {
            return mapper.Map<List<EmployeeDto>>(repository.GetAll());
        }

        public EmployeeDto GetById(int id)
        {
            return mapper.Map<EmployeeDto>(repository.Get(id));
        }

        public EmployeeDto Update(int id, EmployeeDto entity)
        {
            return mapper.Map<EmployeeDto>(repository.Update(id, mapper.Map<Employee>(entity)));
        }
    }
}
