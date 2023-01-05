using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;

namespace PhonebookWebApi.Services.Interfaces
{
    public interface IContactServices
    {
        Task CreateContact(ContactsDto dto);
        Task<Contact> DeleteContact(string phoneNumber);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContacts(string mobile);


    }
}
