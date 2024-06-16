using Microsoft.AspNetCore.Mvc;
using Common.Dto;
using Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<EmployeeDto> service;
        private IConfiguration configuration;
        public LoginController(IService<EmployeeDto> ser, IConfiguration configuration)
        {
            service = ser;
            this.configuration = configuration;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
/*        [HttpPost("{username}/{password}")]
        public IActionResult Post(string username,string password)
        {
            //אימות משתמש
           var user=Authenticate(username,password);
            if(user != null)
            {
                //יוצרת טוקן
                //var token = Generate(user);
                return  Ok(token);
            }
            return NotFound("user not found");
        }*/

        /*private object Generate(EmployeeDto user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user.FirstName),
            new Claim(ClaimTypes.Email,user.Email),
           // new Claim(ClaimTypes.Surname,user.SurName),
           // new Claim(ClaimTypes.Role,user.Role),
           // new Claim(ClaimTypes.GivenName,user.GivenName)
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        private EmployeeDto Authenticate(string username, string password)
        {
          var user= service.GetAll().FirstOrDefault(x=>x.FirstName==username&&x.Password==password);
            if(user!=null)
            {
                return user;
            }
            return null;
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
