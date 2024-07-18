using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_18_07_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {

        private readonly List<Assessment_18_07_2024.Models.Student> _student;
        public StudentApiController()
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
                    StudentUsername = new Random().Next().ToString(),
                    StudentPassword = new Random().Next().ToString(),
                    create_date = DateTime.Now
                });
                n--;
            }
            _student = student;
        }




        [Route("getdata")]
        [HttpGet]
        public IActionResult getdata()
        {
            return Ok(_student);
        }

        [Route("getdataquery")]
        [HttpGet]
        public IActionResult getdata([FromQuery] string id, [FromQuery] string name)
        {
            return Ok(_student);
        }


        




        [HttpPost]
        [Route("api-with-urlenc")]
        [Consumes("application/x-www-form-urlencoded")]
        //public IActionResult getdatawithurlenc([FromForm] string name, [FromForm] string surname)
        public IActionResult getdatawithurlenc([FromForm] Student student)
        {
            return Ok(new { name = "Pranay", surname = "Kumbhar" });
        }

        [HttpPost]
        [Route("get-data-withpost")]
        public IActionResult getdatawithpost([FromBody] Student student)
        {
            return Ok(new { name = "Pranay", surname = "Kumbhar" });
        }

        [HttpGet]
        [Route("get-data-withquery")]
        public IActionResult getdatawithquery([FromQuery] string name, [FromQuery] string surname)
        {
            return Ok(new { name = "Pranay", surname = "Kumbhar" });
        }

    }

    public class Student
    {
        public string? name { get; set; }
        public string? surname { get; set; }
    }
}
