using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IService<VacationDto> _vacationService;

        public VacationController(IService<VacationDto> vacationService)
        {
            _vacationService = vacationService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<VacationDto> Get()
        {
            return _vacationService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public VacationDto Get(int id)
        {
            return _vacationService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public VacationDto Post([FromBody] VacationDto value)
        {
            return _vacationService.Add(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public VacationDto Put(int id, [FromBody] VacationDto value)
        {
            return _vacationService.Update(id, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vacationService.Delete(id);
        }
    }
}
