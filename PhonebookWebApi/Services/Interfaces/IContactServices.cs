using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;

namespace PhonebookWebApi.Services.Interfaces
{
    public interface IContactServices
    {
        void CreateContact(ContactsDto dto);
        void DeleteContact(string phoneNumber);
        Task<List<Contact>> GetAllContacts();
        Task UploadFile(IFormFile file);


    }
}
