using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;

namespace PhonebookWebApi.Services.Interfaces
{
    public interface IContactServices
    {
        Task CreateContact(ContactsDto dto);
        Task DeleteContact(string phoneNumber);
        Task<List<Contact>> GetAllContacts();
        Task UploadFile(IFormFile file);


    }
}
