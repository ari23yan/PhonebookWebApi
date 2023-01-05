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
        public async Task<IActionResult> Index()
        {
            var contact = await _contactServices.GetAllContacts();
            if(contact.Count <= 0)
            {
                return BadRequest();
            }
            return Ok(contact);
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

        [HttpDelete]
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

        [HttpGet]
        public async Task<IActionResult> GetContact([FromBody] DeleteContactDto mobile)
        {
            if(ModelState.IsValid)
            {
                var contact = await _contactServices.GetContacts(mobile.PhoneNumber);
                return Ok(contact);
            }
            return BadRequest();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContactsDto model)
        {
            if (ModelState.IsValid)
            {
                var contact = await _contactServices.GetContacts(model.PhoneNumber);
                contact.PhoneNumber = model.PhoneNumber;    
                contact.FirstName = model.FirstName;    
                contact.LastName = model.LastName;
               await _contactGenerciRepository.UpdateAsync(contact);
                return Ok(contact);
            }
            return BadRequest();
        }

    }
}
