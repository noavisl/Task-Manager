using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageForEmployeeController : ControllerBase
    {
        private readonly IService<LanguageForEmployeeDto> _languageForEmployeeService;

        public LanguageForEmployeeController(IService<LanguageForEmployeeDto> LanguageForEmployeeService)
        {
            _languageForEmployeeService = LanguageForEmployeeService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<LanguageForEmployeeDto> Get()
        {
            return _languageForEmployeeService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public LanguageForEmployeeDto Get(int id)
        {
            return _languageForEmployeeService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public LanguageForEmployeeDto Post([FromBody] LanguageForEmployeeDto value)
        {
            return _languageForEmployeeService.Add(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public LanguageForEmployeeDto Put(int id, [FromBody] LanguageForEmployeeDto value)
        {
            return _languageForEmployeeService.Update(id, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _languageForEmployeeService.Delete(id);
        }
    }
}
