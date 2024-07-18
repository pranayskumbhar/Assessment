using Assessment_18_07_2024.Common;
using Assessment_18_07_2024.Models;
using Assessment_18_07_2024.Repository;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Assessment_18_07_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string baseurl = "https://localhost:7123";
        private readonly IKalbhairavRepository _kalbhairavRepository;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IKalbhairavRepository kalbhairavRepository, HttpClient httpClient)
        {
            _logger = logger;
            _kalbhairavRepository = kalbhairavRepository;
            _httpClient = httpClient;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp([FromForm] string username, [FromForm] string password)
        {
            Assessment_18_07_2024.Models.Student student = new Assessment_18_07_2024.Models.Student();
            student.StudentUsername = username;
            student.StudentPassword = Protect.ToEncrypt(password);
            _kalbhairavRepository.signup(student);
            return View();
        }





        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            Assessment_18_07_2024.Models.Student student = new Assessment_18_07_2024.Models.Student();
            student.StudentUsername = username;
            student.StudentPassword = password;
            var check = _kalbhairavRepository.login(student);
            if (check != null)
            {
                return RedirectToAction(nameof(Welcome));
            }
            return View();
        }


        public IActionResult Welcome()
        {
            return View();
        }



        public async Task<IActionResult> GetListQuery()
        {


            HttpResponseMessage response1 = await _httpClient.GetAsync(baseurl + $"/api/StudentApi/getdataquery?id={1}&name={"PK"}");

            if (response1.IsSuccessStatusCode)
            {
                string responseBody1 = await response1.Content.ReadAsStringAsync();
                List<Assessment_18_07_2024.Models.Student> result1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Assessment_18_07_2024.Models.Student>>(responseBody1);

                ViewBag.cnt = result1.Count();
                return View("GetList", result1);
            }

            else
            {
                ViewBag.cnt = 0;
                return View(new List<Assessment_18_07_2024.Models.Student>());
            }




        }
        public async Task<IActionResult> GetList()
        {
            #region
            //int n = 20;
            //List<Assessment_18_07_2024.Models.Student> student = new List<Assessment_18_07_2024.Models.Student>();
            //while (n != 0)
            //{
            //    student.Add(new Assessment_18_07_2024.Models.Student
            //    {
            //        Id = n,
            //        StudentName = new Random().Next().ToString(),
            //        StudentSurname = new Random().Next().ToString(),
            //        StudentUsername = new Random().Next().ToString(),
            //        StudentPassword = new Random().Next().ToString(),
            //        create_date = DateTime.Now
            //    });
            //    n--;
            //}
            #endregion




            HttpResponseMessage response = await _httpClient.GetAsync(baseurl + "/api/StudentApi/getdata");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Assessment_18_07_2024.Models.Student> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Assessment_18_07_2024.Models.Student>>(responseBody);

                ViewBag.cnt = result.Count();
                return View(result);
            }

            else
            {
                ViewBag.cnt = 0;
                return View(new List<Assessment_18_07_2024.Models.Student>());
            }

























        }











        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
