using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Servises;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IService<TaskDto> _taskService;

        public TaskController(IService<TaskDto> taskService)
        {
            _taskService = taskService;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public List<TaskDto> Get()
        {
            return _taskService.GetAll();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public TaskDto Get(int id)
        {
            return _taskService.GetById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public TaskDto Post([FromBody] TaskDto value)
        {
            return _taskService.Add(value);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public TaskDto Put(int id, [FromBody] TaskDto value)
        {

            return _taskService.Update(id, value);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _taskService.Delete(id);
        }
    }
}
