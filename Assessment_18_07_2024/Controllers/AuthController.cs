using Assessment_18_07_2024.Common;
using Assessment_18_07_2024.Models;
using Assessment_18_07_2024.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assessment_18_07_2024.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IKalbhairavRepository _kalbhairavRepository;

        public AuthController(IKalbhairavRepository kalbhairavRepository)
        {
            _kalbhairavRepository = kalbhairavRepository;

        }


        [Route("login")]
        [HttpPost]
        public IActionResult LoginBody([FromBody] Assessment_18_07_2024.Models.Student login)
        {

            var check = _kalbhairavRepository.login(login);
            if (check == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(StaticDetails.secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, login.StudentUsername)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Token valid for 15 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new TokenResponse { Token = tokenString });
        }




        [Route("login-urlenc")]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult LoginUE([FromBody] Assessment_18_07_2024.Models.Student login)
        {
            Assessment_18_07_2024.Models.Student student = new Assessment_18_07_2024.Models.Student();

            var check = _kalbhairavRepository.login(student);
            if (check == null)
            {
                return Unauthorized();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(StaticDetails.secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, login.StudentSurname)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Token valid for 15 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new TokenResponse { Token = tokenString });
        }





        [HttpPost]
        [Route("GetListPost")]
        //[Authorize]
        public IActionResult GetListPost()
        {
            int n = 20;
            List<Assessment_18_07_2024.Models.Student> student = new List<Assessment_18_07_2024.Models.Student>();
            while (n != 0)
            {
                student.Add(new Assessment_18_07_2024.Models.Student
                {
                    Id = n,
                    StudentName = new Random().Next().ToString(),
                    StudentSurname = new Random().Next().ToString(),
                    StudentPassword = new Random().Next().ToString(),
                    create_date = DateTime.Now
                });
                n--;
            }
            return Ok(student);
        }



        [HttpGet]
        [Route("GetList")]
        //[Authorize]
        public IActionResult GetListGet()
        {
            int n = 20;
            List<Assessment_18_07_2024.Models.Student> student = new List<Assessment_18_07_2024.Models.Student>();
            while (n != 0)
            {
                student.Add(new Assessment_18_07_2024.Models.Student
                {
                    Id = n,
                    StudentName = new Random().Next().ToString(),
                    StudentSurname = new Random().Next().ToString(),
                    StudentPassword = new Random().Next().ToString(),
                    create_date = DateTime.Now
                });
                n--;
            }
            return Ok(student);
        }
    }
}