using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Collections.Generic;
using Service.Servises;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IService<LanguageDto> _languageService;

        public LanguageController(IService<LanguageDto> languageService)
        {
            _languageService = languageService;
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public List<LanguageDto> Get()
        {
            return _languageService.GetAll();
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public LanguageDto Get(int id)
        {

            return _languageService.GetById(id);
        }

        // POST api/<LanguageController>
        [HttpPost]
        public LanguageDto Post([FromBody]LanguageDto value)
        {
            return _languageService.Add(value);
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public LanguageDto Put(int id, [FromBody]LanguageDto value)
        {
            return _languageService.Update(id, value);
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _languageService.Delete(id);
        }
    }
}
