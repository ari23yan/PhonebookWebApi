using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;
using PhonebookWebApi.Repositories.Interfaces;
using PhonebookWebApi.Services.Interfaces;

namespace PhonebookWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IContactServices _contactServices;
        private readonly IGenerciRepository<Contact> _contactGenerciRepository;
        public HomeController(IContactServices contactServices, IGenerciRepository<Contact> contactGenerciRepository)
        {
            _contactServices = contactServices;
            _contactGenerciRepository = contactGenerciRepository;

        }
        [HttpGet]
        public async Task<List<Contact>> Index()
        {
            return await _contactServices.GetAllContacts();
        }
        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactsDto request)
        {
            if (ModelState.IsValid)
            {
                _contactServices.CreateContact(request);
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact([FromBody] DeleteContactDto model)
        {
            if (ModelState.IsValid)
            {
                var contact = await _contactServices.DeleteContact(model.PhoneNumber);
                if (contact != null)
                {
                    contact.IsDeleted = true;
                    await _contactGenerciRepository.UpdateAsync(contact);
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
