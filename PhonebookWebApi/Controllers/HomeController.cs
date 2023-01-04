using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;
using PhonebookWebApi.Services.Interfaces;

namespace PhonebookWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IContactServices _contactServices;
        public HomeController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }
        [HttpGet]
        public async Task<List<Contact>> Index()
        {
              return await _contactServices.GetAllContacts();
        }
        [HttpPost]
        public IActionResult CreateContact([FromBody]ContactsDto request)
        {
            if(ModelState.IsValid)
            {
                _contactServices.CreateContact(request);
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteContact([FromBody] DeleteContactDto model)
        {
            if (ModelState.IsValid)
            {
                _contactServices.DeleteContact(model.PhoneNumber);
                return Ok();
            }
            return BadRequest();
        }
    }
}
