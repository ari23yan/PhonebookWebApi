using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using System.Diagnostics;
using RestSharp;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var url = "https://localhost:7255/api/Home/Index";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = client.ExecuteAsync(request).Result;
            var output = response.Content;
                List<ContacsDto> result = JsonConvert.DeserializeObject<List<ContacsDto>>(output);
                return View(result);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(ContacsDto model)
        {
            var url = "https://localhost:7255/api/Home/CreateContact";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = client.ExecuteAsync(request).Result;
            var output = response.Content;
            ViewBag.Status = output;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteContact([FromBody] DeleteContactsDto model)
        {
            var url = "https://localhost:7255/api/Home/DeleteContact";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                PhoneNumber = model.PhoneNumber
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = client.ExecuteAsync(request).Result;
            return Json(200);
        }
    }

}
